using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using EnrollmentStation.Code;
using EnrollmentStation.Code.DataObjects;
using EnrollmentStation.Code.Utilities;
using Tulpep.ActiveDirectoryObjectPicker;
using YubicoLib.YubikeyPiv;
using YubicoLib.YubikeyManager;
using MetroFramework.Forms;
using MetroFramework;

namespace EnrollmentStation
{
    public partial class DlgEnroll : MetroForm
    {
        private readonly Settings _settings;
        private readonly DataStore _dataStore;
        private bool _devicePresent;
        private bool _hasBeenEnrolled;
        private bool _hsmPresent;

        private string _enrollWorkerMessage;
        private readonly BackgroundWorker _enrollWorker;
        private readonly Timer _hsmUpdateTimer = new Timer();

        public DlgEnroll(Settings settings, DataStore dataStore)
        {
            _settings = settings;
            _dataStore = dataStore;

            _enrollWorker = new BackgroundWorker();
            _enrollWorker.DoWork += EnrollWorkerOnDoWork;
            _enrollWorker.ProgressChanged += EnrollWorkerOnProgressChanged;
            _enrollWorker.RunWorkerCompleted += EnrollWorkerOnRunWorkerCompleted;
            _enrollWorker.WorkerReportsProgress = true;

            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void DlgEnroll_Load(object sender, EventArgs e)
        {
            AcceptButton = cmdEnroll;

            // Start worker that checks for inserted yubikeys
            YubikeyDetector.Instance.StateChanged += YubikeyStateChange;
            YubikeyDetector.Instance.Start();

            _devicePresent = YubikeyDetector.Instance.CurrentState;

            // Call once for initial setup
            YubikeyStateChange();

            _hsmUpdateTimer.Interval = 1000;
            _hsmUpdateTimer.Tick += HsmUpdateTimerOnTick;
            _hsmUpdateTimer.Start();

            RefreshHSM();

            try
            {
                Domain domain = Domain.GetComputerDomain();

                if (!string.IsNullOrWhiteSpace(domain.Name))
                    llBrowseStdUser.Visible = true;
                    llBrowseAdmUser.Visible = true;
            }
            catch (ActiveDirectoryObjectNotFoundException)
            {
                llBrowseStdUser.Visible = false;
                llBrowseAdmUser.Visible = false;
            }

            // Prepare algorithms
            foreach (YubikeyAlgorithm item in YubikeyPolicyUtility.GetYubicoAlgorithms())
            {
                drpAlgorithm.Items.Add(item);

                if (item.Value == _settings.DefaultAlgorithm)
                    drpAlgorithm.SelectedItem = item;
            }
        }

        private void HsmUpdateTimerOnTick(object sender, EventArgs eventArgs)
        {
            RefreshHSM();
        }

        private void DlgEnroll_FormClosing(object sender, FormClosingEventArgs e)
        {
            YubikeyDetector.Instance.StateChanged -= YubikeyStateChange;
        }

        private void YubikeyStateChange()
        {
            string devName = YubikeyPivManager.Instance.ListDevices().FirstOrDefault();
            bool hasDevice = !string.IsNullOrEmpty(devName);

            _devicePresent = hasDevice;
            _hasBeenEnrolled = false;

            if (hasDevice)
            {
                using (YubikeyPivDevice dev = YubikeyPivManager.Instance.OpenDevice(devName))
                {
                    _hasBeenEnrolled = _dataStore.Search((int) dev.GetSerialNumber()).Any();
                }
            }

            RefreshView();
        }

        private void RefreshView()
        {
            RefreshInsertedKeyInfo();
            RefreshEligibleForEnroll();
        }

        private void RefreshHSM()
        {
            _hsmPresent = HsmRng.IsHsmPresent();
            specialYubiHsm.InvokeIfNeeded(() => specialYubiHsm.Text = _hsmPresent ? "Yes" : "No");
        }

        private void EnrollWorkerOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            if (runWorkerCompletedEventArgs.Error != null)
            {
                // An error happened
                MetroMessageBox.Show(this, "An exception has occurred: " + runWorkerCompletedEventArgs.Error.Message + Environment.NewLine + Environment.NewLine + runWorkerCompletedEventArgs.Error.StackTrace, "Unexpected error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                prgEnroll.Value = prgEnroll.Minimum;
            }
            else if (runWorkerCompletedEventArgs.Cancelled)
            {
                // An error happened
                MetroMessageBox.Show(this, _enrollWorkerMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                prgEnroll.Value = prgEnroll.Minimum;
            }
            else
            {
                prgEnroll.Value = prgEnroll.Maximum;

                // Success
                MetroMessageBox.Show(this, "Successfully enrolled Yubikey for user", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }

            cmdEnroll.Enabled = true;

            foreach (Control control in groupBox1.Controls)
                control.Enabled = true;

            foreach (Control control in groupBox3.Controls)
                control.Enabled = true;
        }

        private void EnrollWorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            string devName = YubikeyPivManager.Instance.ListDevices().FirstOrDefault();
            bool hasDevice = !string.IsNullOrEmpty(devName);

            if (!hasDevice)
                throw new InvalidOperationException("No yubikey");

            // 0. Get lock on yubikey
            using (YubikeyPivDevice dev = YubikeyPivManager.Instance.OpenDevice(devName))
            {
                // 1. Prep device info
                int deviceId = (int)dev.GetSerialNumber();
                string neoFirmware = dev.GetVersion().ToString();
                Version pivFirmware;

                using (YubikeyPivDevice piv = YubikeyPivManager.Instance.OpenDevice(devName))
                    pivFirmware = piv.GetVersion();

                _enrollWorker.ReportProgress(1);

                // 2 - Generate PUK, prep PIN
                byte[] randomKey = Utilities.GenerateRandomKey();
                string puk = Utilities.MapBytesToString(randomKey.Take(8).ToArray());

                string pin = txtPin.Text;

                _enrollWorker.ReportProgress(2);

                // 3 - Prep CA
                WindowsCertificate enrollmentAgent_std = WindowsCertStoreUtilities.FindCertificate(_settings.EnrollmentAgentCertificate);
                WindowsCertificate enrollmentAgent_adm = WindowsCertStoreUtilities.FindCertificate(_settings.EnrollmentAgentCertificate);
                string ca = _settings.CSREndpoint;
                string caTemplate = _settings.EnrollmentCaTemplate;
                string std_user = txtStdUser.Text;  //std
                string adm_user = txtAdmUser.Text;  //adm

                if (enrollmentAgent_std == null)
                {
                    doWorkEventArgs.Cancel = true;
                    _enrollWorkerMessage = "Unable to find the certificate with thumbprint: " + _settings.EnrollmentAgentCertificate;
                    return;
                }

                _enrollWorker.ReportProgress(3);

                // 4 - Prep Management Key
                // TODO: Consider a new key every time?
                byte[] mgmKey = _settings.EnrollmentManagementKey;

                _enrollWorker.ReportProgress(4);

                RSAParameters publicKey_std = new RSAParameters();
                RSAParameters publicKey_adm = new RSAParameters();
                X509Certificate2 std_cert;
                X509Certificate2 adm_cert;
                byte[] chuid;

                using (YubikeyPivDevice pivTool = YubikeyPivManager.Instance.OpenDevice(devName))
                {
                    // 5 - Yubico: Reset device
                    pivTool.BlockPin();
                    pivTool.BlockPuk();
                    bool reset = pivTool.ResetDevice();

                    if (!reset)
                    {
                        doWorkEventArgs.Cancel = true;
                        _enrollWorkerMessage = "Unable to reset the YubiKey";
                        return;
                    }

                    _enrollWorker.ReportProgress(5);

                    // 6 - Yubico: Management Key
                    bool authenticated = pivTool.Authenticate(YubikeyPivDevice.DefaultManagementKey);

                    if (!authenticated)
                    {
                        doWorkEventArgs.Cancel = true;
                        _enrollWorkerMessage = "Unable to authenticate with the YubiKey";
                        return;
                    }

                    bool setMgmKey = pivTool.SetManagementKey(mgmKey);

                    if (!setMgmKey)
                    {
                        doWorkEventArgs.Cancel = true;
                        _enrollWorkerMessage = "Unable to set the management key";
                        return;
                    }

                    _enrollWorker.ReportProgress(6);

                    // 7 - Yubico: Set CHUID
                    bool setChuid = pivTool.SetCHUID(Guid.NewGuid(), out chuid);

                    if (!setChuid)
                    {
                        doWorkEventArgs.Cancel = true;
                        _enrollWorkerMessage = "Unable to set CHUID";
                        return;
                    }

                    _enrollWorker.ReportProgress(7);

                    // 8 - Yubico: PIN
                    int tmp;
                    bool setPin = pivTool.ChangePin(YubikeyPivDevice.DefaultPin, pin, out tmp);

                    if (!setPin)
                    {
                        doWorkEventArgs.Cancel = true;
                        _enrollWorkerMessage = "Unable to set the PIN code";
                        return;
                    }

                    _enrollWorker.ReportProgress(8);

                    // 9 - Yubico: PUK
                    bool setPuk = pivTool.ChangePuk(YubikeyPivDevice.DefaultPuk, puk, out tmp);

                    if (!setPuk)
                    {
                        doWorkEventArgs.Cancel = true;
                        _enrollWorkerMessage = "Unable to set the PUK code";
                        return;
                    }

                    _enrollWorker.ReportProgress(9);

                    // 10 - Yubico: Generate Key
                    YubikeyAlgorithm algorithm = (YubikeyAlgorithm)drpAlgorithm.SelectedItem;

                    
                    if (std_user != "")
                    {
                        try
                        {
                            pivTool.GenerateKey9a(algorithm.Value, out publicKey_std);
                        }
                        catch
                        {
                            doWorkEventArgs.Cancel = true;
                            _enrollWorkerMessage = "Unable to generate a keypair for Standard User";
                            return;
                        }
                    }
                    if (adm_user != "")
                    {
                        try
                        {
                            pivTool.GenerateKey9d(algorithm.Value, out publicKey_adm);
                        }
                        catch
                        {
                            doWorkEventArgs.Cancel = true;
                            _enrollWorkerMessage = "Unable to generate a keypair for Admin User";
                            return;
                        }
                    }

                    _enrollWorker.ReportProgress(10);
                }

                // 11 - Yubico: Make CSR
                string csr_std = null;
                string csr_adm = null;
                string csrError = null;

                if(std_user != "")
                {
                    try
                    {
                        MakeCsr_std(Utilities.ExportPublicKeyToPEMFormat(publicKey_std), pin, out csrError, out csr_std);
                    }
                    catch
                    {
                        doWorkEventArgs.Cancel = true;
                        _enrollWorkerMessage = "Unable to generate a CSR for Standard User" + Environment.NewLine + csrError;
                        return;
                    }
                }

                if (adm_user != "")
                {
                    try
                    {
                        MakeCsr_adm(Utilities.ExportPublicKeyToPEMFormat(publicKey_adm), pin, out csrError, out csr_adm);
                    }
                    catch
                    {
                        doWorkEventArgs.Cancel = true;
                        _enrollWorkerMessage = "Unable to generate a CSR for Admin User" + Environment.NewLine + csrError;
                        return;
                    }
                }

                _enrollWorker.ReportProgress(11);

                // 12 - Enroll
                string std_enrollError = null;
                string adm_enrollError = null;
                bool std_enrolled = true;
                bool adm_enrolled = true;

                if (std_user != "")
                {
                    std_enrolled = CertificateUtilities.Enroll(std_user, enrollmentAgent_std, ca, caTemplate, csr_std, out std_enrollError, out std_cert);
                }
                else
                {
                    std_cert = null;
                }

                if (adm_user != "")
                {
                    adm_enrolled = CertificateUtilities.Enroll(adm_user, enrollmentAgent_adm, ca, caTemplate, csr_adm, out adm_enrollError, out adm_cert);
                }
                else
                {
                    adm_cert = null;
                }

                if (!std_enrolled)
                {
                    doWorkEventArgs.Cancel = true;
                    _enrollWorkerMessage = "Unable to enroll a certificate for Standard User." + Environment.NewLine + std_enrollError;
                    return;
                }
                if (!adm_enrolled)
                {
                    doWorkEventArgs.Cancel = true;
                    _enrollWorkerMessage = "Unable to enroll a certificate for Admin User." + Environment.NewLine + adm_enrollError;
                    return;
                }

                _enrollWorker.ReportProgress(12);

                using (YubikeyPivDevice pivTool = YubikeyPivManager.Instance.OpenDevice(devName))
                {
                    // 13 - Yubico: Import Cert
                    bool authenticatedForCert = pivTool.Authenticate(mgmKey);

                    if (!authenticatedForCert)
                    {
                        doWorkEventArgs.Cancel = true;
                        _enrollWorkerMessage = "Unable to authenticate prior to importing a certificate";
                        return;
                    }

                    if (std_user != "")
                    {
                        try
                        {
                            pivTool.SetCertificate9a(std_cert);
                        }
                        catch
                        {
                            doWorkEventArgs.Cancel = true;
                            _enrollWorkerMessage = $"Unable to import a certificate";
                            return;
                        }
                    }

                    if (adm_user != "")
                    {
                        try
                        {
                            pivTool.SetCertificate9d(adm_cert);
                        }
                        catch
                        {
                            doWorkEventArgs.Cancel = true;
                            _enrollWorkerMessage = $"Unable to import a certificate";
                            return;
                        }
                    }

                    _enrollWorker.ReportProgress(13);
                }

                // 14 - Create enrolled item for Standard User
                if (std_user != "")
                {
                    EnrolledYubikey newEnrollment_std = new EnrolledYubikey();
                    newEnrollment_std.DeviceSerial = deviceId;

                    newEnrollment_std.Certificate.Serial = std_cert.SerialNumber;
                    newEnrollment_std.Certificate.Thumbprint = std_cert.Thumbprint;
                    newEnrollment_std.Certificate.Subject = std_cert.Subject;
                    newEnrollment_std.Certificate.Issuer = std_cert.Issuer;
                    newEnrollment_std.Certificate.StartDate = std_cert.NotBefore;
                    newEnrollment_std.Certificate.ExpireDate = std_cert.NotAfter;
                    newEnrollment_std.Certificate.RawCertificate = std_cert.RawData;

                    newEnrollment_std.CA = ca;
                    newEnrollment_std.Username = std_user;
                    newEnrollment_std.Slot = "Standard User";
                    newEnrollment_std.ManagementKey = mgmKey;
                    newEnrollment_std.PukKey = puk;
                    newEnrollment_std.Chuid = BitConverter.ToString(chuid).Replace("-", "");

                    newEnrollment_std.EnrolledAt = DateTime.UtcNow;

                    newEnrollment_std.YubikeyVersions.NeoFirmware = neoFirmware;
                    newEnrollment_std.YubikeyVersions.PivApplet = pivFirmware.ToString();

                    _dataStore.Add(newEnrollment_std);
                }

                // 14 - Create enrolled item for Admin User
                if (adm_user != "")
                {
                    EnrolledYubikey newEnrollment_adm = new EnrolledYubikey();
                    newEnrollment_adm.DeviceSerial = deviceId;

                    newEnrollment_adm.Certificate.Serial = adm_cert.SerialNumber;
                    newEnrollment_adm.Certificate.Thumbprint = adm_cert.Thumbprint;
                    newEnrollment_adm.Certificate.Subject = adm_cert.Subject;
                    newEnrollment_adm.Certificate.Issuer = adm_cert.Issuer;
                    newEnrollment_adm.Certificate.StartDate = adm_cert.NotBefore;
                    newEnrollment_adm.Certificate.ExpireDate = adm_cert.NotAfter;
                    newEnrollment_adm.Certificate.RawCertificate = adm_cert.RawData;

                    newEnrollment_adm.CA = ca;
                    newEnrollment_adm.Username = adm_user;
                    newEnrollment_adm.Slot = "Admin User";
                    newEnrollment_adm.ManagementKey = mgmKey;
                    newEnrollment_adm.PukKey = puk;
                    newEnrollment_adm.Chuid = BitConverter.ToString(chuid).Replace("-", "");

                    newEnrollment_adm.EnrolledAt = DateTime.UtcNow;

                    newEnrollment_adm.YubikeyVersions.NeoFirmware = neoFirmware;
                    newEnrollment_adm.YubikeyVersions.PivApplet = pivFirmware.ToString();

                    _dataStore.Add(newEnrollment_adm);
                }

                _enrollWorker.ReportProgress(14);

                // 15 - Save store
                _dataStore.Save(MainForm.FileStore);

                _enrollWorker.ReportProgress(15);

                // Report
                doWorkEventArgs.Cancel = false;
                _enrollWorkerMessage = "Success";
            }
        }

        private void EnrollWorkerOnProgressChanged(object sender, ProgressChangedEventArgs progressChangedEventArgs)
        {
            prgEnroll.Value = progressChangedEventArgs.ProgressPercentage;
        }

        private void RefreshInsertedKeyInfo()
        {
            string devName = YubikeyPivManager.Instance.ListDevices().FirstOrDefault();
            bool hasDevice = !string.IsNullOrEmpty(devName);

            foreach (Control control in gbInsertedYubikey.Controls)
            {
                if (control.Name.StartsWith("lbl"))
                    control.Visible = hasDevice;
            }

            if (!hasDevice)
                return;

            using (YubikeyPivDevice dev = YubikeyPivManager.Instance.OpenDevice(devName))
            {
                X509Certificate2 cert = null;   //Standard Cert
                X509Certificate2 cert2 = null;  //Admin Cert

                cert = dev.GetCertificate9a();
                cert2 = dev.GetCertificate9d();

                if ((cert != null || cert2 != null) && _hasBeenEnrolled == true)
                {
                    lblAlreadyEnrolled.Text = "Enrolled!";
                    lblAlreadyEnrolled.ForeColor = Color.Green;
                }
                else if ((cert != null || cert2 != null) && _hasBeenEnrolled == false)
                {
                    lblAlreadyEnrolled.Text = "YubiKey is not empty!";
                    lblAlreadyEnrolled.ForeColor = Color.Red;
                }
                else if ((cert == null || cert2 == null) && _hasBeenEnrolled == true)
                {
                    lblAlreadyEnrolled.Text = "YubiKey is empty! Please revoke Certificate!";
                    lblAlreadyEnrolled.ForeColor = Color.Red;
                }
                else if ((cert == null || cert2 == null) && _hasBeenEnrolled == false)
                {
                    lblAlreadyEnrolled.Text = "YubiKey can be enrolled!";
                    lblAlreadyEnrolled.ForeColor = Color.DarkOrange;
                }
            }

            using (YubikeyPivDevice dev = YubikeyPivManager.Instance.OpenDevice(devName))
            {
                string serial = dev.GetSerialNumber().ToString();
                                
                var yi = new YubikeyInfo();
                bool success =  yi.GetYubikeyInfo(serial);
                /* Get currently only CCID enabled Yubikeys 
                if (HasCcid)
                    lblInsertedMode.ForeColor = Color.Black;
                else
                    lblInsertedMode.ForeColor = Color.Red;
                */
                lblInsertedTyp.Text = yi.devicetype;
                lblInsertedSerial.Text = yi.serial;
                lblInsertedMode.Text = yi.usbinterface;
                lblInsertedFirmware.Text = yi.firmware;
            }
        }

        private void RefreshEligibleForEnroll()
        {
            bool eligible = true;

            if (!_devicePresent)
                eligible = false;

            if (!YubikeyPolicyUtility.IsValidPin(txtPin.Text))
                eligible = false;

            if (txtPin.Text != txtPinAgain.Text)
                eligible = false;

            if (string.IsNullOrEmpty(txtStdUser.Text) && string.IsNullOrEmpty(txtAdmUser.Text))
                eligible = false;

            cmdEnroll.Enabled = eligible;
        }

        private void cmdEnroll_Click(object sender, EventArgs e)
        {
            string devName = YubikeyPivManager.Instance.ListDevices().FirstOrDefault();
            bool hasDevice = !string.IsNullOrEmpty(devName);

            if (!hasDevice)
                return;

            using (YubikeyPivDevice piv = YubikeyPivManager.Instance.OpenDevice(devName))
            {
                if (txtStdUser.Text != null && txtAdmUser.Text == null)
                {
                    if (piv.GetCertificate9a() != null)
                    {
                        // Already enrolled
                        DialogResult resp = MetroMessageBox.Show(this, "The inserted Yubikey has already been enrolled. Are you sure you wish to overwrite it?", "Already enrolled", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                        if (resp != DialogResult.Yes)
                            return;
                    }
                }
                else if (txtAdmUser.Text != null && txtStdUser.Text == null)
                {
                    if (piv.GetCertificate9d() != null)
                    {
                        // Already enrolled
                        DialogResult resp = MetroMessageBox.Show(this, "The inserted Yubikey has already been enrolled. Are you sure you wish to overwrite it?", "Already enrolled", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                        if (resp != DialogResult.Yes)
                            return;
                    }
                }
                else
                {
                    if (piv.GetCertificate9d() != null)
                    {
                        // Already enrolled
                        DialogResult resp = MetroMessageBox.Show(this, "The inserted Yubikey has already been enrolled. Are you sure you wish to overwrite Standard and Admin User?", "Already enrolled", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                        if (resp != DialogResult.Yes)
                            return;
                    }
                }
            }

            cmdEnroll.Enabled = false;

            foreach (Control control in groupBox1.Controls)
                control.Enabled = false;

            foreach (Control control in groupBox3.Controls)
                control.Enabled = false;

            drpAlgorithm.Enabled = false;

            _enrollWorker.RunWorkerAsync();
        }

        private bool MakeCsr_std(string pubKeyAsPem, string pin, out string error, out string csr)
        {
            csr = null;

            // TODO: Fix.. use no files at all - this is an ugly hack
            // I wasn't able to create a CSR and sign it using code - so we're using Yubico's code for now
            string tmpPub = Path.GetRandomFileName();
            string tmpCsr = Path.GetRandomFileName();

            try
            {
                using (StreamWriter sw = new StreamWriter(tmpPub))
                {
                    sw.WriteLine("-----BEGIN PUBLIC KEY-----");

                    for (int i = 0; i < pubKeyAsPem.Length; i += 48)
                    {
                        string substr = pubKeyAsPem.Substring(i, Math.Min(48, pubKeyAsPem.Length - i));
                        sw.WriteLine(substr);
                    }

                    sw.WriteLine("-----END PUBLIC KEY-----");
                }

                const string binary = @"Binaries\PivTool\yubico-piv-tool.exe";

                ProcessStartInfo start = new ProcessStartInfo(binary);
                start.Arguments = "-a verify-pin -P " + pin + " -s 9a -a request-certificate -S \"/CN=example/O=test/\" -i " + tmpPub + " -o " + tmpCsr + "";
                start.WorkingDirectory = Path.GetFullPath(".");
                start.CreateNoWindow = true;
                start.UseShellExecute = false;
                start.RedirectStandardError = true;
                start.RedirectStandardOutput = true;

                Process proc = Process.Start(start);
                proc.WaitForExit();

                string stdErr = proc.StandardError.ReadToEnd();
                string stdOut = proc.StandardOutput.ReadToEnd();

                if (File.Exists(tmpCsr))
                    csr = File.ReadAllText(tmpCsr);

                error = "Output: " + stdOut + Environment.NewLine + "Error: " + stdErr;

                return proc.ExitCode == 0;
            }
            finally
            {
                if (File.Exists(tmpPub))
                    File.Delete(tmpPub);

                if (File.Exists(tmpCsr))
                    File.Delete(tmpCsr);
            }
        }

        private bool MakeCsr_adm(string pubKeyAsPem, string pin, out string error, out string csr)
        {
            csr = null;

            // TODO: Fix.. use no files at all - this is an ugly hack
            // I wasn't able to create a CSR and sign it using code - so we're using Yubico's code for now
            string tmpPub = Path.GetRandomFileName();
            string tmpCsr = Path.GetRandomFileName();

            try
            {
                using (StreamWriter sw = new StreamWriter(tmpPub))
                {
                    sw.WriteLine("-----BEGIN PUBLIC KEY-----");

                    for (int i = 0; i < pubKeyAsPem.Length; i += 48)
                    {
                        string substr = pubKeyAsPem.Substring(i, Math.Min(48, pubKeyAsPem.Length - i));
                        sw.WriteLine(substr);
                    }

                    sw.WriteLine("-----END PUBLIC KEY-----");
                }

                const string binary = @"Binaries\PivTool\yubico-piv-tool.exe";

                ProcessStartInfo start = new ProcessStartInfo(binary);
                start.Arguments = "-a verify-pin -P " + pin + " -s 9d -a request-certificate -S \"/CN=example/O=test/\" -i " + tmpPub + " -o " + tmpCsr + "";
                start.WorkingDirectory = Path.GetFullPath(".");
                start.CreateNoWindow = true;
                start.UseShellExecute = false;
                start.RedirectStandardError = true;
                start.RedirectStandardOutput = true;

                Process proc = Process.Start(start);
                proc.WaitForExit();

                string stdErr = proc.StandardError.ReadToEnd();
                string stdOut = proc.StandardOutput.ReadToEnd();

                if (File.Exists(tmpCsr))
                    csr = File.ReadAllText(tmpCsr);

                error = "Output: " + stdOut + Environment.NewLine + "Error: " + stdErr;

                return proc.ExitCode == 0;
            }
            finally
            {
                if (File.Exists(tmpPub))
                    File.Delete(tmpPub);

                if (File.Exists(tmpCsr))
                    File.Delete(tmpCsr);
            }
        }

        private void llBrowseStdUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DirectoryObjectPickerDialog picker = new DirectoryObjectPickerDialog()
            {
                AllowedObjectTypes = ObjectTypes.Users,
                DefaultObjectTypes = ObjectTypes.Users,
                AllowedLocations = Locations.All,
                DefaultLocations = Locations.JoinedDomain,
                MultiSelect = false,
                ShowAdvancedView = true,
                AttributesToFetch = { "samAccountName" }
            };

            if (picker.ShowDialog() == DialogResult.OK)
            {
                DirectoryObject sel = picker.SelectedObjects.FirstOrDefault();
                string userName = sel?.FetchedAttributes.FirstOrDefault() as string;

                if (sel != null)
                {
                    if (txtAdmUser.Text != userName)
                    {
                        txtStdUser.Text = userName;
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Username already in use", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void llBrowseAdmUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DirectoryObjectPickerDialog picker = new DirectoryObjectPickerDialog()
            {
                AllowedObjectTypes = ObjectTypes.Users,
                DefaultObjectTypes = ObjectTypes.Users,
                AllowedLocations = Locations.All,
                DefaultLocations = Locations.JoinedDomain,
                MultiSelect = false,
                ShowAdvancedView = true,
                AttributesToFetch = { "samAccountName" }
            };

            if (picker.ShowDialog() == DialogResult.OK)
            {
                DirectoryObject sel = picker.SelectedObjects.FirstOrDefault();
                string userName = sel?.FetchedAttributes.FirstOrDefault() as string;

                if (sel != null)
                {
                    if (txtStdUser.Text != userName)
                    {
                        txtAdmUser.Text = userName;
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Username already in use", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void textBoxes_TextChanged(object sender, EventArgs e)
        {
            RefreshEligibleForEnroll();
        }

        private void txtPin_Validating(object sender, CancelEventArgs e)
        {
            if (!YubikeyPolicyUtility.IsValidPin(txtPin.Text))
            {
                txtPin.BackColor = Color.LightCoral;
                e.Cancel = true;
            }
            else
            {
                txtPin.BackColor = Color.White;
                e.Cancel = false;
            }
        }

        private void txtPinAgain_Validating(object sender, CancelEventArgs e)
        {
            if (txtPin.Text != txtPinAgain.Text)
            {
                txtPinAgain.BackColor = Color.LightCoral;
                e.Cancel = true;
            }
            else
            {
                txtPinAgain.BackColor = Color.White;
                e.Cancel = false;
            }
        }
    }
}
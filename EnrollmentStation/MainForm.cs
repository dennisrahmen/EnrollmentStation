using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using EnrollmentStation.Code;
using EnrollmentStation.Code.DataObjects;
using EnrollmentStation.Code.Utilities;
using YubicoLib.YubikeyPiv;
using YubicoLib.YubikeyManager;
using System.Drawing;
using MetroFramework.Forms;
using MetroFramework;

namespace EnrollmentStation
{
    public partial class MainForm : MetroForm
    {
        private DataStore _dataStore;
        private Settings _settings;
        private bool _hasBeenEnrolled;

        public const string FileStore = "store.json";
        public const string FileSettings = "settings.json";
        
        private bool _hsmPresent;

        private readonly Timer _hsmUpdateTimer = new Timer();

        public MainForm()
        {
            CheckForIllegalCrossThreadCalls = false; //TODO: remove
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
            RefreshUserStore();
            RefreshSettings();

            RefreshSelectedKeyInfo();

            RefreshInsertedKey();

            _hsmUpdateTimer.Interval = 1000;
            _hsmUpdateTimer.Tick += HsmUpdateTimerOnTick;
            _hsmUpdateTimer.Start();

            lblStatusStripVersion.Text = "Version: " + Assembly.GetExecutingAssembly().GetName().Version;

            // Start worker that checks for inserted yubikeys
            YubikeyDetector.Instance.StateChanged += YubikeyStateChange;
            YubikeyDetector.Instance.Start();

            // Determine if we need to get the settings set
                       
            if (!File.Exists(FileSettings) || _settings.DefaultAlgorithm == 0)
            {
                DlgSettings dialog = new DlgSettings(_settings);
                DialogResult res = dialog.ShowDialog();

                if (res != DialogResult.OK)
                {
                    MetroMessageBox.Show(this, "You have to set the settings. Restart the application to set the settings.", "Settings not set", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            
            RefreshHsm();
        }

        private void HsmUpdateTimerOnTick(object sender, EventArgs e)
        {
            RefreshHsm();
        }

        private void YubikeyStateChange()
        {

            // Piv Manager find only CCID enabled  Yubikeys
            List<string> listDevices = YubikeyPivManager.Instance.ListDevices().ToList();
            string devName = listDevices.FirstOrDefault();
            bool hasDevice = !string.IsNullOrEmpty(devName);

            YubmanUtil yu = new YubmanUtil();
            btnEnableCCID.Enabled = false;
            btnExportCert.Enabled = false;
            btnViewCert.Enabled = false;
            btnResetYubiKey.Enabled = false;



            if (hasDevice)
            {
                using (YubikeyPivDevice dev = YubikeyPivManager.Instance.OpenDevice(devName))
                {
                    int serialNumber = (int)dev.GetSerialNumber();  // uint         
                    bool success = yu.GetYubikeyMode(serialNumber.ToString(), out bool HasOtp, out bool HasCcid, out bool HasFido, out string mode);
                    bool have2enableCcid = !HasCcid;
                    btnEnableCCID.Enabled = HasCcid;
                    btnExportCert.Enabled = !have2enableCcid;
                    btnViewCert.Enabled = !have2enableCcid;
                    btnResetYubiKey.Enabled =!have2enableCcid;
                }
                
            }

            RefreshInsertedKey();
        }

        private void RefreshSelectedKeyInfo()
        {
            foreach (Control control in gbSelectedKey.Controls)
            {
                if (control.Name.StartsWith("lbl"))
                    control.Visible = lstItems.SelectedItems.Count == 1;
            }

            foreach (Control control in gbSelectedKeyCertificate.Controls)
            {
                if (control.Name.StartsWith("lbl"))
                    control.Visible = lstItems.SelectedItems.Count == 1;
            }

            if (lstItems.SelectedItems.Count <= 0)
            {
                return;
            }

            EnrolledYubikey item = lstItems.SelectedItems[0].Tag as EnrolledYubikey;

            if (item == null)
                return;

            lblYubikeySerial.Text = item.DeviceSerial.ToString();
            lblYubikeyFirmware.Text = item.YubikeyVersions.NeoFirmware;
            lblYubikeyPivVersion.Text = item.YubikeyVersions.PivApplet;

            lblCertCA.Text = item.CA;
            lblCertEnrolledOn.Text = item.EnrolledAt.ToString();
            lblCertSerial.Text = item.Certificate.Serial;
            lblCertThumbprint.Text = item.Certificate.Thumbprint;
            lblCertUser.Text = item.Username;
        }

        private void RefreshHsm()
        {
            _hsmPresent = HsmRng.IsHsmPresent();
            btnViewCert.InvokeIfNeeded(() => lblHSMPresent.Text = "HSM present: " + (_hsmPresent ? "Yes" : "No"));
        }

        private void RefreshInsertedKey()
        {                               
            List<string> listDevices = YubikeyPivManager.Instance.ListDevices().ToList();
            string devName = listDevices.FirstOrDefault();
            bool hasDevice = !string.IsNullOrEmpty(devName);

            foreach (Control control in gbInsertedKey.Controls)
            {
                if (control.Name.StartsWith("lbl"))
                    control.Visible = (hasDevice);
            }

            if (hasDevice)
            { 
                using (YubikeyPivDevice dev = YubikeyPivManager.Instance.OpenDevice(devName))
                {
                    int serialNumber = (int) dev.GetSerialNumber();  // uint                    
                    var yi = new YubikeyInfo();
                    yi.GetYubikeyInfo(serialNumber.ToString());
                    lblDevType.Text = yi.devicetype;
                    lblInsertedSerial.Text = yi.serial;
                    lblInsertedFirmware.Text = yi.firmware;
                    lblInsertedMode.Text = yi.usbinterface;

                    X509Certificate2 cert = null;   //Standard Cert
                    X509Certificate2 cert2 = null;  //Admin Cert

                    

                    _hasBeenEnrolled = _dataStore.Search((int)dev.GetSerialNumber()).Any();


                    cert = dev.GetCertificate9a();
                    cert2 = dev.GetCertificate9d();

                    if((cert != null || cert2 != null) && _hasBeenEnrolled == true)
                    {
                        lblInsertedHasBeenEnrolled.Text = "Enrolled!";
                        lblInsertedHasBeenEnrolled.ForeColor = Color.Green;
                    }
                    else if((cert != null || cert2 != null) && _hasBeenEnrolled == false)
                    {
                        lblInsertedHasBeenEnrolled.Text = "YubiKey is not empty!";
                        lblInsertedHasBeenEnrolled.ForeColor = Color.Red;
                    }
                    else if ((cert == null || cert2 == null) && _hasBeenEnrolled == true)
                    {
                        lblInsertedHasBeenEnrolled.Text = "YubiKey is empty! Please revoke Certificate!";
                        lblInsertedHasBeenEnrolled.ForeColor = Color.Red;
                    }
                    else if ((cert == null || cert2 == null) && _hasBeenEnrolled == false)
                    {
                        lblInsertedHasBeenEnrolled.Text = "YubiKey can be enrolled!";
                        lblInsertedHasBeenEnrolled.ForeColor = Color.DarkOrange;
                    }
                }
            }

            if (listDevices.Count > 1)
            {
                lblMultipleKeys.Text = $"{listDevices.Count:N0} keys inserted";
                btnResetYubiKey.Enabled = false;
                btnViewCert.Enabled = false;
                btnEnableCCID.Enabled = false;
                btnExportCert.Enabled = false;
                tsbEnroll.Enabled = false;
                tsbAbout.Enabled = false;
                tsbSettings.Enabled = false;
            }
            else
            {
                lblMultipleKeys.Text = "";
            }
        }

        private void RefreshUserStore()
        {
            _dataStore = DataStore.Load(FileStore);

            lstItems.Items.Clear();

            foreach (EnrolledYubikey yubikey in _dataStore.Yubikeys)
            {
                ListViewItem lsItem = new ListViewItem();

                lsItem.Tag = yubikey;

                // Fields
                // Serial
                lsItem.Text = yubikey.DeviceSerial.ToString();

                // User
                lsItem.SubItems.Add(yubikey.Username);

                // Slot
                lsItem.SubItems.Add(yubikey.Slot);

                // Enrolled
                lsItem.SubItems.Add(yubikey.EnrolledAt.ToLocalTime().ToString());

                // Certificate Serial
                lsItem.SubItems.Add(yubikey.Certificate != null ? yubikey.Certificate.Serial : "<unknown>");

                

                lstItems.Items.Add(lsItem);
            }

            RefreshSelectedKeyInfo();
        }

        private void RefreshSettings()
        {
            _settings = Settings.Load(FileSettings);
        }


        private void btnViewCert_Click(object sender, EventArgs e)  //Angepasst, sodass beide Zertifikate angezeigt werden können
        {
            X509Certificate2 cert = null;   //Standard Cert
            X509Certificate2 cert2 = null;  //Admin Cert

            string devName = YubikeyPivManager.Instance.ListDevices().FirstOrDefault();

            if (!string.IsNullOrEmpty(devName))
            {
                using (YubikeyPivDevice dev = YubikeyPivManager.Instance.OpenDevice(devName))
                {
                    cert = dev.GetCertificate9a();
                    cert2 = dev.GetCertificate9d();
                    
                }
            }

            if (cert == null)
            {
                MetroMessageBox.Show(this, "No Standard User certificate on device.", "No Certificate", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                X509Certificate2UI.DisplayCertificate(cert);
            }
            if (cert2 == null)
            {
                MetroMessageBox.Show(this, "No Admin User certificate on device.", "No Certificate", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                X509Certificate2UI.DisplayCertificate(cert2);
            }
        }

        private void btnExportCert_Click(object sender, EventArgs e)         //Änderungen vorgenommen, dass beide Zertifikate, wenn vorhanden exportiert werden können    
        {
            X509Certificate2 cert = null;   //Standard Cert
            X509Certificate2 cert2 = null;  //Admin Cert
            int deviceSerial = 0;

            string devName = YubikeyPivManager.Instance.ListDevices().FirstOrDefault();

            if (!string.IsNullOrEmpty(devName))
            {
                using (YubikeyPivDevice dev = YubikeyPivManager.Instance.OpenDevice(devName))
                {
                    deviceSerial = (int) dev.GetSerialNumber();
                }

                using (YubikeyPivDevice dev = YubikeyPivManager.Instance.OpenDevice(devName))
                {
                    cert = dev.GetCertificate9a();
                    cert2 = dev.GetCertificate9d();
                }
            }

            if (cert == null && cert2 == null)
            {
                MetroMessageBox.Show(this, "No certificate on device.", "No Certificate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = deviceSerial + "-" + cert.SerialNumber + ".crt"; //TODO: GetSerialNumber() can possibly fail

            DialogResult dlgResult = saveFileDialog.ShowDialog();

            if (dlgResult != DialogResult.OK)
                return;

            if (cert != null)                                          
            {
                using (Stream fs = saveFileDialog.OpenFile())
                {
                    byte[] data = cert.GetRawCertData();
                    fs.Write(data, 0, data.Length);
                }
            }

            if(cert2 != null)
            {
                using (Stream fs = saveFileDialog.OpenFile())
                {
                    byte[] data = cert2.GetRawCertData();
                    fs.Write(data, 0, data.Length);
                }
            }
        }

        private void tsbEnrollKey_Click(object sender, EventArgs e)
        {
            DlgEnroll enroll = new DlgEnroll(_settings, _dataStore);
            enroll.ShowDialog();

            RefreshUserStore();

            RefreshInsertedKey();
        }

        private void exportCertificateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstItems.SelectedItems.Count <= 0)
                return;

            EnrolledYubikey item = lstItems.SelectedItems[0].Tag as EnrolledYubikey;
            if (item == null)
                return;

            X509Certificate2 cert = new X509Certificate2(item.Certificate.RawCertificate);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = item.DeviceSerial + "-" + cert.SerialNumber + ".crt";

            DialogResult dlgResult = saveFileDialog.ShowDialog();

            if (dlgResult != DialogResult.OK)
                return;

            using (Stream fs = saveFileDialog.OpenFile())
            {
                byte[] data = cert.GetRawCertData();
                fs.Write(data, 0, data.Length);
            }
        }

        private void viewCertificateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstItems.SelectedItems.Count <= 0)
                return;

            EnrolledYubikey item = lstItems.SelectedItems[0].Tag as EnrolledYubikey;
            if (item == null)
                return;

            X509Certificate2 cert = new X509Certificate2(item.Certificate.RawCertificate);
            X509Certificate2UI.DisplayCertificate(cert);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // YubikeyNeoManager.Instance.Dispose();
        }

        private void tsbSettings_Click(object sender, EventArgs e)
        {
            DlgSettings dialog = new DlgSettings(_settings);
            dialog.ShowDialog();
        }

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshSelectedKeyInfo();
        }

        private void resetPINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstItems.SelectedItems.Count <= 0)
                return;

            EnrolledYubikey item = lstItems.SelectedItems[0].Tag as EnrolledYubikey;
            if (item == null)
                return;

            DlgResetPin changePin = new DlgResetPin(item);
            changePin.ShowDialog();
        }

        private void revokeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (lstItems.SelectedItems.Count <= 0)
                return;

            EnrolledYubikey item = lstItems.SelectedItems[0].Tag as EnrolledYubikey;
            if (item == null)
                return;

            DialogResult dlgResult = MetroMessageBox.Show(this, "Revoke the certificate enrolled at " + item.EnrolledAt.ToLocalTime() + " for " + item.Username + ". This action will revoke " +
                   "the certificate, but will NOT wipe the yubikey." + Environment.NewLine + Environment.NewLine +
                   "Certificate: " + item.Certificate.Serial + Environment.NewLine +
                   "Subject: " + item.Certificate.Subject + Environment.NewLine +
                   "Issuer: " + item.Certificate.Issuer + Environment.NewLine +
                   "Valid: " + item.Certificate.StartDate + " to " + item.Certificate.ExpireDate,
                   "Revoke certificate?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            if (dlgResult != DialogResult.Yes)
                return;

            DlgProgress prg = new DlgProgress("Revoking certificate");
            prg.WorkerAction = worker =>
            {
                worker.ReportProgress(20, "Revoking certificate ...");

                // Begin
                try
                {
                    CertificateUtilities.RevokeCertificate(item.CA, item.Certificate.Serial);

                    // Revoked
                    _dataStore.Remove(item);
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this,
                        "Unable to revoke certificate " + item.Certificate.Serial + " of " + item.CA +
                        " enrolled on " + item.EnrolledAt + ". There was an error." + Environment.NewLine +
                        Environment.NewLine + ex.Message, "An error occurred.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                worker.ReportProgress(100, string.Empty);

                // Write to disk
                _dataStore.Save(FileStore);
            };

            prg.ShowDialog();

            RefreshUserStore();

            RefreshInsertedKey();
        }

        private void tsbAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void btnEnableCCID_Click(object sender, EventArgs e)
        {
            DlgChangeMode changeMode = new DlgChangeMode();
            DialogResult resp = changeMode.ShowDialog();
        }

        private void btnResetYubiKey_Click(object sender, EventArgs e)
        {
            string devName = YubikeyPivManager.Instance.ListDevices().FirstOrDefault();
            bool hasDevice = !string.IsNullOrEmpty(devName);

            if (hasDevice && MetroMessageBox.Show(this, "Are you sure you want to reset the YubiKey?", "Reset confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                using (YubikeyPivDevice piv = YubikeyPivManager.Instance.OpenDevice(devName))
                {
                    piv.BlockPin();
                    piv.BlockPuk();

                    bool reset = piv.ResetDevice();
                    if (!reset)
                    {
                        MetroMessageBox.Show(this, "Unable to reset the yubikey. Try resetting it manually.", "An error occurred.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "YubiKey has been successfully resettet.", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshInsertedKey();
                    }
                }
            }
        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            if(tb_search.Text != "")
            {
                // Call FindItemWithText with the contents of the textbox.
                ListViewItem foundItem = lstItems.FindItemWithText(tb_search.Text);
                if (foundItem != null)
                {
                    foundItem.Selected = true;
                    foundItem.EnsureVisible();
                }
                else
                {
                    lstItems.SelectedItems.Clear();
                }
            }
            else
            {
                lstItems.SelectedItems.Clear();
            }
        }

        private void tsbEnroll_MouseHover(object sender, EventArgs e)
        {
            tsbEnroll.Image = EnrollmentStation.Properties.Resources.s_add_24px; 
        }

        private void tsbSettings_MouseHover(object sender, EventArgs e)
        {
            tsbSettings.Image = EnrollmentStation.Properties.Resources.s_settings_24px;
        }

        private void tsbAbout_MouseHover(object sender, EventArgs e)
        {
            tsbAbout.Image = EnrollmentStation.Properties.Resources.s_star_24px;
        }

        private void tsbEnroll_MouseLeave(object sender, EventArgs e)
        {
            tsbEnroll.Image = EnrollmentStation.Properties.Resources.add_24px;
        }

        private void tsbSettings_MouseLeave(object sender, EventArgs e)
        {
            tsbSettings.Image = EnrollmentStation.Properties.Resources.settings_24px;
        }

        private void tsbAbout_MouseLeave(object sender, EventArgs e)
        {
            tsbAbout.Image = EnrollmentStation.Properties.Resources.star_24px;
        }
    }
}
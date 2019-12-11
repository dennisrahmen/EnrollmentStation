using System;
using System.Drawing;
using System.Windows.Forms;
using EnrollmentStation.Code;
using EnrollmentStation.Code.Utilities;
using YubicoLib.YubikeyPiv;
using YubicoLib.YubikeyManager;
using System.Collections.Generic;
using System.Linq;


namespace EnrollmentStation
{
    public partial class DlgChangeMode : Form
    {
        private bool _stateWaitingToRemove;
        private bool _deferCheckboxEvents;
        YubikeyInfo yi = new YubikeyInfo();
        bool _currentModeHasOTP = false;
        bool _currentModeHasCCID= false;
        bool _currentModeHasFIDO= false;
        string _currentMode= null;


        public DlgChangeMode()
        {
            InitializeComponent();
            SetStatus(Color.Yellow, "Insert a Yubikey");
        }

        private void SetStatus(Color color, string text)
        {
            lblStatus.Text = text;
            lblStatus.BackColor = color;
        }

        private void DlgChangeMode_Load(object sender, EventArgs e)
        {
            AcceptButton = cmdChange;

            YubikeyDetector.Instance.StateChanged += InstanceOnStateChanged;
            YubikeyDetector.Instance.Start();

            UpdateCurrentView();
        }

        private void DlgChangeMode_FormClosing(object sender, FormClosingEventArgs e)
        {
            YubikeyDetector.Instance.StateChanged -= InstanceOnStateChanged;
        }

        private void InstanceOnStateChanged()
        {
            if (_stateWaitingToRemove && !YubikeyDetector.Instance.CurrentState)
            {
                // The current key has been removed - reset the state
                _stateWaitingToRemove = false;
            }

             this.InvokeIfNeeded(UpdateCurrentView);
        }

        private void UpdateCurrentView()
        {
            if (_stateWaitingToRemove)
                // Don't update the UI - wait for the user to remove the current Yubikey
                return;

           // using (YubikeyDetector.Instance.GetExclusiveLock())
            {
                
                string devName = YubikeyPivManager.Instance.ListDevices().FirstOrDefault();
                bool hasDevice = !string.IsNullOrEmpty(devName);

                foreach (Control control in grpChangeMode.Controls)
                    control.Enabled = hasDevice;

                if (!hasDevice)
                {
                    SetStatus(Color.Yellow, "Insert a Yubikey");
                    return;
                }
                YubmanUtil yu = new YubmanUtil();
                using (YubikeyPivDevice dev = YubikeyPivManager.Instance.OpenDevice(devName))
                {
                    int serialNumber = (int)dev.GetSerialNumber();  // uint         
                    bool success = yu.GetYubikeyMode(serialNumber.ToString(), out  _currentModeHasOTP, out _currentModeHasCCID, out  _currentModeHasFIDO, out  _currentMode);
                                                        
                    _deferCheckboxEvents = true;
                    chkOTP.Checked = _currentModeHasOTP;
                    chkCCID.Checked = _currentModeHasCCID;
                    chkU2f.Checked = _currentModeHasFIDO;               
                    _deferCheckboxEvents = false;
                    SetStatus(Color.GreenYellow, "Currently set to " + _currentMode);
                }
            }
        }

        private void checkBox_Changed(object sender, EventArgs e)
        {
            if (_deferCheckboxEvents)
                return;
            // CCID is always on
            _currentModeHasOTP = chkOTP.Checked;
            _currentModeHasCCID = true;
            _currentModeHasFIDO = chkU2f.Checked;
          
            cmdChange.Enabled = true;  //
        }

        private void cmdChange_Click(object sender, EventArgs e)
        {
            SetStatus(Color.Orange, "DO NOT REMOVE THE YUBIKEY");

            string devName = YubikeyPivManager.Instance.ListDevices().FirstOrDefault();
            bool hasDevice = !string.IsNullOrEmpty(devName);
                
            if (!hasDevice)
            {
                SetStatus(Color.Yellow, "Insert a Yubikey");
                return;
            }

            YubmanUtil yu = new YubmanUtil();
            using (YubikeyPivDevice dev = YubikeyPivManager.Instance.OpenDevice(devName))
            {
                try
                {
                    string serialNumber = dev.GetSerialNumber().ToString();  // uint 
                    bool success = yu.SetYubikeyMode(serialNumber, _currentModeHasOTP, _currentModeHasCCID, _currentModeHasFIDO);
                    if (success)
                    {
                        SetStatus(Color.GreenYellow, "The mode was set. Please remove the Yubikey from the system.");
                    }
                    else
                    {
                        SetStatus(Color.Red, "Was unable to set the mode, please remove the Yubikey.");
                    }
                    
                }
                catch (Exception ex)
                {
                    SetStatus(Color.Red, "Was unable to set the mode, please remove the Yubikey. Details: " + ex.Message);
                }

                _stateWaitingToRemove = true;
                foreach (Control control in grpChangeMode.Controls)
                    control.Enabled = false;
            }
        }
    }
}

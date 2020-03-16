using System.ComponentModel;
using System.Windows.Forms;

namespace EnrollmentStation
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.contextMenuStrip1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.revocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.revokeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCertificateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportCertificateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePINToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbInsertedKey = new System.Windows.Forms.GroupBox();
            this.btnViewCert = new MetroFramework.Controls.MetroButton();
            this.btnExportCert = new MetroFramework.Controls.MetroButton();
            this.btnEnableCCID = new MetroFramework.Controls.MetroButton();
            this.btnResetYubiKey = new MetroFramework.Controls.MetroButton();
            this.lblDevType = new MetroFramework.Controls.MetroLabel();
            this.label3 = new MetroFramework.Controls.MetroLabel();
            this.lblMultipleKeys = new MetroFramework.Controls.MetroLabel();
            this.lblInsertedHasBeenEnrolled = new MetroFramework.Controls.MetroLabel();
            this.label1 = new MetroFramework.Controls.MetroLabel();
            this.lblInsertedFirmware = new MetroFramework.Controls.MetroLabel();
            this.label8 = new MetroFramework.Controls.MetroLabel();
            this.lblInsertedMode = new MetroFramework.Controls.MetroLabel();
            this.label14 = new MetroFramework.Controls.MetroLabel();
            this.dlblInsertedSerial = new MetroFramework.Controls.MetroLabel();
            this.lblInsertedSerial = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbSelectedKey = new System.Windows.Forms.GroupBox();
            this.lblYubikeyFirmware = new MetroFramework.Controls.MetroLabel();
            this.label17 = new MetroFramework.Controls.MetroLabel();
            this.label4 = new MetroFramework.Controls.MetroLabel();
            this.lblYubikeyPivVersion = new MetroFramework.Controls.MetroLabel();
            this.label2 = new MetroFramework.Controls.MetroLabel();
            this.lblYubikeySerial = new MetroFramework.Controls.MetroLabel();
            this.gbSelectedKeyCertificate = new System.Windows.Forms.GroupBox();
            this.lblCertThumbprint = new MetroFramework.Controls.MetroLabel();
            this.label11 = new MetroFramework.Controls.MetroLabel();
            this.lblCertCA = new MetroFramework.Controls.MetroLabel();
            this.label13 = new MetroFramework.Controls.MetroLabel();
            this.lblCertUser = new MetroFramework.Controls.MetroLabel();
            this.label7 = new MetroFramework.Controls.MetroLabel();
            this.lblCertEnrolledOn = new MetroFramework.Controls.MetroLabel();
            this.label5 = new MetroFramework.Controls.MetroLabel();
            this.lblCertSerial = new MetroFramework.Controls.MetroLabel();
            this.label6 = new MetroFramework.Controls.MetroLabel();
            this.tb_search = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.lblHSMPresent = new MetroFramework.Controls.MetroLabel();
            this.lblStatusStripVersion = new MetroFramework.Controls.MetroLabel();
            this.tsbAbout = new System.Windows.Forms.PictureBox();
            this.tsbSettings = new System.Windows.Forms.PictureBox();
            this.tsbEnroll = new System.Windows.Forms.PictureBox();
            this.lstItems = new System.Windows.Forms.ListView();
            this.clmSerial = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmSlot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmEnrolledAt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCertificateSerial = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1.SuspendLayout();
            this.gbInsertedKey.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbSelectedKey.SuspendLayout();
            this.gbSelectedKeyCertificate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tsbAbout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsbSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsbEnroll)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.revocationToolStripMenuItem,
            this.viewCertificateToolStripMenuItem,
            this.exportCertificateToolStripMenuItem,
            this.changePINToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(166, 92);
            // 
            // revocationToolStripMenuItem
            // 
            this.revocationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.revokeToolStripMenuItem});
            this.revocationToolStripMenuItem.Name = "revocationToolStripMenuItem";
            this.revocationToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.revocationToolStripMenuItem.Text = "&Revocation";
            // 
            // revokeToolStripMenuItem
            // 
            this.revokeToolStripMenuItem.Name = "revokeToolStripMenuItem";
            this.revokeToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.revokeToolStripMenuItem.Text = "Revoke";
            this.revokeToolStripMenuItem.Click += new System.EventHandler(this.revokeToolStripMenuItem_Click_1);
            // 
            // viewCertificateToolStripMenuItem
            // 
            this.viewCertificateToolStripMenuItem.Name = "viewCertificateToolStripMenuItem";
            this.viewCertificateToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.viewCertificateToolStripMenuItem.Text = "View Certificate";
            this.viewCertificateToolStripMenuItem.Click += new System.EventHandler(this.viewCertificateToolStripMenuItem_Click);
            // 
            // exportCertificateToolStripMenuItem
            // 
            this.exportCertificateToolStripMenuItem.Name = "exportCertificateToolStripMenuItem";
            this.exportCertificateToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.exportCertificateToolStripMenuItem.Text = "Export Certificate";
            this.exportCertificateToolStripMenuItem.Click += new System.EventHandler(this.exportCertificateToolStripMenuItem_Click);
            // 
            // changePINToolStripMenuItem
            // 
            this.changePINToolStripMenuItem.Name = "changePINToolStripMenuItem";
            this.changePINToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.changePINToolStripMenuItem.Text = "Reset PIN";
            this.changePINToolStripMenuItem.Click += new System.EventHandler(this.resetPINToolStripMenuItem_Click);
            // 
            // gbInsertedKey
            // 
            this.gbInsertedKey.Controls.Add(this.btnViewCert);
            this.gbInsertedKey.Controls.Add(this.btnExportCert);
            this.gbInsertedKey.Controls.Add(this.btnEnableCCID);
            this.gbInsertedKey.Controls.Add(this.btnResetYubiKey);
            this.gbInsertedKey.Controls.Add(this.lblDevType);
            this.gbInsertedKey.Controls.Add(this.label3);
            this.gbInsertedKey.Controls.Add(this.lblMultipleKeys);
            this.gbInsertedKey.Controls.Add(this.lblInsertedHasBeenEnrolled);
            this.gbInsertedKey.Controls.Add(this.label1);
            this.gbInsertedKey.Controls.Add(this.lblInsertedFirmware);
            this.gbInsertedKey.Controls.Add(this.label8);
            this.gbInsertedKey.Controls.Add(this.lblInsertedMode);
            this.gbInsertedKey.Controls.Add(this.label14);
            this.gbInsertedKey.Controls.Add(this.dlblInsertedSerial);
            this.gbInsertedKey.Controls.Add(this.lblInsertedSerial);
            this.gbInsertedKey.Controls.Add(this.pictureBox1);
            this.gbInsertedKey.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gbInsertedKey.Location = new System.Drawing.Point(4, 359);
            this.gbInsertedKey.Name = "gbInsertedKey";
            this.gbInsertedKey.Size = new System.Drawing.Size(463, 191);
            this.gbInsertedKey.TabIndex = 3;
            this.gbInsertedKey.TabStop = false;
            this.gbInsertedKey.Text = "Inserted Yubikey";
            // 
            // btnViewCert
            // 
            this.btnViewCert.Enabled = false;
            this.btnViewCert.Location = new System.Drawing.Point(10, 151);
            this.btnViewCert.Name = "btnViewCert";
            this.btnViewCert.Size = new System.Drawing.Size(97, 25);
            this.btnViewCert.TabIndex = 20;
            this.btnViewCert.Text = "View Certificate";
            this.btnViewCert.UseSelectable = true;
            this.btnViewCert.Click += new System.EventHandler(this.btnViewCert_Click);
            // 
            // btnExportCert
            // 
            this.btnExportCert.Enabled = false;
            this.btnExportCert.Location = new System.Drawing.Point(125, 151);
            this.btnExportCert.Name = "btnExportCert";
            this.btnExportCert.Size = new System.Drawing.Size(97, 25);
            this.btnExportCert.TabIndex = 19;
            this.btnExportCert.Text = "Export Certificate";
            this.btnExportCert.UseSelectable = true;
            this.btnExportCert.Click += new System.EventHandler(this.btnExportCert_Click);
            // 
            // btnEnableCCID
            // 
            this.btnEnableCCID.Enabled = false;
            this.btnEnableCCID.Location = new System.Drawing.Point(239, 151);
            this.btnEnableCCID.Name = "btnEnableCCID";
            this.btnEnableCCID.Size = new System.Drawing.Size(97, 25);
            this.btnEnableCCID.TabIndex = 18;
            this.btnEnableCCID.Text = "Change Mode";
            this.btnEnableCCID.UseSelectable = true;
            this.btnEnableCCID.Click += new System.EventHandler(this.btnEnableCCID_Click);
            // 
            // btnResetYubiKey
            // 
            this.btnResetYubiKey.Enabled = false;
            this.btnResetYubiKey.Location = new System.Drawing.Point(358, 151);
            this.btnResetYubiKey.Name = "btnResetYubiKey";
            this.btnResetYubiKey.Size = new System.Drawing.Size(97, 25);
            this.btnResetYubiKey.TabIndex = 17;
            this.btnResetYubiKey.Text = "Reset YubiKey";
            this.btnResetYubiKey.UseSelectable = true;
            this.btnResetYubiKey.Click += new System.EventHandler(this.btnResetYubiKey_Click);
            // 
            // lblDevType
            // 
            this.lblDevType.AutoSize = true;
            this.lblDevType.Location = new System.Drawing.Point(114, 21);
            this.lblDevType.Name = "lblDevType";
            this.lblDevType.Size = new System.Drawing.Size(65, 19);
            this.lblDevType.TabIndex = 13;
            this.lblDevType.Text = "Loading...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "Typ:";
            // 
            // lblMultipleKeys
            // 
            this.lblMultipleKeys.AutoSize = true;
            this.lblMultipleKeys.ForeColor = System.Drawing.Color.Red;
            this.lblMultipleKeys.Location = new System.Drawing.Point(330, 21);
            this.lblMultipleKeys.Name = "lblMultipleKeys";
            this.lblMultipleKeys.Size = new System.Drawing.Size(95, 19);
            this.lblMultipleKeys.TabIndex = 11;
            this.lblMultipleKeys.Text = "lblMultipleKeys";
            this.lblMultipleKeys.UseCustomForeColor = true;
            // 
            // lblInsertedHasBeenEnrolled
            // 
            this.lblInsertedHasBeenEnrolled.AutoSize = true;
            this.lblInsertedHasBeenEnrolled.Location = new System.Drawing.Point(114, 117);
            this.lblInsertedHasBeenEnrolled.Name = "lblInsertedHasBeenEnrolled";
            this.lblInsertedHasBeenEnrolled.Size = new System.Drawing.Size(65, 19);
            this.lblInsertedHasBeenEnrolled.TabIndex = 7;
            this.lblInsertedHasBeenEnrolled.Text = "Loading...";
            this.lblInsertedHasBeenEnrolled.UseCustomForeColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Enrolled:";
            // 
            // lblInsertedFirmware
            // 
            this.lblInsertedFirmware.AutoSize = true;
            this.lblInsertedFirmware.Location = new System.Drawing.Point(114, 93);
            this.lblInsertedFirmware.Name = "lblInsertedFirmware";
            this.lblInsertedFirmware.Size = new System.Drawing.Size(65, 19);
            this.lblInsertedFirmware.TabIndex = 5;
            this.lblInsertedFirmware.Text = "Loading...";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 19);
            this.label8.TabIndex = 4;
            this.label8.Text = "Firmware:";
            // 
            // lblInsertedMode
            // 
            this.lblInsertedMode.AutoSize = true;
            this.lblInsertedMode.Location = new System.Drawing.Point(114, 69);
            this.lblInsertedMode.Name = "lblInsertedMode";
            this.lblInsertedMode.Size = new System.Drawing.Size(65, 19);
            this.lblInsertedMode.TabIndex = 3;
            this.lblInsertedMode.Text = "Loading...";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 69);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 19);
            this.label14.TabIndex = 2;
            this.label14.Text = "Current Mode:";
            // 
            // dlblInsertedSerial
            // 
            this.dlblInsertedSerial.AutoSize = true;
            this.dlblInsertedSerial.Location = new System.Drawing.Point(8, 45);
            this.dlblInsertedSerial.Name = "dlblInsertedSerial";
            this.dlblInsertedSerial.Size = new System.Drawing.Size(98, 19);
            this.dlblInsertedSerial.TabIndex = 0;
            this.dlblInsertedSerial.Text = "Serial Number:";
            // 
            // lblInsertedSerial
            // 
            this.lblInsertedSerial.AutoSize = true;
            this.lblInsertedSerial.Location = new System.Drawing.Point(114, 45);
            this.lblInsertedSerial.Name = "lblInsertedSerial";
            this.lblInsertedSerial.Size = new System.Drawing.Size(65, 19);
            this.lblInsertedSerial.TabIndex = 1;
            this.lblInsertedSerial.Text = "Loading...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.Location = new System.Drawing.Point(356, 149);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(101, 29);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // gbSelectedKey
            // 
            this.gbSelectedKey.Controls.Add(this.lblYubikeyFirmware);
            this.gbSelectedKey.Controls.Add(this.label17);
            this.gbSelectedKey.Controls.Add(this.label4);
            this.gbSelectedKey.Controls.Add(this.lblYubikeyPivVersion);
            this.gbSelectedKey.Controls.Add(this.label2);
            this.gbSelectedKey.Controls.Add(this.lblYubikeySerial);
            this.gbSelectedKey.Location = new System.Drawing.Point(4, 111);
            this.gbSelectedKey.Name = "gbSelectedKey";
            this.gbSelectedKey.Size = new System.Drawing.Size(463, 95);
            this.gbSelectedKey.TabIndex = 1;
            this.gbSelectedKey.TabStop = false;
            this.gbSelectedKey.Text = "YubiKey";
            // 
            // lblYubikeyFirmware
            // 
            this.lblYubikeyFirmware.AutoSize = true;
            this.lblYubikeyFirmware.Location = new System.Drawing.Point(114, 70);
            this.lblYubikeyFirmware.Name = "lblYubikeyFirmware";
            this.lblYubikeyFirmware.Size = new System.Drawing.Size(122, 19);
            this.lblYubikeyFirmware.TabIndex = 5;
            this.lblYubikeyFirmware.Text = "lblYubikeyFirmware";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 70);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 19);
            this.label17.TabIndex = 4;
            this.label17.Text = "Firmware:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "PIV Version:";
            // 
            // lblYubikeyPivVersion
            // 
            this.lblYubikeyPivVersion.AutoSize = true;
            this.lblYubikeyPivVersion.Location = new System.Drawing.Point(114, 45);
            this.lblYubikeyPivVersion.Name = "lblYubikeyPivVersion";
            this.lblYubikeyPivVersion.Size = new System.Drawing.Size(126, 19);
            this.lblYubikeyPivVersion.TabIndex = 3;
            this.lblYubikeyPivVersion.Text = "lblYubikeyPivVersion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Serial Number:";
            // 
            // lblYubikeySerial
            // 
            this.lblYubikeySerial.AutoSize = true;
            this.lblYubikeySerial.Location = new System.Drawing.Point(114, 20);
            this.lblYubikeySerial.Name = "lblYubikeySerial";
            this.lblYubikeySerial.Size = new System.Drawing.Size(99, 19);
            this.lblYubikeySerial.TabIndex = 1;
            this.lblYubikeySerial.Text = "lblYubikeySerial";
            // 
            // gbSelectedKeyCertificate
            // 
            this.gbSelectedKeyCertificate.BackColor = System.Drawing.Color.Transparent;
            this.gbSelectedKeyCertificate.Controls.Add(this.lblCertThumbprint);
            this.gbSelectedKeyCertificate.Controls.Add(this.label11);
            this.gbSelectedKeyCertificate.Controls.Add(this.lblCertCA);
            this.gbSelectedKeyCertificate.Controls.Add(this.label13);
            this.gbSelectedKeyCertificate.Controls.Add(this.lblCertUser);
            this.gbSelectedKeyCertificate.Controls.Add(this.label7);
            this.gbSelectedKeyCertificate.Controls.Add(this.lblCertEnrolledOn);
            this.gbSelectedKeyCertificate.Controls.Add(this.label5);
            this.gbSelectedKeyCertificate.Controls.Add(this.lblCertSerial);
            this.gbSelectedKeyCertificate.Controls.Add(this.label6);
            this.gbSelectedKeyCertificate.Location = new System.Drawing.Point(4, 211);
            this.gbSelectedKeyCertificate.Name = "gbSelectedKeyCertificate";
            this.gbSelectedKeyCertificate.Size = new System.Drawing.Size(463, 145);
            this.gbSelectedKeyCertificate.TabIndex = 2;
            this.gbSelectedKeyCertificate.TabStop = false;
            this.gbSelectedKeyCertificate.Text = "Certificate";
            // 
            // lblCertThumbprint
            // 
            this.lblCertThumbprint.AutoSize = true;
            this.lblCertThumbprint.Location = new System.Drawing.Point(114, 120);
            this.lblCertThumbprint.Name = "lblCertThumbprint";
            this.lblCertThumbprint.Size = new System.Drawing.Size(117, 19);
            this.lblCertThumbprint.TabIndex = 9;
            this.lblCertThumbprint.Text = "lblCertThumbprint";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 120);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 19);
            this.label11.TabIndex = 8;
            this.label11.Text = "Thumbprint:";
            // 
            // lblCertCA
            // 
            this.lblCertCA.AutoSize = true;
            this.lblCertCA.Location = new System.Drawing.Point(114, 95);
            this.lblCertCA.Name = "lblCertCA";
            this.lblCertCA.Size = new System.Drawing.Size(67, 19);
            this.lblCertCA.TabIndex = 7;
            this.lblCertCA.Text = "lblCertCA";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 95);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 19);
            this.label13.TabIndex = 6;
            this.label13.Text = "CA:";
            // 
            // lblCertUser
            // 
            this.lblCertUser.AutoSize = true;
            this.lblCertUser.Location = new System.Drawing.Point(114, 20);
            this.lblCertUser.Name = "lblCertUser";
            this.lblCertUser.Size = new System.Drawing.Size(75, 19);
            this.lblCertUser.TabIndex = 1;
            this.lblCertUser.Text = "lblCertUser";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 19);
            this.label7.TabIndex = 0;
            this.label7.Text = "User:";
            // 
            // lblCertEnrolledOn
            // 
            this.lblCertEnrolledOn.AutoSize = true;
            this.lblCertEnrolledOn.Location = new System.Drawing.Point(114, 70);
            this.lblCertEnrolledOn.Name = "lblCertEnrolledOn";
            this.lblCertEnrolledOn.Size = new System.Drawing.Size(115, 19);
            this.lblCertEnrolledOn.TabIndex = 5;
            this.lblCertEnrolledOn.Text = "lblCertEnrolledOn";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Enrolled on:";
            // 
            // lblCertSerial
            // 
            this.lblCertSerial.AutoSize = true;
            this.lblCertSerial.Location = new System.Drawing.Point(114, 45);
            this.lblCertSerial.Name = "lblCertSerial";
            this.lblCertSerial.Size = new System.Drawing.Size(81, 19);
            this.lblCertSerial.TabIndex = 3;
            this.lblCertSerial.Text = "lblCertSerial";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 19);
            this.label6.TabIndex = 2;
            this.label6.Text = "Serial:";
            // 
            // tb_search
            // 
            // 
            // 
            // 
            this.tb_search.CustomButton.Image = null;
            this.tb_search.CustomButton.Location = new System.Drawing.Point(159, 2);
            this.tb_search.CustomButton.Name = "";
            this.tb_search.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.tb_search.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tb_search.CustomButton.TabIndex = 1;
            this.tb_search.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tb_search.CustomButton.UseSelectable = true;
            this.tb_search.CustomButton.Visible = false;
            this.tb_search.Lines = new string[0];
            this.tb_search.Location = new System.Drawing.Point(521, 15);
            this.tb_search.MaxLength = 32767;
            this.tb_search.Name = "tb_search";
            this.tb_search.PasswordChar = '\0';
            this.tb_search.PromptText = "Search...";
            this.tb_search.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_search.SelectedText = "";
            this.tb_search.SelectionLength = 0;
            this.tb_search.SelectionStart = 0;
            this.tb_search.ShortcutsEnabled = true;
            this.tb_search.Size = new System.Drawing.Size(177, 20);
            this.tb_search.TabIndex = 10;
            this.tb_search.UseSelectable = true;
            this.tb_search.WaterMark = "Search...";
            this.tb_search.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tb_search.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.tb_search.TextChanged += new System.EventHandler(this.tb_search_TextChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(476, 15);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(39, 19);
            this.metroLabel1.TabIndex = 13;
            this.metroLabel1.Text = "User:";
            // 
            // lblHSMPresent
            // 
            this.lblHSMPresent.AutoSize = true;
            this.lblHSMPresent.Location = new System.Drawing.Point(4, 555);
            this.lblHSMPresent.Name = "lblHSMPresent";
            this.lblHSMPresent.Size = new System.Drawing.Size(94, 19);
            this.lblHSMPresent.TabIndex = 21;
            this.lblHSMPresent.Text = "lblHSMPresent";
            // 
            // lblStatusStripVersion
            // 
            this.lblStatusStripVersion.AutoSize = true;
            this.lblStatusStripVersion.Location = new System.Drawing.Point(132, 555);
            this.lblStatusStripVersion.Name = "lblStatusStripVersion";
            this.lblStatusStripVersion.Size = new System.Drawing.Size(126, 19);
            this.lblStatusStripVersion.TabIndex = 22;
            this.lblStatusStripVersion.Text = "lblStatusStripVersion";
            // 
            // tsbAbout
            // 
            this.tsbAbout.Image = global::EnrollmentStation.Properties.Resources.star_24px;
            this.tsbAbout.Location = new System.Drawing.Point(152, 57);
            this.tsbAbout.Name = "tsbAbout";
            this.tsbAbout.Size = new System.Drawing.Size(38, 38);
            this.tsbAbout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tsbAbout.TabIndex = 25;
            this.tsbAbout.TabStop = false;
            this.tsbAbout.Click += new System.EventHandler(this.tsbAbout_Click);
            this.tsbAbout.MouseLeave += new System.EventHandler(this.tsbAbout_MouseLeave);
            this.tsbAbout.MouseHover += new System.EventHandler(this.tsbAbout_MouseHover);
            // 
            // tsbSettings
            // 
            this.tsbSettings.Image = global::EnrollmentStation.Properties.Resources.settings_24px;
            this.tsbSettings.Location = new System.Drawing.Point(88, 57);
            this.tsbSettings.Name = "tsbSettings";
            this.tsbSettings.Size = new System.Drawing.Size(38, 38);
            this.tsbSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tsbSettings.TabIndex = 24;
            this.tsbSettings.TabStop = false;
            this.tsbSettings.Click += new System.EventHandler(this.tsbSettings_Click);
            this.tsbSettings.MouseLeave += new System.EventHandler(this.tsbSettings_MouseLeave);
            this.tsbSettings.MouseHover += new System.EventHandler(this.tsbSettings_MouseHover);
            // 
            // tsbEnroll
            // 
            this.tsbEnroll.Image = global::EnrollmentStation.Properties.Resources.add_24px;
            this.tsbEnroll.Location = new System.Drawing.Point(23, 57);
            this.tsbEnroll.Name = "tsbEnroll";
            this.tsbEnroll.Size = new System.Drawing.Size(38, 38);
            this.tsbEnroll.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tsbEnroll.TabIndex = 23;
            this.tsbEnroll.TabStop = false;
            this.tsbEnroll.Click += new System.EventHandler(this.tsbEnrollKey_Click);
            this.tsbEnroll.MouseLeave += new System.EventHandler(this.tsbEnroll_MouseLeave);
            this.tsbEnroll.MouseHover += new System.EventHandler(this.tsbEnroll_MouseHover);
            // 
            // lstItems
            // 
            this.lstItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmSerial,
            this.clmUser,
            this.clmSlot,
            this.clmEnrolledAt,
            this.clmCertificateSerial});
            this.lstItems.ContextMenuStrip = this.contextMenuStrip1;
            this.lstItems.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstItems.FullRowSelect = true;
            this.lstItems.GridLines = true;
            this.lstItems.HideSelection = false;
            this.lstItems.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lstItems.Location = new System.Drawing.Point(476, 41);
            this.lstItems.MultiSelect = false;
            this.lstItems.Name = "lstItems";
            this.lstItems.ShowGroups = false;
            this.lstItems.Size = new System.Drawing.Size(713, 509);
            this.lstItems.TabIndex = 26;
            this.lstItems.UseCompatibleStateImageBehavior = false;
            this.lstItems.View = System.Windows.Forms.View.Details;
            this.lstItems.SelectedIndexChanged += new System.EventHandler(this.lstItems_SelectedIndexChanged);
            // 
            // clmSerial
            // 
            this.clmSerial.Text = "Serial";
            this.clmSerial.Width = 86;
            // 
            // clmUser
            // 
            this.clmUser.Text = "User";
            this.clmUser.Width = 71;
            // 
            // clmSlot
            // 
            this.clmSlot.Text = "Slot";
            this.clmSlot.Width = 118;
            // 
            // clmEnrolledAt
            // 
            this.clmEnrolledAt.Text = "Enrolled on";
            this.clmEnrolledAt.Width = 142;
            // 
            // clmCertificateSerial
            // 
            this.clmCertificateSerial.Text = "Certificate";
            this.clmCertificateSerial.Width = 291;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 576);
            this.Controls.Add(this.lstItems);
            this.Controls.Add(this.tsbAbout);
            this.Controls.Add(this.tsbSettings);
            this.Controls.Add(this.tsbEnroll);
            this.Controls.Add(this.lblHSMPresent);
            this.Controls.Add(this.lblStatusStripVersion);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.tb_search);
            this.Controls.Add(this.gbSelectedKeyCertificate);
            this.Controls.Add(this.gbInsertedKey);
            this.Controls.Add(this.gbSelectedKey);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1202, 576);
            this.Name = "MainForm";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "YubiKey Enrollment Station";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.gbInsertedKey.ResumeLayout(false);
            this.gbInsertedKey.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbSelectedKey.ResumeLayout(false);
            this.gbSelectedKey.PerformLayout();
            this.gbSelectedKeyCertificate.ResumeLayout(false);
            this.gbSelectedKeyCertificate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tsbAbout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsbSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsbEnroll)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ToolStripMenuItem viewCertificateToolStripMenuItem;
        private ToolStripMenuItem exportCertificateToolStripMenuItem;
        private ToolStripMenuItem changePINToolStripMenuItem;
        private ToolStripMenuItem revocationToolStripMenuItem;
        private ToolStripMenuItem revokeToolStripMenuItem;
        private GroupBox gbInsertedKey;
        private GroupBox gbSelectedKey;
        private GroupBox gbSelectedKeyCertificate;
        private MetroFramework.Controls.MetroButton btnResetYubiKey;
        private MetroFramework.Controls.MetroTextBox tb_search;
        private MetroFramework.Controls.MetroButton btnViewCert;
        private MetroFramework.Controls.MetroButton btnExportCert;
        private MetroFramework.Controls.MetroButton btnEnableCCID;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel lblHSMPresent;
        private MetroFramework.Controls.MetroLabel lblStatusStripVersion;
        private PictureBox tsbEnroll;
        private PictureBox tsbSettings;
        private PictureBox tsbAbout;
        private PictureBox pictureBox1;
        private MetroFramework.Controls.MetroLabel lblInsertedHasBeenEnrolled;
        private MetroFramework.Controls.MetroLabel label1;
        private MetroFramework.Controls.MetroLabel lblInsertedFirmware;
        private MetroFramework.Controls.MetroLabel label8;
        private MetroFramework.Controls.MetroLabel lblInsertedMode;
        private MetroFramework.Controls.MetroLabel label14;
        private MetroFramework.Controls.MetroLabel dlblInsertedSerial;
        private MetroFramework.Controls.MetroLabel lblInsertedSerial;
        private MetroFramework.Controls.MetroLabel lblYubikeyFirmware;
        private MetroFramework.Controls.MetroLabel label17;
        private MetroFramework.Controls.MetroLabel label4;
        private MetroFramework.Controls.MetroLabel lblYubikeyPivVersion;
        private MetroFramework.Controls.MetroLabel label2;
        private MetroFramework.Controls.MetroLabel lblYubikeySerial;
        private MetroFramework.Controls.MetroLabel lblCertThumbprint;
        private MetroFramework.Controls.MetroLabel label11;
        private MetroFramework.Controls.MetroLabel lblCertCA;
        private MetroFramework.Controls.MetroLabel label13;
        private MetroFramework.Controls.MetroLabel lblCertUser;
        private MetroFramework.Controls.MetroLabel label7;
        private MetroFramework.Controls.MetroLabel lblCertEnrolledOn;
        private MetroFramework.Controls.MetroLabel label5;
        private MetroFramework.Controls.MetroLabel lblCertSerial;
        private MetroFramework.Controls.MetroLabel label6;
        private MetroFramework.Controls.MetroLabel lblMultipleKeys;
        private MetroFramework.Controls.MetroLabel lblDevType;
        private MetroFramework.Controls.MetroLabel label3;
        private MetroFramework.Controls.MetroContextMenu contextMenuStrip1;
        private ListView lstItems;
        private ColumnHeader clmSerial;
        private ColumnHeader clmUser;
        private ColumnHeader clmSlot;
        private ColumnHeader clmEnrolledAt;
        private ColumnHeader clmCertificateSerial;
    }
}
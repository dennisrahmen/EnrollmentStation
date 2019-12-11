﻿using System.ComponentModel;
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.revocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.revokeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminateToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCertificateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportCertificateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePINToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblHSMPresent = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDummyStatusStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusStripVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbEnroll = new System.Windows.Forms.ToolStripButton();
            this.tsbSettings = new System.Windows.Forms.ToolStripButton();
            this.tsbAbout = new System.Windows.Forms.ToolStripButton();
            this.gbInsertedKey = new System.Windows.Forms.GroupBox();
            this.lblDevType = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMultipleKeys = new System.Windows.Forms.Label();
            this.btnViewCert = new System.Windows.Forms.Button();
            this.btnExportCert = new System.Windows.Forms.Button();
            this.lblInsertedHasBeenEnrolled = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInsertedFirmware = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblInsertedMode = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dlblInsertedSerial = new System.Windows.Forms.Label();
            this.lblInsertedSerial = new System.Windows.Forms.Label();
            this.gbSelectedKey = new System.Windows.Forms.GroupBox();
            this.lblYubikeyFirmware = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblYubikeyPivVersion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblYubikeySerial = new System.Windows.Forms.Label();
            this.gbSelectedKeyCertificate = new System.Windows.Forms.GroupBox();
            this.lblCertThumbprint = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblCertCA = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblCertUser = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCertEnrolledOn = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCertSerial = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lstItems = new System.Windows.Forms.ListView();
            this.clmSerial = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmEnrolledAt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCertificateSerial = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnEnableCCID = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.gbInsertedKey.SuspendLayout();
            this.gbSelectedKey.SuspendLayout();
            this.gbSelectedKeyCertificate.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.revocationToolStripMenuItem,
            this.viewCertificateToolStripMenuItem,
            this.exportCertificateToolStripMenuItem,
            this.changePINToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(194, 100);
            // 
            // revocationToolStripMenuItem
            // 
            this.revocationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.revokeToolStripMenuItem,
            this.terminateToolStripMenuItem1});
            this.revocationToolStripMenuItem.Name = "revocationToolStripMenuItem";
            this.revocationToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.revocationToolStripMenuItem.Text = "&Revocation";
            // 
            // revokeToolStripMenuItem
            // 
            this.revokeToolStripMenuItem.Name = "revokeToolStripMenuItem";
            this.revokeToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.revokeToolStripMenuItem.Text = "Revoke";
            this.revokeToolStripMenuItem.Click += new System.EventHandler(this.revokeToolStripMenuItem_Click_1);
            // 
            // terminateToolStripMenuItem1
            // 
            this.terminateToolStripMenuItem1.Name = "terminateToolStripMenuItem1";
            this.terminateToolStripMenuItem1.Size = new System.Drawing.Size(158, 26);
            this.terminateToolStripMenuItem1.Text = "Terminate";
            this.terminateToolStripMenuItem1.Click += new System.EventHandler(this.terminateToolStripMenuItem1_Click);
            // 
            // viewCertificateToolStripMenuItem
            // 
            this.viewCertificateToolStripMenuItem.Name = "viewCertificateToolStripMenuItem";
            this.viewCertificateToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.viewCertificateToolStripMenuItem.Text = "View Certificate";
            this.viewCertificateToolStripMenuItem.Click += new System.EventHandler(this.viewCertificateToolStripMenuItem_Click);
            // 
            // exportCertificateToolStripMenuItem
            // 
            this.exportCertificateToolStripMenuItem.Name = "exportCertificateToolStripMenuItem";
            this.exportCertificateToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.exportCertificateToolStripMenuItem.Text = "Export Certificate";
            this.exportCertificateToolStripMenuItem.Click += new System.EventHandler(this.exportCertificateToolStripMenuItem_Click);
            // 
            // changePINToolStripMenuItem
            // 
            this.changePINToolStripMenuItem.Name = "changePINToolStripMenuItem";
            this.changePINToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.changePINToolStripMenuItem.Text = "Reset PIN";
            this.changePINToolStripMenuItem.Click += new System.EventHandler(this.resetPINToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblHSMPresent,
            this.lblDummyStatusStrip,
            this.lblStatusStripVersion});
            this.statusStrip1.Location = new System.Drawing.Point(0, 557);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1173, 26);
            this.statusStrip1.TabIndex = 8;
            // 
            // lblHSMPresent
            // 
            this.lblHSMPresent.Name = "lblHSMPresent";
            this.lblHSMPresent.Size = new System.Drawing.Size(106, 20);
            this.lblHSMPresent.Text = "lblHSMPresent";
            // 
            // lblDummyStatusStrip
            // 
            this.lblDummyStatusStrip.Name = "lblDummyStatusStrip";
            this.lblDummyStatusStrip.Size = new System.Drawing.Size(902, 20);
            this.lblDummyStatusStrip.Spring = true;
            // 
            // lblStatusStripVersion
            // 
            this.lblStatusStripVersion.Name = "lblStatusStripVersion";
            this.lblStatusStripVersion.Size = new System.Drawing.Size(145, 20);
            this.lblStatusStripVersion.Text = "lblStatusStripVersion";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbEnroll,
            this.tsbSettings,
            this.tsbAbout});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1173, 39);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbEnroll
            // 
            this.tsbEnroll.AutoSize = false;
            this.tsbEnroll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEnroll.Image = ((System.Drawing.Image)(resources.GetObject("tsbEnroll.Image")));
            this.tsbEnroll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbEnroll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEnroll.Name = "tsbEnroll";
            this.tsbEnroll.Size = new System.Drawing.Size(50, 30);
            this.tsbEnroll.Text = "Enroll YubiKey";
            this.tsbEnroll.Click += new System.EventHandler(this.tsbEnrollKey_Click);
            // 
            // tsbSettings
            // 
            this.tsbSettings.AutoSize = false;
            this.tsbSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSettings.Image = ((System.Drawing.Image)(resources.GetObject("tsbSettings.Image")));
            this.tsbSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSettings.Name = "tsbSettings";
            this.tsbSettings.Size = new System.Drawing.Size(50, 30);
            this.tsbSettings.Text = "Application Settings";
            this.tsbSettings.Click += new System.EventHandler(this.tsbSettings_Click);
            // 
            // tsbAbout
            // 
            this.tsbAbout.AutoSize = false;
            this.tsbAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAbout.Image = global::EnrollmentStation.Properties.Resources.gnome_app_install_star;
            this.tsbAbout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbout.Name = "tsbAbout";
            this.tsbAbout.Size = new System.Drawing.Size(50, 30);
            this.tsbAbout.Text = "About";
            this.tsbAbout.Click += new System.EventHandler(this.tsbAbout_Click);
            // 
            // gbInsertedKey
            // 
            this.gbInsertedKey.Controls.Add(this.btnEnableCCID);
            this.gbInsertedKey.Controls.Add(this.lblDevType);
            this.gbInsertedKey.Controls.Add(this.label3);
            this.gbInsertedKey.Controls.Add(this.lblMultipleKeys);
            this.gbInsertedKey.Controls.Add(this.btnViewCert);
            this.gbInsertedKey.Controls.Add(this.btnExportCert);
            this.gbInsertedKey.Controls.Add(this.lblInsertedHasBeenEnrolled);
            this.gbInsertedKey.Controls.Add(this.label1);
            this.gbInsertedKey.Controls.Add(this.lblInsertedFirmware);
            this.gbInsertedKey.Controls.Add(this.label8);
            this.gbInsertedKey.Controls.Add(this.lblInsertedMode);
            this.gbInsertedKey.Controls.Add(this.label14);
            this.gbInsertedKey.Controls.Add(this.dlblInsertedSerial);
            this.gbInsertedKey.Controls.Add(this.lblInsertedSerial);
            this.gbInsertedKey.Location = new System.Drawing.Point(5, 354);
            this.gbInsertedKey.Margin = new System.Windows.Forms.Padding(4);
            this.gbInsertedKey.Name = "gbInsertedKey";
            this.gbInsertedKey.Padding = new System.Windows.Forms.Padding(4);
            this.gbInsertedKey.Size = new System.Drawing.Size(472, 193);
            this.gbInsertedKey.TabIndex = 3;
            this.gbInsertedKey.TabStop = false;
            this.gbInsertedKey.Text = "Inserted Yubikey";
            // 
            // lblDevType
            // 
            this.lblDevType.AutoSize = true;
            this.lblDevType.Location = new System.Drawing.Point(117, 25);
            this.lblDevType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDevType.Name = "lblDevType";
            this.lblDevType.Size = new System.Drawing.Size(79, 17);
            this.lblDevType.TabIndex = 13;
            this.lblDevType.Text = "lblDevType";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Typ";
            // 
            // lblMultipleKeys
            // 
            this.lblMultipleKeys.AutoSize = true;
            this.lblMultipleKeys.ForeColor = System.Drawing.Color.Red;
            this.lblMultipleKeys.Location = new System.Drawing.Point(363, 25);
            this.lblMultipleKeys.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMultipleKeys.Name = "lblMultipleKeys";
            this.lblMultipleKeys.Size = new System.Drawing.Size(101, 17);
            this.lblMultipleKeys.TabIndex = 11;
            this.lblMultipleKeys.Text = "lblMultipleKeys";
            // 
            // btnViewCert
            // 
            this.btnViewCert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnViewCert.Enabled = false;
            this.btnViewCert.Location = new System.Drawing.Point(11, 153);
            this.btnViewCert.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewCert.Name = "btnViewCert";
            this.btnViewCert.Size = new System.Drawing.Size(104, 23);
            this.btnViewCert.TabIndex = 8;
            this.btnViewCert.Text = "View Certificate";
            this.btnViewCert.UseVisualStyleBackColor = true;
            this.btnViewCert.Click += new System.EventHandler(this.btnViewCert_Click);
            // 
            // btnExportCert
            // 
            this.btnExportCert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportCert.Enabled = false;
            this.btnExportCert.Location = new System.Drawing.Point(135, 153);
            this.btnExportCert.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportCert.Name = "btnExportCert";
            this.btnExportCert.Size = new System.Drawing.Size(104, 23);
            this.btnExportCert.TabIndex = 9;
            this.btnExportCert.Text = "Export Certificate";
            this.btnExportCert.UseVisualStyleBackColor = true;
            this.btnExportCert.Click += new System.EventHandler(this.btnExportCert_Click);
            // 
            // lblInsertedHasBeenEnrolled
            // 
            this.lblInsertedHasBeenEnrolled.AutoSize = true;
            this.lblInsertedHasBeenEnrolled.Location = new System.Drawing.Point(117, 121);
            this.lblInsertedHasBeenEnrolled.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInsertedHasBeenEnrolled.Name = "lblInsertedHasBeenEnrolled";
            this.lblInsertedHasBeenEnrolled.Size = new System.Drawing.Size(183, 17);
            this.lblInsertedHasBeenEnrolled.TabIndex = 7;
            this.lblInsertedHasBeenEnrolled.Text = "lblInsertedHasBeenEnrolled";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 121);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Enrolled";
            // 
            // lblInsertedFirmware
            // 
            this.lblInsertedFirmware.AutoSize = true;
            this.lblInsertedFirmware.Location = new System.Drawing.Point(117, 97);
            this.lblInsertedFirmware.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInsertedFirmware.Name = "lblInsertedFirmware";
            this.lblInsertedFirmware.Size = new System.Drawing.Size(130, 17);
            this.lblInsertedFirmware.TabIndex = 5;
            this.lblInsertedFirmware.Text = "lblInsertedFirmware";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 97);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Firmware";
            // 
            // lblInsertedMode
            // 
            this.lblInsertedMode.AutoSize = true;
            this.lblInsertedMode.Location = new System.Drawing.Point(117, 73);
            this.lblInsertedMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInsertedMode.Name = "lblInsertedMode";
            this.lblInsertedMode.Size = new System.Drawing.Size(108, 17);
            this.lblInsertedMode.TabIndex = 3;
            this.lblInsertedMode.Text = "lblInsertedMode";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 73);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 17);
            this.label14.TabIndex = 2;
            this.label14.Text = "Current Mode";
            // 
            // dlblInsertedSerial
            // 
            this.dlblInsertedSerial.AutoSize = true;
            this.dlblInsertedSerial.Location = new System.Drawing.Point(11, 49);
            this.dlblInsertedSerial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dlblInsertedSerial.Name = "dlblInsertedSerial";
            this.dlblInsertedSerial.Size = new System.Drawing.Size(98, 17);
            this.dlblInsertedSerial.TabIndex = 0;
            this.dlblInsertedSerial.Text = "Serial Number";
            // 
            // lblInsertedSerial
            // 
            this.lblInsertedSerial.AutoSize = true;
            this.lblInsertedSerial.Location = new System.Drawing.Point(117, 49);
            this.lblInsertedSerial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInsertedSerial.Name = "lblInsertedSerial";
            this.lblInsertedSerial.Size = new System.Drawing.Size(109, 17);
            this.lblInsertedSerial.TabIndex = 1;
            this.lblInsertedSerial.Text = "lblInsertedSerial";
            // 
            // gbSelectedKey
            // 
            this.gbSelectedKey.Controls.Add(this.lblYubikeyFirmware);
            this.gbSelectedKey.Controls.Add(this.label17);
            this.gbSelectedKey.Controls.Add(this.label4);
            this.gbSelectedKey.Controls.Add(this.lblYubikeyPivVersion);
            this.gbSelectedKey.Controls.Add(this.label2);
            this.gbSelectedKey.Controls.Add(this.lblYubikeySerial);
            this.gbSelectedKey.Location = new System.Drawing.Point(5, 43);
            this.gbSelectedKey.Margin = new System.Windows.Forms.Padding(4);
            this.gbSelectedKey.Name = "gbSelectedKey";
            this.gbSelectedKey.Padding = new System.Windows.Forms.Padding(4);
            this.gbSelectedKey.Size = new System.Drawing.Size(472, 117);
            this.gbSelectedKey.TabIndex = 1;
            this.gbSelectedKey.TabStop = false;
            this.gbSelectedKey.Text = "YubiKey";
            // 
            // lblYubikeyFirmware
            // 
            this.lblYubikeyFirmware.AutoSize = true;
            this.lblYubikeyFirmware.Location = new System.Drawing.Point(117, 86);
            this.lblYubikeyFirmware.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblYubikeyFirmware.Name = "lblYubikeyFirmware";
            this.lblYubikeyFirmware.Size = new System.Drawing.Size(129, 17);
            this.lblYubikeyFirmware.TabIndex = 5;
            this.lblYubikeyFirmware.Text = "lblYubikeyFirmware";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(11, 86);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 17);
            this.label17.TabIndex = 4;
            this.label17.Text = "Firmware";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 55);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "PIV Version";
            // 
            // lblYubikeyPivVersion
            // 
            this.lblYubikeyPivVersion.AutoSize = true;
            this.lblYubikeyPivVersion.Location = new System.Drawing.Point(117, 55);
            this.lblYubikeyPivVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblYubikeyPivVersion.Name = "lblYubikeyPivVersion";
            this.lblYubikeyPivVersion.Size = new System.Drawing.Size(139, 17);
            this.lblYubikeyPivVersion.TabIndex = 3;
            this.lblYubikeyPivVersion.Text = "lblYubikeyPivVersion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Serial Number";
            // 
            // lblYubikeySerial
            // 
            this.lblYubikeySerial.AutoSize = true;
            this.lblYubikeySerial.Location = new System.Drawing.Point(117, 25);
            this.lblYubikeySerial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblYubikeySerial.Name = "lblYubikeySerial";
            this.lblYubikeySerial.Size = new System.Drawing.Size(108, 17);
            this.lblYubikeySerial.TabIndex = 1;
            this.lblYubikeySerial.Text = "lblYubikeySerial";
            // 
            // gbSelectedKeyCertificate
            // 
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
            this.gbSelectedKeyCertificate.Location = new System.Drawing.Point(5, 169);
            this.gbSelectedKeyCertificate.Margin = new System.Windows.Forms.Padding(4);
            this.gbSelectedKeyCertificate.Name = "gbSelectedKeyCertificate";
            this.gbSelectedKeyCertificate.Padding = new System.Windows.Forms.Padding(4);
            this.gbSelectedKeyCertificate.Size = new System.Drawing.Size(472, 178);
            this.gbSelectedKeyCertificate.TabIndex = 2;
            this.gbSelectedKeyCertificate.TabStop = false;
            this.gbSelectedKeyCertificate.Text = "Certificate";
            // 
            // lblCertThumbprint
            // 
            this.lblCertThumbprint.AutoSize = true;
            this.lblCertThumbprint.Location = new System.Drawing.Point(117, 148);
            this.lblCertThumbprint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCertThumbprint.Name = "lblCertThumbprint";
            this.lblCertThumbprint.Size = new System.Drawing.Size(120, 17);
            this.lblCertThumbprint.TabIndex = 9;
            this.lblCertThumbprint.Text = "lblCertThumbprint";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 148);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 17);
            this.label11.TabIndex = 8;
            this.label11.Text = "Thumbprint";
            // 
            // lblCertCA
            // 
            this.lblCertCA.AutoSize = true;
            this.lblCertCA.Location = new System.Drawing.Point(117, 117);
            this.lblCertCA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCertCA.Name = "lblCertCA";
            this.lblCertCA.Size = new System.Drawing.Size(66, 17);
            this.lblCertCA.TabIndex = 7;
            this.lblCertCA.Text = "lblCertCA";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 117);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 17);
            this.label13.TabIndex = 6;
            this.label13.Text = "CA";
            // 
            // lblCertUser
            // 
            this.lblCertUser.AutoSize = true;
            this.lblCertUser.Location = new System.Drawing.Point(117, 25);
            this.lblCertUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCertUser.Name = "lblCertUser";
            this.lblCertUser.Size = new System.Drawing.Size(78, 17);
            this.lblCertUser.TabIndex = 1;
            this.lblCertUser.Text = "lblCertUser";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 25);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "User";
            // 
            // lblCertEnrolledOn
            // 
            this.lblCertEnrolledOn.AutoSize = true;
            this.lblCertEnrolledOn.Location = new System.Drawing.Point(117, 86);
            this.lblCertEnrolledOn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCertEnrolledOn.Name = "lblCertEnrolledOn";
            this.lblCertEnrolledOn.Size = new System.Drawing.Size(119, 17);
            this.lblCertEnrolledOn.TabIndex = 5;
            this.lblCertEnrolledOn.Text = "lblCertEnrolledOn";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 86);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Enrolled on";
            // 
            // lblCertSerial
            // 
            this.lblCertSerial.AutoSize = true;
            this.lblCertSerial.Location = new System.Drawing.Point(117, 55);
            this.lblCertSerial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCertSerial.Name = "lblCertSerial";
            this.lblCertSerial.Size = new System.Drawing.Size(84, 17);
            this.lblCertSerial.TabIndex = 3;
            this.lblCertSerial.Text = "lblCertSerial";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 55);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Serial";
            // 
            // lstItems
            // 
            this.lstItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmSerial,
            this.clmUser,
            this.clmEnrolledAt,
            this.clmCertificateSerial});
            this.lstItems.ContextMenuStrip = this.contextMenuStrip1;
            this.lstItems.FullRowSelect = true;
            this.lstItems.HideSelection = false;
            this.lstItems.Location = new System.Drawing.Point(485, 50);
            this.lstItems.Margin = new System.Windows.Forms.Padding(4);
            this.lstItems.MultiSelect = false;
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(677, 496);
            this.lstItems.TabIndex = 7;
            this.lstItems.UseCompatibleStateImageBehavior = false;
            this.lstItems.View = System.Windows.Forms.View.Details;
            this.lstItems.SelectedIndexChanged += new System.EventHandler(this.lstItems_SelectedIndexChanged);
            // 
            // clmSerial
            // 
            this.clmSerial.Text = "Serial";
            // 
            // clmUser
            // 
            this.clmUser.Text = "User";
            this.clmUser.Width = 132;
            // 
            // clmEnrolledAt
            // 
            this.clmEnrolledAt.Text = "Enrolled on";
            this.clmEnrolledAt.Width = 118;
            // 
            // clmCertificateSerial
            // 
            this.clmCertificateSerial.Text = "Certificate";
            this.clmCertificateSerial.Width = 189;
            // 
            // btnEnableCCID
            // 
            this.btnEnableCCID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEnableCCID.Enabled = false;
            this.btnEnableCCID.Location = new System.Drawing.Point(258, 153);
            this.btnEnableCCID.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnableCCID.Name = "btnEnableCCID";
            this.btnEnableCCID.Size = new System.Drawing.Size(104, 23);
            this.btnEnableCCID.TabIndex = 14;
            this.btnEnableCCID.Text = "Change Mode";
            this.btnEnableCCID.UseVisualStyleBackColor = true;
            this.btnEnableCCID.Click += new System.EventHandler(this.btnEnableCCID_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 583);
            this.Controls.Add(this.gbSelectedKeyCertificate);
            this.Controls.Add(this.gbInsertedKey);
            this.Controls.Add(this.gbSelectedKey);
            this.Controls.Add(this.lstItems);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1189, 619);
            this.Name = "MainForm";
            this.Text = "CSIS Enrollment Station";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gbInsertedKey.ResumeLayout(false);
            this.gbInsertedKey.PerformLayout();
            this.gbSelectedKey.ResumeLayout(false);
            this.gbSelectedKey.PerformLayout();
            this.gbSelectedKeyCertificate.ResumeLayout(false);
            this.gbSelectedKeyCertificate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem viewCertificateToolStripMenuItem;
        private ToolStripMenuItem exportCertificateToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblHSMPresent;
        private ToolStripMenuItem changePINToolStripMenuItem;
        private ToolStripMenuItem revocationToolStripMenuItem;
        private ToolStripMenuItem revokeToolStripMenuItem;
        private ToolStripMenuItem terminateToolStripMenuItem1;
        private ToolStrip toolStrip1;
        private ToolStripButton tsbEnroll;
        private ToolStripButton tsbSettings;
        private ToolStripButton tsbAbout;
        private GroupBox gbInsertedKey;
        private Label lblInsertedHasBeenEnrolled;
        private Label label1;
        private Label lblInsertedFirmware;
        private Label label8;
        private Label lblInsertedMode;
        private Label label14;
        private Label dlblInsertedSerial;
        private Label lblInsertedSerial;
        private GroupBox gbSelectedKey;
        private Label lblYubikeyFirmware;
        private Label label17;
        private Label label4;
        private Label lblYubikeyPivVersion;
        private Label label2;
        private Label lblYubikeySerial;
        private GroupBox gbSelectedKeyCertificate;
        private Label lblCertThumbprint;
        private Label label11;
        private Label lblCertCA;
        private Label label13;
        private Label lblCertUser;
        private Label label7;
        private Label lblCertEnrolledOn;
        private Label label5;
        private Label lblCertSerial;
        private Label label6;
        private ListView lstItems;
        private ColumnHeader clmSerial;
        private ColumnHeader clmUser;
        private ColumnHeader clmEnrolledAt;
        private ColumnHeader clmCertificateSerial;
        private ToolStripStatusLabel lblStatusStripVersion;
        private ToolStripStatusLabel lblDummyStatusStrip;
        private Button btnViewCert;
        private Button btnExportCert;
        private Label lblMultipleKeys;
        private Label lblDevType;
        private Label label3;
        private Button btnEnableCCID;
    }
}
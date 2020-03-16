using System.ComponentModel;
using System.Windows.Forms;

namespace EnrollmentStation
{
    partial class DlgEnroll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgEnroll));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.llBrowseAdmUser = new System.Windows.Forms.LinkLabel();
            this.txtAdmUser = new System.Windows.Forms.TextBox();
            this.label4 = new MetroFramework.Controls.MetroLabel();
            this.llBrowseStdUser = new System.Windows.Forms.LinkLabel();
            this.txtStdUser = new System.Windows.Forms.TextBox();
            this.label2 = new MetroFramework.Controls.MetroLabel();
            this.gbInsertedYubikey = new System.Windows.Forms.GroupBox();
            this.lblInsertedTyp = new MetroFramework.Controls.MetroLabel();
            this.label3 = new MetroFramework.Controls.MetroLabel();
            this.lblAlreadyEnrolled = new MetroFramework.Controls.MetroLabel();
            this.specialYubiHsm = new MetroFramework.Controls.MetroLabel();
            this.label5 = new MetroFramework.Controls.MetroLabel();
            this.lblInsertedFirmware = new MetroFramework.Controls.MetroLabel();
            this.label8 = new MetroFramework.Controls.MetroLabel();
            this.lblInsertedMode = new MetroFramework.Controls.MetroLabel();
            this.label14 = new MetroFramework.Controls.MetroLabel();
            this.dlblInsertedSerial = new MetroFramework.Controls.MetroLabel();
            this.lblInsertedSerial = new MetroFramework.Controls.MetroLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPinAgain = new System.Windows.Forms.TextBox();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.label7 = new MetroFramework.Controls.MetroLabel();
            this.label6 = new MetroFramework.Controls.MetroLabel();
            this.cmdEnroll = new MetroFramework.Controls.MetroButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.drpAlgorithm = new MetroFramework.Controls.MetroComboBox();
            this.label1 = new MetroFramework.Controls.MetroLabel();
            this.prgEnroll = new MetroFramework.Controls.MetroProgressBar();
            this.groupBox1.SuspendLayout();
            this.gbInsertedYubikey.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.llBrowseAdmUser);
            this.groupBox1.Controls.Add(this.txtAdmUser);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.llBrowseStdUser);
            this.groupBox1.Controls.Add(this.txtStdUser);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(6, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Details";
            // 
            // llBrowseAdmUser
            // 
            this.llBrowseAdmUser.AutoSize = true;
            this.llBrowseAdmUser.Location = new System.Drawing.Point(297, 47);
            this.llBrowseAdmUser.Name = "llBrowseAdmUser";
            this.llBrowseAdmUser.Size = new System.Drawing.Size(42, 13);
            this.llBrowseAdmUser.TabIndex = 5;
            this.llBrowseAdmUser.TabStop = true;
            this.llBrowseAdmUser.Text = "Browse";
            this.llBrowseAdmUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llBrowseAdmUser_LinkClicked);
            // 
            // txtAdmUser
            // 
            this.txtAdmUser.Location = new System.Drawing.Point(114, 44);
            this.txtAdmUser.Name = "txtAdmUser";
            this.txtAdmUser.Size = new System.Drawing.Size(177, 20);
            this.txtAdmUser.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Admin User:";
            // 
            // llBrowseStdUser
            // 
            this.llBrowseStdUser.AutoSize = true;
            this.llBrowseStdUser.Location = new System.Drawing.Point(297, 20);
            this.llBrowseStdUser.Name = "llBrowseStdUser";
            this.llBrowseStdUser.Size = new System.Drawing.Size(42, 13);
            this.llBrowseStdUser.TabIndex = 2;
            this.llBrowseStdUser.TabStop = true;
            this.llBrowseStdUser.Text = "Browse";
            this.llBrowseStdUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llBrowseStdUser_LinkClicked);
            // 
            // txtStdUser
            // 
            this.txtStdUser.Location = new System.Drawing.Point(114, 16);
            this.txtStdUser.Name = "txtStdUser";
            this.txtStdUser.Size = new System.Drawing.Size(177, 20);
            this.txtStdUser.TabIndex = 1;
            this.txtStdUser.TextChanged += new System.EventHandler(this.textBoxes_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Standard User:";
            // 
            // gbInsertedYubikey
            // 
            this.gbInsertedYubikey.Controls.Add(this.lblInsertedTyp);
            this.gbInsertedYubikey.Controls.Add(this.label3);
            this.gbInsertedYubikey.Controls.Add(this.lblAlreadyEnrolled);
            this.gbInsertedYubikey.Controls.Add(this.specialYubiHsm);
            this.gbInsertedYubikey.Controls.Add(this.label5);
            this.gbInsertedYubikey.Controls.Add(this.lblInsertedFirmware);
            this.gbInsertedYubikey.Controls.Add(this.label8);
            this.gbInsertedYubikey.Controls.Add(this.lblInsertedMode);
            this.gbInsertedYubikey.Controls.Add(this.label14);
            this.gbInsertedYubikey.Controls.Add(this.dlblInsertedSerial);
            this.gbInsertedYubikey.Controls.Add(this.lblInsertedSerial);
            this.gbInsertedYubikey.Location = new System.Drawing.Point(6, 280);
            this.gbInsertedYubikey.Name = "gbInsertedYubikey";
            this.gbInsertedYubikey.Size = new System.Drawing.Size(350, 139);
            this.gbInsertedYubikey.TabIndex = 2;
            this.gbInsertedYubikey.TabStop = false;
            this.gbInsertedYubikey.Text = "Inserted Yubikey";
            // 
            // lblInsertedTyp
            // 
            this.lblInsertedTyp.AutoSize = true;
            this.lblInsertedTyp.Location = new System.Drawing.Point(140, 19);
            this.lblInsertedTyp.Name = "lblInsertedTyp";
            this.lblInsertedTyp.Size = new System.Drawing.Size(90, 19);
            this.lblInsertedTyp.TabIndex = 10;
            this.lblInsertedTyp.Text = "lblInsertedTyp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "Typ:";
            // 
            // lblAlreadyEnrolled
            // 
            this.lblAlreadyEnrolled.AutoSize = true;
            this.lblAlreadyEnrolled.ForeColor = System.Drawing.Color.Black;
            this.lblAlreadyEnrolled.Location = new System.Drawing.Point(108, -3);
            this.lblAlreadyEnrolled.Name = "lblAlreadyEnrolled";
            this.lblAlreadyEnrolled.Size = new System.Drawing.Size(65, 19);
            this.lblAlreadyEnrolled.TabIndex = 8;
            this.lblAlreadyEnrolled.Text = "Loading...";
            this.lblAlreadyEnrolled.UseCustomForeColor = true;
            // 
            // specialYubiHsm
            // 
            this.specialYubiHsm.AutoSize = true;
            this.specialYubiHsm.Location = new System.Drawing.Point(140, 115);
            this.specialYubiHsm.Name = "specialYubiHsm";
            this.specialYubiHsm.Size = new System.Drawing.Size(99, 19);
            this.specialYubiHsm.TabIndex = 7;
            this.specialYubiHsm.Text = "specialYubiHsm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "YubiHSM available:";
            // 
            // lblInsertedFirmware
            // 
            this.lblInsertedFirmware.AutoSize = true;
            this.lblInsertedFirmware.Location = new System.Drawing.Point(140, 91);
            this.lblInsertedFirmware.Name = "lblInsertedFirmware";
            this.lblInsertedFirmware.Size = new System.Drawing.Size(125, 19);
            this.lblInsertedFirmware.TabIndex = 5;
            this.lblInsertedFirmware.Text = "lblInsertedFirmware";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 19);
            this.label8.TabIndex = 4;
            this.label8.Text = "Firmware:";
            // 
            // lblInsertedMode
            // 
            this.lblInsertedMode.AutoSize = true;
            this.lblInsertedMode.Location = new System.Drawing.Point(140, 67);
            this.lblInsertedMode.Name = "lblInsertedMode";
            this.lblInsertedMode.Size = new System.Drawing.Size(105, 19);
            this.lblInsertedMode.TabIndex = 3;
            this.lblInsertedMode.Text = "lblInsertedMode";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 67);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 19);
            this.label14.TabIndex = 2;
            this.label14.Text = "Current Mode:";
            // 
            // dlblInsertedSerial
            // 
            this.dlblInsertedSerial.AutoSize = true;
            this.dlblInsertedSerial.Location = new System.Drawing.Point(13, 43);
            this.dlblInsertedSerial.Name = "dlblInsertedSerial";
            this.dlblInsertedSerial.Size = new System.Drawing.Size(98, 19);
            this.dlblInsertedSerial.TabIndex = 0;
            this.dlblInsertedSerial.Text = "Serial Number:";
            // 
            // lblInsertedSerial
            // 
            this.lblInsertedSerial.AutoSize = true;
            this.lblInsertedSerial.Location = new System.Drawing.Point(140, 43);
            this.lblInsertedSerial.Name = "lblInsertedSerial";
            this.lblInsertedSerial.Size = new System.Drawing.Size(102, 19);
            this.lblInsertedSerial.TabIndex = 1;
            this.lblInsertedSerial.Text = "lblInsertedSerial";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtPinAgain);
            this.groupBox3.Controls.Add(this.txtPin);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(6, 140);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(350, 75);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PIN code";
            // 
            // txtPinAgain
            // 
            this.txtPinAgain.Location = new System.Drawing.Point(114, 44);
            this.txtPinAgain.Name = "txtPinAgain";
            this.txtPinAgain.PasswordChar = '*';
            this.txtPinAgain.Size = new System.Drawing.Size(177, 20);
            this.txtPinAgain.TabIndex = 3;
            this.txtPinAgain.UseSystemPasswordChar = true;
            this.txtPinAgain.TextChanged += new System.EventHandler(this.textBoxes_TextChanged);
            this.txtPinAgain.Validating += new System.ComponentModel.CancelEventHandler(this.txtPinAgain_Validating);
            // 
            // txtPin
            // 
            this.txtPin.Location = new System.Drawing.Point(114, 16);
            this.txtPin.Name = "txtPin";
            this.txtPin.PasswordChar = '*';
            this.txtPin.Size = new System.Drawing.Size(177, 20);
            this.txtPin.TabIndex = 1;
            this.txtPin.UseSystemPasswordChar = true;
            this.txtPin.TextChanged += new System.EventHandler(this.textBoxes_TextChanged);
            this.txtPin.Validating += new System.ComponentModel.CancelEventHandler(this.txtPin_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 19);
            this.label7.TabIndex = 2;
            this.label7.Text = "PIN (again):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "PIN:";
            // 
            // cmdEnroll
            // 
            this.cmdEnroll.Location = new System.Drawing.Point(281, 428);
            this.cmdEnroll.Name = "cmdEnroll";
            this.cmdEnroll.Size = new System.Drawing.Size(75, 23);
            this.cmdEnroll.TabIndex = 4;
            this.cmdEnroll.Text = "Enroll";
            this.cmdEnroll.UseSelectable = true;
            this.cmdEnroll.Click += new System.EventHandler(this.cmdEnroll_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.drpAlgorithm);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(6, 221);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(350, 53);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Key details";
            // 
            // drpAlgorithm
            // 
            this.drpAlgorithm.FormattingEnabled = true;
            this.drpAlgorithm.ItemHeight = 23;
            this.drpAlgorithm.Location = new System.Drawing.Point(114, 16);
            this.drpAlgorithm.Name = "drpAlgorithm";
            this.drpAlgorithm.Size = new System.Drawing.Size(177, 29);
            this.drpAlgorithm.TabIndex = 12;
            this.drpAlgorithm.UseSelectable = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Algorithm:";
            // 
            // prgEnroll
            // 
            this.prgEnroll.Location = new System.Drawing.Point(6, 428);
            this.prgEnroll.Name = "prgEnroll";
            this.prgEnroll.Size = new System.Drawing.Size(269, 23);
            this.prgEnroll.TabIndex = 11;
            // 
            // DlgEnroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(364, 458);
            this.Controls.Add(this.prgEnroll);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmdEnroll);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbInsertedYubikey);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgEnroll";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enroll new YubiKey";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DlgEnroll_FormClosing);
            this.Load += new System.EventHandler(this.DlgEnroll_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbInsertedYubikey.ResumeLayout(false);
            this.gbInsertedYubikey.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox gbInsertedYubikey;
        private TextBox txtStdUser;
        private GroupBox groupBox3;
        private TextBox txtPinAgain;
        private TextBox txtPin;
        private LinkLabel llBrowseStdUser;
        private GroupBox groupBox2;
        private LinkLabel llBrowseAdmUser;
        private TextBox txtAdmUser;
        private MetroFramework.Controls.MetroProgressBar prgEnroll;
        private MetroFramework.Controls.MetroLabel label2;
        private MetroFramework.Controls.MetroLabel label7;
        private MetroFramework.Controls.MetroLabel label6;
        private MetroFramework.Controls.MetroLabel lblInsertedFirmware;
        private MetroFramework.Controls.MetroLabel label8;
        private MetroFramework.Controls.MetroLabel lblInsertedMode;
        private MetroFramework.Controls.MetroLabel label14;
        private MetroFramework.Controls.MetroLabel dlblInsertedSerial;
        private MetroFramework.Controls.MetroLabel lblInsertedSerial;
        private MetroFramework.Controls.MetroLabel lblAlreadyEnrolled;
        private MetroFramework.Controls.MetroLabel specialYubiHsm;
        private MetroFramework.Controls.MetroLabel label5;
        private MetroFramework.Controls.MetroLabel label1;
        private MetroFramework.Controls.MetroLabel label3;
        private MetroFramework.Controls.MetroLabel lblInsertedTyp;
        private MetroFramework.Controls.MetroLabel label4;
        private MetroFramework.Controls.MetroButton cmdEnroll;
        private MetroFramework.Controls.MetroComboBox drpAlgorithm;
    }
}
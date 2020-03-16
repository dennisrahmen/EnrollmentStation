namespace EnrollmentStation
{
    partial class DlgChangeMode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgChangeMode));
            this.lblStatus = new MetroFramework.Controls.MetroLabel();
            this.grpChangeMode = new System.Windows.Forms.GroupBox();
            this.chkU2f = new MetroFramework.Controls.MetroCheckBox();
            this.chkCCID = new MetroFramework.Controls.MetroCheckBox();
            this.chkOTP = new MetroFramework.Controls.MetroCheckBox();
            this.cmdChange = new MetroFramework.Controls.MetroButton();
            this.grpChangeMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(12, 58);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(206, 46);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "lblStatus";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus.UseCustomBackColor = true;
            this.lblStatus.UseCustomForeColor = true;
            // 
            // grpChangeMode
            // 
            this.grpChangeMode.Controls.Add(this.chkU2f);
            this.grpChangeMode.Controls.Add(this.chkCCID);
            this.grpChangeMode.Controls.Add(this.chkOTP);
            this.grpChangeMode.Location = new System.Drawing.Point(12, 107);
            this.grpChangeMode.Name = "grpChangeMode";
            this.grpChangeMode.Size = new System.Drawing.Size(206, 92);
            this.grpChangeMode.TabIndex = 1;
            this.grpChangeMode.TabStop = false;
            this.grpChangeMode.Text = "Mode";
            // 
            // chkU2f
            // 
            this.chkU2f.AutoSize = true;
            this.chkU2f.Location = new System.Drawing.Point(21, 43);
            this.chkU2f.Name = "chkU2f";
            this.chkU2f.Size = new System.Drawing.Size(74, 15);
            this.chkU2f.TabIndex = 2;
            this.chkU2f.Text = "FIDO/U2F";
            this.chkU2f.UseSelectable = true;
            this.chkU2f.CheckedChanged += new System.EventHandler(this.checkBox_Changed);
            // 
            // chkCCID
            // 
            this.chkCCID.AutoCheck = false;
            this.chkCCID.AutoSize = true;
            this.chkCCID.Location = new System.Drawing.Point(21, 64);
            this.chkCCID.Name = "chkCCID";
            this.chkCCID.Size = new System.Drawing.Size(50, 15);
            this.chkCCID.TabIndex = 1;
            this.chkCCID.Text = "CCID";
            this.chkCCID.UseSelectable = true;
            this.chkCCID.CheckedChanged += new System.EventHandler(this.checkBox_Changed);
            // 
            // chkOTP
            // 
            this.chkOTP.AutoSize = true;
            this.chkOTP.Location = new System.Drawing.Point(21, 22);
            this.chkOTP.Name = "chkOTP";
            this.chkOTP.Size = new System.Drawing.Size(44, 15);
            this.chkOTP.TabIndex = 0;
            this.chkOTP.Text = "OTP";
            this.chkOTP.UseSelectable = true;
            this.chkOTP.CheckedChanged += new System.EventHandler(this.checkBox_Changed);
            // 
            // cmdChange
            // 
            this.cmdChange.Location = new System.Drawing.Point(143, 205);
            this.cmdChange.Name = "cmdChange";
            this.cmdChange.Size = new System.Drawing.Size(75, 23);
            this.cmdChange.TabIndex = 4;
            this.cmdChange.Text = "Change";
            this.cmdChange.UseSelectable = true;
            this.cmdChange.Click += new System.EventHandler(this.cmdChange_Click);
            // 
            // DlgChangeMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 237);
            this.Controls.Add(this.cmdChange);
            this.Controls.Add(this.grpChangeMode);
            this.Controls.Add(this.lblStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgChangeMode";
            this.Padding = new System.Windows.Forms.Padding(15, 60, 15, 16);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Mode";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DlgChangeMode_FormClosing);
            this.Load += new System.EventHandler(this.DlgChangeMode_Load);
            this.grpChangeMode.ResumeLayout(false);
            this.grpChangeMode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpChangeMode;
        private MetroFramework.Controls.MetroLabel lblStatus;
        private MetroFramework.Controls.MetroButton cmdChange;
        private MetroFramework.Controls.MetroCheckBox chkU2f;
        private MetroFramework.Controls.MetroCheckBox chkCCID;
        private MetroFramework.Controls.MetroCheckBox chkOTP;
    }
}
using System.ComponentModel;
using System.Windows.Forms;

namespace EnrollmentStation
{
    partial class DlgSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgSettings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAgentCert = new System.Windows.Forms.TextBox();
            this.llBrowseAgentCert = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCSREndpoint = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCaTemplate = new System.Windows.Forms.TextBox();
            this.llBrowseCA = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.llGenerateMgtKey = new System.Windows.Forms.LinkLabel();
            this.txtManagementKey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.drpAlgorithm = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.llDefaultMgtKey = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAgentCert);
            this.groupBox1.Controls.Add(this.llBrowseAgentCert);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCSREndpoint);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCaTemplate);
            this.groupBox1.Controls.Add(this.llBrowseCA);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 64);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(689, 116);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CA Settings";
            // 
            // txtAgentCert
            // 
            this.txtAgentCert.BackColor = System.Drawing.SystemColors.Control;
            this.txtAgentCert.Location = new System.Drawing.Point(157, 50);
            this.txtAgentCert.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAgentCert.Name = "txtAgentCert";
            this.txtAgentCert.ReadOnly = true;
            this.txtAgentCert.Size = new System.Drawing.Size(447, 22);
            this.txtAgentCert.TabIndex = 4;
            this.txtAgentCert.Validating += new System.ComponentModel.CancelEventHandler(this.txtAgentCert_Validating);
            // 
            // llBrowseAgentCert
            // 
            this.llBrowseAgentCert.AutoSize = true;
            this.llBrowseAgentCert.Location = new System.Drawing.Point(613, 55);
            this.llBrowseAgentCert.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llBrowseAgentCert.Name = "llBrowseAgentCert";
            this.llBrowseAgentCert.Size = new System.Drawing.Size(54, 17);
            this.llBrowseAgentCert.TabIndex = 5;
            this.llBrowseAgentCert.TabStop = true;
            this.llBrowseAgentCert.Text = "Browse";
            this.llBrowseAgentCert.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llBrowseAgentCert_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 55);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Agent certificate";
            // 
            // txtCSREndpoint
            // 
            this.txtCSREndpoint.Location = new System.Drawing.Point(157, 20);
            this.txtCSREndpoint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCSREndpoint.Name = "txtCSREndpoint";
            this.txtCSREndpoint.Size = new System.Drawing.Size(447, 22);
            this.txtCSREndpoint.TabIndex = 1;
            this.txtCSREndpoint.Validating += new System.ComponentModel.CancelEventHandler(this.txtCSREndpoint_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 86);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Cert template";
            // 
            // txtCaTemplate
            // 
            this.txtCaTemplate.Location = new System.Drawing.Point(157, 81);
            this.txtCaTemplate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCaTemplate.Name = "txtCaTemplate";
            this.txtCaTemplate.Size = new System.Drawing.Size(447, 22);
            this.txtCaTemplate.TabIndex = 7;
            this.txtCaTemplate.Text = "SmartcardLogon";
            this.txtCaTemplate.Validating += new System.ComponentModel.CancelEventHandler(this.txtCaTemplate_Validating);
            // 
            // llBrowseCA
            // 
            this.llBrowseCA.AutoSize = true;
            this.llBrowseCA.Location = new System.Drawing.Point(613, 25);
            this.llBrowseCA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llBrowseCA.Name = "llBrowseCA";
            this.llBrowseCA.Size = new System.Drawing.Size(54, 17);
            this.llBrowseCA.TabIndex = 2;
            this.llBrowseCA.TabStop = true;
            this.llBrowseCA.Text = "Browse";
            this.llBrowseCA.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llBrowseCA_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "CSR endpoint";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(497, 250);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(605, 250);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.llDefaultMgtKey);
            this.groupBox3.Controls.Add(this.llGenerateMgtKey);
            this.groupBox3.Controls.Add(this.txtManagementKey);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(16, 2);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(689, 54);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "YubiKey";
            // 
            // llGenerateMgtKey
            // 
            this.llGenerateMgtKey.AutoSize = true;
            this.llGenerateMgtKey.Location = new System.Drawing.Point(618, 29);
            this.llGenerateMgtKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llGenerateMgtKey.Name = "llGenerateMgtKey";
            this.llGenerateMgtKey.Size = new System.Drawing.Size(68, 17);
            this.llGenerateMgtKey.TabIndex = 4;
            this.llGenerateMgtKey.TabStop = true;
            this.llGenerateMgtKey.Text = "Generate";
            this.llGenerateMgtKey.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llGenerateMgtKey_LinkClicked);
            // 
            // txtManagementKey
            // 
            this.txtManagementKey.Location = new System.Drawing.Point(157, 20);
            this.txtManagementKey.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtManagementKey.MaxLength = 48;
            this.txtManagementKey.Name = "txtManagementKey";
            this.txtManagementKey.Size = new System.Drawing.Size(447, 22);
            this.txtManagementKey.TabIndex = 3;
            this.txtManagementKey.Validating += new System.ComponentModel.CancelEventHandler(this.txtManagementKey_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Management key";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.drpAlgorithm);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(16, 187);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(689, 55);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Card details";
            // 
            // drpAlgorithm
            // 
            this.drpAlgorithm.FormattingEnabled = true;
            this.drpAlgorithm.Location = new System.Drawing.Point(157, 21);
            this.drpAlgorithm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.drpAlgorithm.Name = "drpAlgorithm";
            this.drpAlgorithm.Size = new System.Drawing.Size(447, 24);
            this.drpAlgorithm.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Default algorithm";
            // 
            // llDefaultMgtKey
            // 
            this.llDefaultMgtKey.AutoSize = true;
            this.llDefaultMgtKey.Location = new System.Drawing.Point(618, 12);
            this.llDefaultMgtKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llDefaultMgtKey.Name = "llDefaultMgtKey";
            this.llDefaultMgtKey.Size = new System.Drawing.Size(53, 17);
            this.llDefaultMgtKey.TabIndex = 5;
            this.llDefaultMgtKey.TabStop = true;
            this.llDefaultMgtKey.Text = "Default";
            this.llDefaultMgtKey.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llDefaultMgtKey_LinkClicked);
            // 
            // DlgSettings
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(721, 290);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.DlgSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private LinkLabel llBrowseCA;
        private Label label1;
        private Button btnSave;
        private Button btnCancel;
        private TextBox txtCSREndpoint;
        private GroupBox groupBox3;
        private TextBox txtManagementKey;
        private Label label4;
        private TextBox txtAgentCert;
        private LinkLabel llBrowseAgentCert;
        private Label label3;
        private LinkLabel llGenerateMgtKey;
        private Label label5;
        private TextBox txtCaTemplate;
        private GroupBox groupBox2;
        private ComboBox drpAlgorithm;
        private Label label2;
        private LinkLabel llDefaultMgtKey;
    }
}
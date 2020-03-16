namespace EnrollmentStation
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.link_old_project = new MetroFramework.Controls.MetroLink();
            this.link_new_project = new MetroFramework.Controls.MetroLink();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.fechter_link = new MetroFramework.Controls.MetroLink();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(44, 76);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(0, 0);
            this.metroLabel1.TabIndex = 0;
            // 
            // link_old_project
            // 
            this.link_old_project.Location = new System.Drawing.Point(18, 161);
            this.link_old_project.Name = "link_old_project";
            this.link_old_project.Size = new System.Drawing.Size(252, 23);
            this.link_old_project.TabIndex = 3;
            this.link_old_project.Text = "https://github.com/CSIS/EnrollmentStation";
            this.link_old_project.UseSelectable = true;
            this.link_old_project.Click += new System.EventHandler(this.link_old_project_Click);
            // 
            // link_new_project
            // 
            this.link_new_project.Location = new System.Drawing.Point(18, 365);
            this.link_new_project.Name = "link_new_project";
            this.link_new_project.Size = new System.Drawing.Size(263, 23);
            this.link_new_project.TabIndex = 4;
            this.link_new_project.Text = "https://github.com/jnsgsbz/EnrollmentStation";
            this.link_new_project.UseSelectable = true;
            this.link_new_project.Click += new System.EventHandler(this.link_new_project_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(18, 63);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(429, 95);
            this.metroLabel2.TabIndex = 5;
            this.metroLabel2.Text = resources.GetString("metroLabel2.Text");
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(18, 201);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(244, 19);
            this.metroLabel3.TabIndex = 6;
            this.metroLabel3.Text = "Updated to YubiKey 5 by Jürgen Fechter";
            // 
            // fechter_link
            // 
            this.fechter_link.Location = new System.Drawing.Point(18, 223);
            this.fechter_link.Name = "fechter_link";
            this.fechter_link.Size = new System.Drawing.Size(277, 23);
            this.fechter_link.TabIndex = 7;
            this.fechter_link.Text = "https://github.com/scVENUS/EnrollmentStation";
            this.fechter_link.UseSelectable = true;
            this.fechter_link.Click += new System.EventHandler(this.fechter_link_Click);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(18, 267);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(349, 95);
            this.metroLabel4.TabIndex = 8;
            this.metroLabel4.Text = "Added the ability to enroll two certificates on one YubiKey.\r\nEncrypt the store a" +
    "nd settings file.\r\nNew metro style design.\r\n\r\nBy Dennis Rahmen and Jonas Gisbert" +
    "z";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "______________________________________________________";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(331, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "______________________________________________________";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 401);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.fechter_link);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.link_new_project);
            this.Controls.Add(this.link_old_project);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.Padding = new System.Windows.Forms.Padding(15, 60, 15, 16);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLink link_old_project;
        private MetroFramework.Controls.MetroLink link_new_project;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private MetroFramework.Controls.MetroLink fechter_link;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
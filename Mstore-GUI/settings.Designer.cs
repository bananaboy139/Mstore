using Mstore_Core_lib;
namespace Mstore_GUI
{
    partial class settings
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.PathLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ChangePathBtn = new System.Windows.Forms.Button();
            this.ShowPathLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PathLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(131, 95);
            this.panel1.TabIndex = 0;
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.PathLabel.Location = new System.Drawing.Point(0, 0);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(119, 15);
            this.PathLabel.TabIndex = 0;
            this.PathLabel.Text = "Path to Mstore folder";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ChangePathBtn);
            this.panel2.Controls.Add(this.ShowPathLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(131, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(409, 95);
            this.panel2.TabIndex = 1;
            // 
            // ChangePathBtn
            // 
            this.ChangePathBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.ChangePathBtn.Location = new System.Drawing.Point(0, 0);
            this.ChangePathBtn.Name = "ChangePathBtn";
            this.ChangePathBtn.Size = new System.Drawing.Size(409, 23);
            this.ChangePathBtn.TabIndex = 1;
            this.ChangePathBtn.Text = "Change Path";
            this.ChangePathBtn.UseVisualStyleBackColor = true;
            this.ChangePathBtn.Click += new System.EventHandler(this.ChangePathBtn_Click);
            // 
            // ShowPathLabel
            // 
            this.ShowPathLabel.AutoSize = true;
            this.ShowPathLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ShowPathLabel.Location = new System.Drawing.Point(0, 0);
            this.ShowPathLabel.Name = "ShowPathLabel";
            this.ShowPathLabel.Size = new System.Drawing.Size(0, 15);
            this.ShowPathLabel.TabIndex = 0;
            // 
            // settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 95);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "settings";
            this.Text = "settings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label PathLabel;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label ShowPathLabel;
        private System.Windows.Forms.Button ChangePathBtn;
    }
}
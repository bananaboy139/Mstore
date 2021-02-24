

namespace Mstore_GUI
{
    partial class window
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(window));
            this.SideBar = new System.Windows.Forms.Panel();
            this.RunButton = new System.Windows.Forms.Button();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.PakageName = new System.Windows.Forms.Panel();
            this.PakageNameLabel = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.SideBar.SuspendLayout();
            this.PakageName.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.InfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SideBar
            // 
            this.SideBar.Controls.Add(this.RunButton);
            this.SideBar.Controls.Add(this.DownloadButton);
            this.SideBar.Controls.Add(this.PakageName);
            this.SideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.SideBar.Location = new System.Drawing.Point(0, 0);
            this.SideBar.Name = "SideBar";
            this.SideBar.Size = new System.Drawing.Size(200, 636);
            this.SideBar.TabIndex = 0;
            // 
            // RunButton
            // 
            this.RunButton.BackColor = System.Drawing.Color.Gray;
            this.RunButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.RunButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(46)))));
            this.RunButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RunButton.ForeColor = System.Drawing.SystemColors.Control;
            this.RunButton.Location = new System.Drawing.Point(0, 134);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(200, 34);
            this.RunButton.TabIndex = 2;
            this.RunButton.Text = "Run";
            this.RunButton.UseVisualStyleBackColor = false;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // DownloadButton
            // 
            this.DownloadButton.BackColor = System.Drawing.Color.Gray;
            this.DownloadButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.DownloadButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(46)))));
            this.DownloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownloadButton.ForeColor = System.Drawing.SystemColors.Control;
            this.DownloadButton.Location = new System.Drawing.Point(0, 100);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(200, 34);
            this.DownloadButton.TabIndex = 1;
            this.DownloadButton.Text = "Download";
            this.DownloadButton.UseVisualStyleBackColor = false;
            // 
            // PakageName
            // 
            this.PakageName.Controls.Add(this.PakageNameLabel);
            this.PakageName.Dock = System.Windows.Forms.DockStyle.Top;
            this.PakageName.Location = new System.Drawing.Point(0, 0);
            this.PakageName.Name = "PakageName";
            this.PakageName.Size = new System.Drawing.Size(200, 100);
            this.PakageName.TabIndex = 0;
            // 
            // PakageNameLabel
            // 
            this.PakageNameLabel.AutoSize = true;
            this.PakageNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PakageNameLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.PakageNameLabel.Location = new System.Drawing.Point(0, 0);
            this.PakageNameLabel.Name = "PakageNameLabel";
            this.PakageNameLabel.Size = new System.Drawing.Size(57, 20);
            this.PakageNameLabel.TabIndex = 0;
            this.PakageNameLabel.Text = "Name:";
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.vScrollBar1);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MainPanel.Location = new System.Drawing.Point(200, 269);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1134, 367);
            this.MainPanel.TabIndex = 1;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar1.Location = new System.Drawing.Point(1117, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 367);
            this.vScrollBar1.TabIndex = 1;
            // 
            // InfoPanel
            // 
            this.InfoPanel.Controls.Add(this.DescriptionLabel);
            this.InfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfoPanel.Location = new System.Drawing.Point(200, 0);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(1134, 269);
            this.InfoPanel.TabIndex = 2;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DescriptionLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.DescriptionLabel.Location = new System.Drawing.Point(0, 0);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(99, 20);
            this.DescriptionLabel.TabIndex = 0;
            this.DescriptionLabel.Text = "Description: ";
            // 
            // window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(20)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(1334, 636);
            this.Controls.Add(this.InfoPanel);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.SideBar);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "window";
            this.Text = "Mstore";
            this.SideBar.ResumeLayout(false);
            this.PakageName.ResumeLayout(false);
            this.PakageName.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.InfoPanel.ResumeLayout(false);
            this.InfoPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SideBar;
        public System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.Panel PakageName;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.Label PakageNameLabel;
        private System.Windows.Forms.Panel InfoPanel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.VScrollBar vScrollBar1;
    }
}


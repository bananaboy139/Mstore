using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Mstore_Core_lib;
using System.Diagnostics;

namespace Mstore_GUI
{
    public partial class window : Form
    {
        public window()
        {
            InitializeComponent();
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            //TODO: run spelunky without taking the entire screen
            Program.current.Run();
        }


        private void DownloadButton_Click(object sender, EventArgs e)
        {
            if (!Program.current.IsInstalled)
            {
                Corelib Lib = new Corelib();
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                    wc.DownloadFileAsync(
                        // Param1 = Link of file
                        new System.Uri(Program.current.DownloadURL),
                        // Param2 = Path to save
                        Lib.path + Program.current.JName + ".zip"
                    );
                }

            }
        }
        // Event to track the progress
        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            DownloadProgress.Value = e.ProgressPercentage;
            if (DownloadProgress.Value == 100)
            {
                Program.current.Install();
                IsInstalled.Text = "Installed";
            }
        }

        private void Form1_FormClosing(System.Object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            Program.Export();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            Program.Export();
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            Program.Import();
        }

        private void OpenFolderBtn_Click(object sender, EventArgs e)
        {
            //TODO:fix access denied error
            Corelib lib = new Corelib();
            Process.Start(lib.path);
        }
    }
}

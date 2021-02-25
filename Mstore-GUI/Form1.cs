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
                    wc.DownloadFileAsync
                        (
                        new System.Uri(Program.current.DownloadURL), 
                        Lib.path + Program.current.JName + ".zip"
                        );
                }

            }
        }
        // Event to track the progress
        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            DownloadProgress.Value = e.ProgressPercentage;
            IsInstalled.ForeColor = System.Drawing.Color.Chartreuse;
            IsInstalled.Text = "Downloading";
            if (DownloadProgress.Value == 100)
            {
                Program.current.Install();
                IsInstalled.Text = Program.current.Name + " Installed";
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
            try
            {
                Process.Start(lib.path);
            }
            catch (System.ComponentModel.Win32Exception q)
            {
                lib.Write("     " + lib.path + "     ");
                lib.Write(q.Message);
            }
        }
        private void DeleteGameBtn_Click(object sender, EventArgs e)
        {
            Corelib lib = new Corelib();
            if (Program.current.IsInstalled)
            {
                Directory.Delete(lib.path + "Apps/" + Program.current.JName + "/", true);
                Program.current.IsInstalled = false;
                Program.UpdateIsInstalled();
            }
        }
    }
}

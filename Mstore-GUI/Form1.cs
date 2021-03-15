using Mstore_Core_lib;
using Pakagesn;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

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
            Program.current.Run();
        }

        public void Download(Pakage p)
        {
            if (!p.IsInstalled)
            {
                Corelib Lib = new Corelib();
                Program.Downloading = p;
                using (WebClient wc = new WebClient())
                {
                    wc.Credentials = new NetworkCredential(Program.Downloading.User, Program.Downloading.Password);
                    wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                    wc.DownloadFileAsync
                        (
                        new System.Uri(Program.Downloading.DownloadURL),
                        Lib.path + Program.Downloading.JName + ".zip"
                        );
                }
            }
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            Download(Program.current);
        }

        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            DownloadProgress.Value = e.ProgressPercentage;
            IsInstalled.ForeColor = System.Drawing.Color.Chartreuse;
            IsInstalled.Text = "Downloading";
            if (DownloadProgress.Value == 100)
            {
                Corelib lib = new Corelib();
                lib.Write("Download done" + Program.Downloading.Name);
                IsInstalled.Text = Program.Downloading.Name + "\nInstalling";
                Program.Downloading.Install();
                IsInstalled.Text = Program.Downloading.Name + "\nInstalled";
                lib.ExportList(Program.Pakages);
                DownloadProgress.Value = 0;
            }
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
            Corelib lib = new Corelib();
            try
            {
                Process.Start
                    (
                    Environment.GetEnvironmentVariable("WINDIR") + @"\explorer.exe",
                    Path.GetFullPath(lib.path + "pakages/")
                    );
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

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            CreatePakage p = new CreatePakage();
            p.Show();
        }

        private void InfoBtn_Click(object sender, EventArgs e)
        {
            MoreInfo m = new MoreInfo();
            m.Show();
        }

        private void window_FormClosing(Object sender, FormClosingEventArgs e)
        {
            Program.Export();
            Corelib lib = new Corelib();
            lib.Write("CLOSING");
        }

        private void ChangePathBtn_Click(object sender, EventArgs e)
        {
            settings s = new settings();
            Corelib lib = new Corelib();
            s.ShowPathLabel.Text = lib.path;
            s.Show();
        }

        public void DownloadAll(List<Pakage> Pakages)
        {
            foreach (Pakage p in Pakages)
            {
                if (!p.IsInstalled)
                {
                    Download(p);
                }
            }
        }

        private void DownloadAllBtn_Click(object sender, EventArgs e)
        {
            DownloadAll(Program.Pakages);
        }
    }
}
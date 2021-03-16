using Mstore_Core_lib;
using Pakagesn;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

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

        private async void DownloadButton_Click(object sender, EventArgs e)
        {
            await Download(Program.current);
        }
        private bool InUse = false;
        public async Task Download(Pakage p)
        {
            if (!p.IsInstalled)
            {
                InUse = true;
                Corelib Lib = new Corelib();
                Program.Downloading = p;
                using (WebClient wc = new WebClient())
                {
                    wc.Credentials = new NetworkCredential(Program.Downloading.User, Program.Downloading.Password);
                    wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                    wc.DownloadFileCompleted += wc_DownloadFinished;
                    await Task.Run(() => wc.DownloadFileAsync
                        (
                        new System.Uri(Program.Downloading.DownloadURL),
                        Lib.path + Program.Downloading.JName + ".zip"
                        ));
                }
            }
        }
        private void setIsInstalled()
        {
            IsInstalled.Text = Program.Downloading.Name + "\nInstalling";
        }
        private void SetIsInstalled()
        {
            IsInstalled.Text = Program.Downloading.Name + "\nInstalled";
        }
        
        private void wc_DownloadFinished(object sender, EventArgs e)
        {
            Corelib lib = new Corelib();
            lib.Write("Download done" + Program.Downloading.Name);
            Invoke(new Action(setIsInstalled));
            Program.Downloading.Install();
            Invoke(new Action(SetIsInstalled));
            lib.ExportList(Program.Pakages);
            InUse = false;
        }
        private DownloadProgressChangedEventArgs s;
        private void progress()
        {
            DownloadProgress.Value = s.ProgressPercentage;
            IsInstalled.ForeColor = System.Drawing.Color.Chartreuse;
            IsInstalled.Text = "Downloading";
        }
        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            s = e;
            Invoke(new Action(progress));
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

        private async void DownloadAllBtn_Click(object sender, EventArgs e)
        {
            foreach (Pakage p in Program.Pakages)
            {
                if (!p.IsInstalled)
                {
                    await Download(p);
                    InUse = true;
                    while (InUse)
                    {
                        await Task.Delay(1000);
                    }
                }
            }
        }
    }
}
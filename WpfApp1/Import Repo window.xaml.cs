using System;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Mstore_Core_lib;

namespace GUI
{
    public partial class Import_Repo_window : Window
    {
        string destinationFolder = Corelib.DownloadsFolder + "pakages/";
        string destinationFile = Corelib.DownloadsFolder + "pakages" + ".zip";

        public Import_Repo_window()
        {
            InitializeComponent();
        }

        private async void Download_Button_Click(object sender, RoutedEventArgs e)
        {
            string User = User_textbox.Text;
            string Pass = Password_textbox.Text;
            string URL = Link_Textbox.Text;


            WebClient WClient = new WebClient();
            WClient.Credentials = new NetworkCredential(User, Pass);
            WClient.DownloadFileCompleted += wc_DownloadFinished;
            WClient.DownloadProgressChanged += WClient_DownloadProgressChanged;
            await Task.Run(() => WClient.DownloadFileAsync(new System.Uri(URL), destinationFile));
        }

        private void WClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                progress_text.Text = e.ProgressPercentage.ToString();
                Download_text.Text = "Downloading";
            });

        }

        private void wc_DownloadFinished(object sender, EventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                Download_text.Text = "Installing";
            });
            
            Corelib.Write("finished downloading Pakages REPO");

            ZipFile.ExtractToDirectory(destinationFile, destinationFolder);
            Corelib.Write("Extract Complete of Pakages REPO");
            File.Delete(destinationFile);
            foreach (string s in Directory.GetFiles(destinationFolder))
            {
                try
                {
                    File.Move(s, Corelib.PakagesFolder + Path.GetFileName(s));
                }
                catch (IOException ex)
                {
                    Corelib.Write(ex.ToString());
                }
            }
            Corelib.ClearDownloadsFolder();
            Corelib.Write("pakages are added, finished");
            this.Dispatcher.Invoke(() =>
            {
                Download_text.Text = "Done!";
            });
        }
    }
}

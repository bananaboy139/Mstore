using Mstore_Core_lib;
using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using Notifications.Wpf;


namespace GUI
{
    public partial class Import_Repo_window : Window
    {
        private readonly string destinationFolder = Corelib.DownloadsFolder + "pakages/";
        private readonly string destinationFile = Corelib.DownloadsFolder + "pakages" + ".zip";
        private NotificationManager Notify = new NotificationManager();

        public Import_Repo_window()
        {
            InitializeComponent();
        }

        private async void Download_Button_Click(object sender, RoutedEventArgs e)
        {
            string User = User_textbox.Text;
            string Pass = Password_textbox.Text;
            string URL = Link_Textbox.Text;

            WebClient WClient = new();
            WClient.Credentials = new NetworkCredential(User, Pass);
            WClient.DownloadFileCompleted += Wc_DownloadFinished;
            WClient.DownloadProgressChanged += WClient_DownloadProgressChanged;
            try
            {
                await Task.Run(() => WClient.DownloadFileAsync(new System.Uri(URL), destinationFile));
            }
            catch (WebException ex)
            {
                Corelib.Write(ex.ToString());
                Notify.Show(new NotificationContent
                {
                    Title = "Download failed",
                    Type = NotificationType.Error
                });
            }
            
        }

        private void WClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                progress_text.Text = e.ProgressPercentage.ToString();
                Download_text.Text = "Downloading";
            });
        }

        private void Wc_DownloadFinished(object sender, EventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                Download_text.Text = "Installing";
            });

            Corelib.Write("finished downloading Pakages REPO");

            ZipFile.ExtractToDirectory(destinationFile, destinationFolder);
            Corelib.Write("Extract Complete of Pakages REPO");
            foreach (string s in Directory.GetFiles(destinationFolder, "*.json"))
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
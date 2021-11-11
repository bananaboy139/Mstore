using Mstore_Core_lib;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Shell;

namespace GUI
{
    public partial class MainWindow : Window
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            Closing += MainWindow_Closing;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //setup mstore
            Corelib.Setup();
            Corelib.Write("folder setup");
            Corelib.Import();
            Corelib.Write("inital import");
            AddButtons();
            Corelib.ClearDownloadsFolder();
            Corelib.Write("downloads cleared");
            if (Corelib.Current == null && Corelib.Pakages.Count > 0)
            {
                Corelib.Current = Corelib.Pakages[0];
                UpdateUI();
            }
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Corelib.ExportList();
        }

        public void AddButtons()
        {
            ButtonPanel.Children.Clear();
            foreach (Pakage p in Corelib.Pakages)
            {
                //< Button Content = "Button" Height = "33.275" Width = "558.557" HorizontalAlignment = "Center" DockPanel.Dock = "Top" Background = "#FF132857" />
                Button B = new()
                {
                    Height = 33.275,
                    Width = 558.557,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Background = new SolidColorBrush(Color.FromArgb(100, 19, 40, 87)),
                    Name = p.JName,
                    Content = p.Name
                };
                B.Click += new RoutedEventHandler(Click);
                DockPanel.SetDock(B, Dock.Top);
                ButtonPanel.Children.Add(B);
                ButtonPanel.UpdateLayout();
            }
        }

        private void Click(object sender, RoutedEventArgs s)
        {
            String name;
            if (sender is Button)
            {
                name = (sender as Button).Name;
                foreach (Pakage p in Corelib.Pakages)
                {
                    if (name == p.JName)
                    {
                        Corelib.Current = p;
                    }
                }
                UpdateUI();
            }
            else
            {
                Corelib.Write("ERROR: click event not from button");
            }
        }
        public void UpdateUI()
        {
            Description_textbox.Text = Corelib.Current.Description;
            Current_Name_Textbox.Text = Corelib.Current.Name;
            UpdateImage();
        }

        public void UpdateImage()
        {
            //Stream AppICON = Application.GetResourceStream(new Uri("/Mstore.ico")).Stream;
            ImageSource ICON = this.Icon;
            //System.Drawing.Icon Ico = new System.Drawing.Icon(AppICON);
            if (Corelib.Current.IsInstalled)
            {
                try
                {
                    var Ico = System.Drawing.Icon.ExtractAssociatedIcon(Corelib.AppsFolder + Corelib.Current.JName + "/" + Corelib.Current.exe);
                    IntPtr i = Ico.ToBitmap().GetHbitmap();
                    ICON = Imaging.CreateBitmapSourceFromHBitmap(
                        i,
                        IntPtr.Zero,
                        Int32Rect.Empty,
                        System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions()
                        );
                    DeleteObject(i);
                }
                catch (Exception e)
                {
                    Corelib.Write(e.ToString());
                }
            }
            EXE_Icon.Source = ICON;
        }

        private Button DownloadingBtn;


        private async void DownloadButtonClick(object sender, RoutedEventArgs s)
        {
            if (!Corelib.Current.IsInstalled)
            {
                Download_button.IsEnabled = false;
                Corelib.Downloading = Corelib.Current;
                Corelib.Write(Corelib.Downloading.ToString() + " start downloading");
                if (!Config.StorePass && Corelib.Current.User != "")
                {
                    if (Corelib.Current.User != null)
                    {
                        Credentials c = new();
                        c.ShowDialog();
                    }
                }
                foreach (Button B in ButtonPanel.Children)
                {
                    if (B.Name == Corelib.Downloading.JName)
                    {
                        DownloadingBtn = B;
                    }

                }

                await Download();
            }
        }

        private async Task Download()
        {
            WebClient WClient = new();
            WClient.Credentials = new NetworkCredential(Corelib.Downloading.User, Corelib.Downloading.Password);
            WClient.DownloadProgressChanged += Wc_DownloadProgressChanged;
            WClient.DownloadFileCompleted += Wc_DownloadFinished;
            TaskBarItemInfoMainWindow.ProgressState = TaskbarItemProgressState.Normal;
            try
            {
                await Task.Run(() => WClient.DownloadFileAsync
                    (
                    new System.Uri(Corelib.Downloading.DownloadURL),
                    Corelib.DownloadsFolder + Corelib.Downloading.JName + ".zip"
                    ));
                //TODO: "Download Started"
                DownloadStatusTextBox.Text = "Download Started";
            }
            catch (WebException ex)
            {
                Corelib.Write(ex.ToString());
                //TODO: "Download failed"
                DownloadStatusTextBox.Text = "Download failed";
            }

        }

        private DateTime _startedAt;

        private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (_startedAt == default)
            {
                _startedAt = DateTime.Now;
            }
            else
            {
                var timeSpan = DateTime.Now - _startedAt;
                if (timeSpan.TotalSeconds > 1)
                {
                    long bytesPerSecond = e.BytesReceived / (long)timeSpan.TotalSeconds;
                    long KBPerSec = bytesPerSecond / 1000;
                    var elapsedTime = timeSpan.TotalSeconds;
                    var allTimeFordownloading = (elapsedTime * e.TotalBytesToReceive / e.BytesReceived);
                    var remainingTime = allTimeFordownloading - elapsedTime;
                    TimeSpan time = TimeSpan.FromSeconds(remainingTime);

                    Dispatcher.Invoke(() =>
                    {
                        Download_button.Content = "Downloading " + "(" + KBPerSec.ToString() + " KB/sec)";
                        string remaining;
                        if (e.BytesReceived < 1024)
                        {
                            remaining = string.Format("{0}/{1} KBs", 
                                Math.Round(e.BytesReceived / 1024f), 
                                Math.Round(e.TotalBytesToReceive / 1024f));
                        }
                        else
                        {
                            remaining = string.Format("{0}/{1} MBs", 
                                (Math.Round((e.BytesReceived / 1024f) / 1024f)), 
                                Math.Round((e.TotalBytesToReceive / 1024f) / 1024f));
                        }
                        string ETA = string.Format("(ETA: {0}Mins, {1}Secs)", time.Minutes, time.Seconds);

                        double ProgressPerc = (double)e.ProgressPercentage / 100;
                        int ProgressPercINT = (int)(ProgressPerc * 100);
                        string dow = string.Format("{0} - {1}% {2} ({3})", Corelib.Downloading.Name, ProgressPercINT.ToString(), ETA, remaining);
                        DownloadingBtn.Content = dow;

                        TaskBarItemInfoMainWindow.ProgressValue = ProgressPerc;
                    });
                }
            }

        }

        private void Wc_DownloadFinished(object sender, EventArgs e)
        {
            Corelib.Write(Corelib.Downloading.ToString() + "finished downloading");

            this.Dispatcher.Invoke(() =>
            {
                DownloadingBtn.Content = Corelib.Downloading.Name;
                TaskBarItemInfoMainWindow.ProgressState = TaskbarItemProgressState.Paused;
                Download_button.Content = "Download app";
            });

            Corelib.Downloading.Install(Corelib.DownloadsFolder + Corelib.Downloading.JName + ".zip");

            this.Dispatcher.Invoke(() =>
            {
                TaskBarItemInfoMainWindow.ProgressState = TaskbarItemProgressState.None;
                //TODO: "Download Finished"
                DownloadStatusTextBox.Text = "Download Finished";

                Download_button.IsEnabled = true;
                UpdateImage();
            });
        }

        private void RunButtonClick(object sender, RoutedEventArgs s)
        {
            Corelib.Current.Run();
        }

        private void OpenRepoButtonClick(object sender, RoutedEventArgs s)
        {
            try
            {
                Process.Start
                    (
                    Environment.GetEnvironmentVariable("WINDIR") + @"\explorer.exe",
                    Path.GetFullPath(Corelib.PakagesFolder)
                    );
            }
            catch (System.ComponentModel.Win32Exception q)
            {
                Corelib.Write("     " + Corelib.PakagesFolder + "     ");
                Corelib.Write(q.Message);
            }
        }

        private void ImportButtonClicked(object sender, RoutedEventArgs s)
        {
            Corelib.Write("Import button clicked");
            Corelib.Import();
            AddButtons();
            Corelib.Write("Import button clicked - finished");
        }

        private void ImportRepository(object sender, RoutedEventArgs s)
        {
            Import_Repo_window w = new();
            w.Closing += Repo_window_Closing;
            w.Show();
        }

        private void Repo_window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Corelib.Import();
            AddButtons();
        }

        private void SettingsClick(object sender, RoutedEventArgs s)
        {
            Settings w = new();
            w.Show();
        }

        private void DeleteClicked(object sender, RoutedEventArgs s)
        {
            if (Corelib.Current.IsInstalled)
            {
                TaskBarItemInfoMainWindow.ProgressState = TaskbarItemProgressState.Paused;
                string Shortcut = Corelib.StartFolder + Corelib.Current.Name + ".lnk";
                File.Delete(Shortcut);
                Directory.Delete(Path.Combine(Corelib.AppsFolder, Corelib.Current.JName), true);
                TaskBarItemInfoMainWindow.ProgressState = TaskbarItemProgressState.None;
                Corelib.Current.IsInstalled = false;
                UpdateImage();
            }
        }

        private void CreatePButton_Click(object sender, RoutedEventArgs e)
        {
            CreatePakage p = new();
            p.Closed += P_Closed;
            p.Show();
        }

        private void P_Closed(object sender, EventArgs e)
        {
            AddButtons();
        }

        private void Export_Button_Click(object sender, RoutedEventArgs e)
        {
            Corelib.ExportList();
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            CreatePakage p = new();
            p.Loaded += p.P_Loaded;
            p.Closed += P_Closed;
            p.Show();
        }

        private void HelpBtn_Click(object sender, RoutedEventArgs e)
        {
            Help h = new();
            h.Show();
        }

        private void ButtonPanel_Drop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string f in files)
            {
                switch (Path.GetExtension(f))
                {
                    case ".json":
                        Corelib.ImportF(f);
                        AddButtons();
                        break;

                    case ".zip":
                        string folder = Corelib.DownloadsFolder + Path.GetFileName(f);
                        ZipFile.ExtractToDirectory(f, folder);
                        foreach (string s in Directory.GetFiles(folder, "*.json"))
                        {
                            try
                            {
                                Corelib.ImportF(s);
                                AddButtons();
                            }
                            catch (IOException ex)
                            {
                                Corelib.Write(ex.ToString());
                            }
                        }
                        Corelib.ClearDownloadsFolder();
                        break;
                }
            }
            Corelib.ExportList();
            //TODO: "Import Finished"
            DownloadStatusTextBox.Text = "Import Finished";
        }

        private void Remake_Shortcut_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (Corelib.Current.IsInstalled)
            {
                if (File.Exists(Corelib.StartFolder + Corelib.Current.Name + ".lnk")) 
                {
                    File.Delete(Corelib.StartFolder + Corelib.Current.Name + ".lnk");
                }
                try 
                {
                    Corelib.Current.CreateShortcut();
                }
                catch (Exception ex)
                {
                    Corelib.Write(ex.Message);
                }
                
            }
        }
    }
}
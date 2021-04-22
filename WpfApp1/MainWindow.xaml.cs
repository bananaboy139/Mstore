using Mstore_Core_lib;
using Notifications.Wpf;
using System;
using System.Diagnostics;
using System.IO;
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

        private NotificationManager Notify = new NotificationManager();

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
                Button B = new Button()
                {
                    Height = 33.275,
                    Width = 558.557,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 19, 40, 87)),
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
                Description_textbox.Text = Corelib.Current.Description;
                Current_Name_Textbox.Text = Corelib.Current.Name;
                UpdateImage();
            }
            else
            {
                Corelib.Write("ERROR: click event not from button");
            }
        }

        public void UpdateImage()
        {
            if (Corelib.Current.IsInstalled)
            {
                System.Drawing.Icon Ico = System.Drawing.Icon.ExtractAssociatedIcon(Corelib.AppsFolder + Corelib.Current.JName + "/" + Corelib.Current.exe);
                IntPtr i = Ico.ToBitmap().GetHbitmap();

                using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(1000, 1000))
                {
                    try
                    {
                        var ICON = Imaging.CreateBitmapSourceFromHBitmap(
                            i,
                            IntPtr.Zero,
                            Int32Rect.Empty,
                            System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions()
                            );
                        EXE_Icon.Source = ICON;
                    }
                    finally
                    {
                        DeleteObject(i);
                    }
                }
            }
            else
            {
                //FIXME: EXE_Icon.Source = GET RESOURCE APP ICON
                EXE_Icon.Source = null;
            }
        }

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
                        Credentials c = new Credentials();
                        c.ShowDialog();
                    }
                }

                await Download();
            }
        }

        private async Task Download()
        {
            WebClient WClient = new WebClient();
            WClient.Credentials = new NetworkCredential(Corelib.Downloading.User, Corelib.Downloading.Password);
            WClient.DownloadProgressChanged += wc_DownloadProgressChanged;
            WClient.DownloadFileCompleted += wc_DownloadFinished;
            TaskBarItemInfoMainWindow.ProgressState = TaskbarItemProgressState.Normal;

            await Task.Run(() => WClient.DownloadFileAsync
                (
                new System.Uri(Corelib.Downloading.DownloadURL),
                Corelib.DownloadsFolder + Corelib.Downloading.JName + ".zip"
                ));
            Notify.Show(new NotificationContent
            {
                Title = "Download Started",
                Type = NotificationType.Information
            });
        }

        private DateTime _startedAt;

        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (_startedAt == default(DateTime))
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
                    Dispatcher.Invoke(() =>
                    {
                        Download_button.Content = "Downloading " + KBPerSec.ToString() + " KB/sec";
                    });
                }
            }
            this.Dispatcher.Invoke(() =>
            {
                TaskBarItemInfoMainWindow.ProgressValue = (double)e.ProgressPercentage / 100;
            });
        }

        private void wc_DownloadFinished(object sender, EventArgs e)
        {
            Corelib.Write(Corelib.Downloading.ToString() + "finished downloading");

            this.Dispatcher.Invoke(() =>
            {
                TaskBarItemInfoMainWindow.ProgressState = TaskbarItemProgressState.Paused;
                Download_button.Content = "Download app";
            });

            Corelib.Downloading.Install(Corelib.DownloadsFolder + Corelib.Downloading.JName + ".zip");

            this.Dispatcher.Invoke(() =>
            {
                TaskBarItemInfoMainWindow.ProgressState = TaskbarItemProgressState.None;
                Notify.Show(new NotificationContent
                {
                    Title = "Download Finished",
                    Type = NotificationType.Success
                });
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
            Import_Repo_window w = new Import_Repo_window();
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
            Settings w = new Settings();
            w.Show();
        }

        private void DeleteClicked(object sender, RoutedEventArgs s)
        {
            if (Corelib.Current.IsInstalled)
            {
                TaskBarItemInfoMainWindow.ProgressState = TaskbarItemProgressState.Paused;
                string Shortcut = Corelib.StartFolder + Corelib.Current.Name + ".url";
                File.Delete(Shortcut);
                Directory.Delete(Path.Combine(Corelib.AppsFolder, Corelib.Current.JName), true);
                TaskBarItemInfoMainWindow.ProgressState = TaskbarItemProgressState.None;
                Corelib.Current.IsInstalled = false;
                UpdateImage();
            }
        }

        private void CreatePButton_Click(object sender, RoutedEventArgs e)
        {
            CreatePakage p = new CreatePakage();
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
    }
}
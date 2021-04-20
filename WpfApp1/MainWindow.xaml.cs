using Mstore_Core_lib;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shell;
using System.Windows.Controls;
using System.Windows.Media;
using System.Diagnostics;

namespace GUI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            Closing += MainWindow_Closing;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //import settings
            ImportSettings();
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
            ExportSettings();
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
                Description_textbox.Text = Corelib.Current.Description;
                //Fixme: Error CS0103  The name 'Current_Name_Textbox' does not exist in the current context Mstore GUI WPF  C: \Users\matte\Documents\Code\Mstore\WpfApp1\MainWindow.xaml.cs 54  Active
                Current_Name_Textbox.Text = Corelib.Current.Name;
                //Program.UpdateIsInstalled();
                if (Corelib.Current.IsInstalled)
                {
                    //FixME: EXE_Icon.Source = Icon.ExtractAssociatedIcon(Corelib.Current.exepath);
                }
                else
                {
                    //FIXME: EXE_Icon.Source = GET RESOURCE APP ICON
                }
            }
            else
            {
                Corelib.Write("ERROR: click event not from button");
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
                    Credentials c = new Credentials();
                    c.ShowDialog();
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
        }

        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //fixme: not working
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
            });
            Corelib.Downloading.Install(Corelib.DownloadsFolder + Corelib.Downloading.JName + ".zip");
            this.Dispatcher.Invoke(() =>
            {
                TaskBarItemInfoMainWindow.ProgressState = TaskbarItemProgressState.None;
                Download_button.IsEnabled = true;
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
            }
        }

        public void ImportSettings()
        {
            if (ConfigurationManager.AppSettings.Get("StorePass") != null)
            {
                //Config.StorePass = bool.Parse(ConfigurationManager.AppSettings.Get("StorePass"));
            }
            else
            {
                ExportSettings();
            }
        }

        public void ExportSettings()
        {
            //ConfigurationManager.AppSettings.Set("StorePass", Config.StorePass.ToString());
        }
    }
}
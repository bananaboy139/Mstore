using Mstore_Core_lib;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
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
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //setup mstore
            Corelib.FolderSetup();
            Corelib.Write("folder setup");
            Corelib.Import();
            Corelib.Write("inital import");
            AddButtons();
            Corelib.ClearDownloadsFolder();
            Corelib.Write("downloads cleared");
        }

        public void AddButtons()
        {
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
                Button_Dock.Children.Add(B);
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
                Corelib.Downloading = Corelib.Current;
                Corelib.Write(Corelib.Downloading.ToString() + " start downloading");
                //FIXME: download async with download bar
                await Download();
            }
        }

        private async Task Download()
        {
            WebClient WClient = new WebClient();
            WClient.Credentials = new NetworkCredential(Corelib.Downloading.User, Corelib.Downloading.Password);
            WClient.DownloadProgressChanged += wc_DownloadProgressChanged;
            WClient.DownloadFileCompleted += wc_DownloadFinished;
            await Task.Run(() => WClient.DownloadFileAsync
                (
                new System.Uri(Corelib.Downloading.DownloadURL),
                Corelib.DownloadsFolder + Corelib.Downloading.JName + ".zip"
                ));
        }

        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double p = e.ProgressPercentage;
            TaskbarItemInfo.ProgressValue = p;
        }

        private void wc_DownloadFinished(object sender, EventArgs e)
        {
            Corelib.Write(Corelib.Downloading.ToString() + "finished downloading");
            TaskbarItemInfo.ProgressState = System.Windows.Shell.TaskbarItemProgressState.None;
            Corelib.Downloading.Install(Corelib.DownloadsFolder + Corelib.Downloading.JName + ".zip");
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

        }
    }
}
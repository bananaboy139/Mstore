using Mstore_Core_lib;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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

        private void DownloadButtonClick(object sender, RoutedEventArgs s)
        {
            if (!Corelib.Current.IsInstalled)
            {
                Corelib.Downloading = Corelib.Current;
                Corelib.Write(Corelib.Downloading.ToString() + " start downloading");
                //FIXME: download async with download bar
            }
        }

        private void RunButtonClick(object sender, RoutedEventArgs s)
        {
            Corelib.Current.Run();
        }
    }
}
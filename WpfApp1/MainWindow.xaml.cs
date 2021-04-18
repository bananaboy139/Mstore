using System;
using System.IO;

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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Mstore_Core_lib;

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
    }
}

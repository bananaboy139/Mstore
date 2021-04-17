using System;
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
            //< Button Content = "Button" Height = "33.275" Width = "558.557" HorizontalAlignment = "Center" DockPanel.Dock = "Top" Background = "#FF132857" />
            Button B = new Button()
            {
                Height = 33.275,
                Width = 558.557,
                HorizontalAlignment = HorizontalAlignment.Center,
                Background = new SolidColorBrush(Color.FromArgb(100, 19, 40, 87))
            };
            DockPanel.SetDock(B, Dock.Top);
            Button_Dock.Children.Add(B);

        }
    }
}

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
using System.Windows.Shapes;
using Mstore_Core_lib;
namespace GUI
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
            Closing += Settings_Closing;
            Loaded += Settings_Loaded;
        }

        private void Settings_Loaded(object sender, RoutedEventArgs e)
        {
            Store_Pass_check.IsChecked = Config.StorePass;
        }

        private void Settings_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Config.StorePass = (bool)Store_Pass_check.IsChecked;
        }
    }
}

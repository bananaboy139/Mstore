using Mstore_Core_lib;
using System.IO;
using System.Windows;

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
            Store_Encrypted_check.IsChecked = Config.StoreSecured;
        }

        private void Settings_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Config.StorePass = (bool)Store_Pass_check.IsChecked;
            Config.StoreSecured = (bool)Store_Encrypted_check.IsChecked;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            File.Delete(Corelib.LogFile);
            File.Create(Corelib.LogFile);
        }
    }
}
using Mstore_Core_lib;
using System.Windows;

namespace GUI
{
    /// <summary>
    /// Interaction logic for Credentials.xaml
    /// </summary>
    public partial class Credentials : Window
    {
        public Credentials()
        {
            InitializeComponent();
            Loaded += Credentials_Loaded;
            Closing += Credentials_Closing;
        }

        private void Credentials_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Corelib.Current.User = User_box.Text;
            Corelib.Current.Password = Pass_box.Password;
        }

        private void Credentials_Loaded(object sender, RoutedEventArgs e)
        {
            User_box.Text = Corelib.Current.User;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
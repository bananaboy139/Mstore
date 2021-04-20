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
            Corelib.Current.Password = Pass_box.Text;
        }

        private void Credentials_Loaded(object sender, RoutedEventArgs e)
        {
            User_box.Text = Corelib.Current.User;
        }
    }
}

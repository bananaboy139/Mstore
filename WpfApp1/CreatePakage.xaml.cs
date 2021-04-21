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
    /// Interaction logic for CreatePakage.xaml
    /// </summary>
    public partial class CreatePakage : Window
    {
        public CreatePakage()
        {
            InitializeComponent();
            Closing += CreatePakage_Closing;
        }

        private void CreatePakage_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Pakage p = new Pakage()
            {
                Name = NameBox.Text,
                DownloadURL = URLBox.Text,
                Description = DescriptionBox.Text.Replace("{n}", Environment.NewLine),
                JName = JNameBox.Text,
                exe = EXEBox.Text,
                args = ArgsBox.Text,
                User = UserBox.Text,
                Password = PassBox.Text
            };
            Corelib.Pakages.Add(p);
            Corelib.ExportList();
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

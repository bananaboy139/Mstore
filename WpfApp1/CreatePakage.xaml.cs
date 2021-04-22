using Mstore_Core_lib;
using System;
using System.Windows;

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
                Password = PassBox.Password
            };
            Corelib.Pakages.Add(p);
            Corelib.ExportList();
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
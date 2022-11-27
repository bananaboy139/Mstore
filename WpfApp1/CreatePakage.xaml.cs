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
        private bool Editing = false;
        private void CreatePakage_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Editing)
            {
                Pakage p = new()
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
            }
            else
            {
                Corelib.Current.Name = NameBox.Text;
                Corelib.Current.DownloadURL = URLBox.Text;
                Corelib.Current.Description = DescriptionBox.Text.Replace("{n}", Environment.NewLine);
                Corelib.Current.JName = JNameBox.Text;
                Corelib.Current.exe = EXEBox.Text;
                Corelib.Current.args = ArgsBox.Text;
                Corelib.Current.User = UserBox.Text;
                Corelib.Current.User = UserBox.Text;
                Corelib.Current.Password = PassBox.Password;
            }
            Corelib.ExportList();
        }

        public void P_Loaded(object sender, RoutedEventArgs e)
        {
            Editing = true;
            //only if editing
            NameBox.Text = Corelib.Current.Name;
            URLBox.Text = Corelib.Current.DownloadURL;
            DescriptionBox.Text = Corelib.Current.Description.Replace(Environment.NewLine, "{n}");
            JNameBox.Text = Corelib.Current.JName;
            EXEBox.Text = Corelib.Current.exe;
            ArgsBox.Text = Corelib.Current.args;
            UserBox.Text = Corelib.Current.User;
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
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

namespace CharityApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// collin was here
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            //this.Loaded += Window_Loaded; // check the database

        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var data = new CharityApplication.Data();
            bool isConnected = data.TestConnection();

            if (!isConnected)
            {
                MessageBox.Show("Failed to connect to the database.");
            }
            else { MessageBox.Show("Connected to the database."); }
        }

      
        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to SignUpChoose page
            mainFrame.Navigate(new Uri("SignUpChoose.xaml", UriKind.Relative));
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Uri("MainPageAdmin.xaml", UriKind.Relative));
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}

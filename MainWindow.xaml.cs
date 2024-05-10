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
using System.Windows.Markup;
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
        private Data data;
        public MainWindow()
        {
            InitializeComponent();
            //this.Loaded += Window_Loaded; // check the database
            data = new Data();
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
            string email = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            Admin admin = data.GetAdminByEmail(email);
            Donator donator = data.GetDonatorByEmail(email);

            
            Organisation organisation = data.GetOrganizationByEmail(email);
            
            if (admin != null && admin.Password == password)  
            {
                
                
                mainFrame.Navigate(new Uri("MainPageAdmin.xaml", UriKind.Relative));
            }
            else if(donator != null && donator.Password == password)
            {
                UserSession.Instance.SetCurrentUser(donator);
                mainFrame.Navigate(new Uri("HomePageUser.xaml", UriKind.Relative));
            }
            else if (organisation != null && organisation.Password == password)
            {
                OrganisationSession.Instance.SetCurrentOrganisation(organisation);
                mainFrame.Navigate(new Uri("HomePageOrganisation.xaml", UriKind.Relative));
            }
            else  // Passwords do not match
            {
                ResultTextBlock.Text = "Invalid password. Please try again.";
            }
            
        }

        //mainFrame.Navigate(new Uri("MainPageAdmin.xaml", UriKind.Relative));
    
        
        private void UsernameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // If the default text is present, clear it
            if (UsernameTextBox.Text == "Email")
            {
                UsernameTextBox.Text = "";
            }
        }

        private void UsernameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // If there's no text after losing focus, set the placeholder
            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text))
            {
                UsernameTextBox.Text = "Email";
            }
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Hide the placeholder when there's text in the PasswordBox
            if (PasswordBox.Password.Length > 0)
            {
                PasswordPlaceholder.Visibility = Visibility.Collapsed;
            }
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Hide the placeholder when PasswordBox is focused
            PasswordPlaceholder.Visibility = Visibility.Collapsed;
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Show the placeholder if the PasswordBox is empty after losing focus
            if (PasswordBox.Password.Length == 0)
            {
                PasswordPlaceholder.Visibility = Visibility.Visible;
            }
        }
    }
}

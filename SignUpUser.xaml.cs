using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace CharityApplication
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SignUpUser : Page
    {
        public SignUpUser()
        {
            InitializeComponent();
        }
        private void SignUpUserButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName = NameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;
            // Check if any required field is empty
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            if (!IsValidPassword(password))
            {
                MessageBox.Show("Password must be at least 8 characters long and contain both letters and numbers.");
                return; 
            }
            if (password != confirmPassword)
            {
                MessageBox.Show("Password and confirm password do not match. Please try again.");
                return; 
            }
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Invalid email address format. Please enter a valid email address.");
                return; 
            }

            // Passwords match, continue with registration process
            Donator newDonator = new Donator(firstName, lastName, email, password);

            // Insert the new Donator into the database
            Data dataAccess = new Data();

            // Check if the email already exists
            if (dataAccess.DoesEmailExist(email))
            {
                MessageBox.Show("An account with this email already exists. Please use a different email.");
                return;
            }
            bool success = dataAccess.InsertDonator(newDonator);

            if (success)
            {
                
                MessageBox.Show("Registration successful!");

                
                UserSession.Instance.SetCurrentUser(newDonator);

                signUpUserFrame.Navigate(new Uri("HomePageUser.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Registration failed. Please try again.");
            }
        }

        private bool IsValidPassword(string password)
        {
            // Regular expression pattern to validate password (at least 8 characters, contains letters and numbers)
            string pattern = @"^(?=.*[A-Za-z])(?=.*\d).{8,}$";
            return System.Text.RegularExpressions.Regex.IsMatch(password, pattern);
        }
        private bool IsValidEmail(string email)
        {
          
            return email.Contains("@") && email.Split('@')[1].Contains(".");
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            signUpUserFrame.Navigate(new Uri("SignUpChoose.xaml", UriKind.Relative));
        }
    }
}

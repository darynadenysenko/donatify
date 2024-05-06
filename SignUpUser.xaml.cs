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

            // Check if password and confirm password match
            if (password != confirmPassword)
            {
                MessageBox.Show("Password and confirm password do not match. Please try again.");
                return; // Stop registration process
            }

            // Passwords match, continue with registration process
            Donator newDonator = new Donator
            {
                Name = firstName,
                LastName = lastName,
                Email = email,
                Password = password // You may want to hash the password before storing it in the database
            };


            // Insert the new Donator into the database
            Data dataAccess = new Data();
            int insertedDonatorId = dataAccess.InsertDonator(newDonator);

            if (insertedDonatorId != -1)
            {
                MessageBox.Show("Registration successful! ");
                signUpUserFrame.Navigate(new Uri("HomePageUser.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Registration failed. Please try again.");
            }
        }

    
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            signUpUserFrame.Navigate(new Uri("SignUpChoose.xaml", UriKind.Relative));
        }
    }
}

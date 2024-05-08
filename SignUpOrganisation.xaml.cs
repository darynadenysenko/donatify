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
    /// Interaction logic for SignUpOrganisation.xaml
    /// </summary>
    public partial class SignUpOrganisation : Page
    {
        public SignUpOrganisation()
        {
            InitializeComponent();
            var types = Enum.GetValues(typeof(Types)).Cast<Types>();
            TypeComboBox.ItemsSource = types;
        }
        private void SignUpOrgButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            Types type = (Types)TypeComboBox.SelectedItem; // Modified this line

            string mission = MissionTextBox.Text;
            string phone = PhoneTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Password;
            string confirmPassword = ConfirmPasswordTextBox.Password;
            // Check if password and confirm password match
            if (password != confirmPassword)
            {
                MessageBox.Show("Password and confirm password do not match. Please try again.");
                return; // Stop registration process
            }

            // Passwords match, continue with registration process
            Organisation newOrganisation = new Organisation
            {
                Name = name,
                Type = type, // Modified this line
                Mission = mission,
                Phone = phone,
                Email = email,
                Password = password // You may want to hash the password before storing it in the database
            };

            // Insert the new Organisation into the database
            Data dataAccess = new Data();
            bool success = dataAccess.InsertOrganisation(newOrganisation);

            if (success)
            {
                MessageBox.Show("Registration successful! ");
                signUpOrgFrame.Navigate(new Uri("HomePageOrganisation.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Registration failed. Please try again.");
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            signUpOrgFrame.Navigate(new Uri("SignUpChoose.xaml", UriKind.Relative));
        }

    }
}

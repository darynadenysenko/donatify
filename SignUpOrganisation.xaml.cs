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
            Types type = (Types)TypeComboBox.SelectedItem; 

            string mission = MissionTextBox.Text;
            string phone = PhoneTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Password;
            string confirmPassword = ConfirmPasswordTextBox.Password;
            // Check if any required field is empty
            if (string.IsNullOrWhiteSpace(mission) || string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(type.ToString()))
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
            Organisation newOrganisation = new Organisation
            {
                Name = name,
                Type = type,
                Mission = mission,
                Phone = phone,
                Email = email,
                Password = password
            };

           
            Data dataAccess = new Data();
            if (dataAccess.DoesOrgEmailExist(email))
            {
                MessageBox.Show("An account with this email already exists. Please use a different email.");
                return;
            }
            bool success = dataAccess.InsertOrganisation(newOrganisation);

            if (success)
            {
                MessageBox.Show("Registration successful! ");
                Organisation currentOrganisation = dataAccess.GetOrganizationByEmail(email);
                OrganisationSession.Instance.SetCurrentOrganisation(currentOrganisation);
                signUpOrgFrame.Navigate(new Uri("HomePageOrganisation.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Registration failed. Please try again.");
            }
        }
        private bool IsValidPassword(string password)
        {
            
            string pattern = @"^(?=.*[A-Za-z])(?=.*\d).{8,}$";
            return System.Text.RegularExpressions.Regex.IsMatch(password, pattern);
        }
        private bool IsValidEmail(string email)
        {

            return email.Contains("@") && email.Split('@')[1].Contains(".");
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            signUpOrgFrame.Navigate(new Uri("SignUpChoose.xaml", UriKind.Relative));
        }

    }
}

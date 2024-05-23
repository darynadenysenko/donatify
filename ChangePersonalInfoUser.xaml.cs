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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CharityApplication
{
    /// <summary>
    /// Interaction logic for ChangePersonalInfoUser.xaml
    /// </summary>
    public partial class ChangePersonalInfoUser : Page
    {
        public ChangePersonalInfoUser()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = UserSession.Instance.CurrentUser;
            bool isUpdated = false;

            if (!string.IsNullOrWhiteSpace(NameTextBox.Text) && NameTextBox.Text != currentUser.Name)
            {
                currentUser.Name = NameTextBox.Text;
                isUpdated = true;
            }

            if (!string.IsNullOrWhiteSpace(LastNameTextBox.Text) && LastNameTextBox.Text != currentUser.LastName)
            {
                currentUser.LastName = LastNameTextBox.Text;
                isUpdated = true;
            }

            if (!string.IsNullOrWhiteSpace(EmailTextBox.Text) && EmailTextBox.Text != currentUser.Email)
            {
                currentUser.Email = EmailTextBox.Text;
                isUpdated = true;
                if (!IsValidEmail(EmailTextBox.Text))
                {
                    MessageBox.Show("Invalid email address format. Please enter a valid email address.");
                    return;
                }
            }
            


            if (isUpdated)
            {
                Data dataAccess = new Data();
                bool success = dataAccess.UpdateUserInfo(currentUser);

                if (success)
                {
                    MessageBox.Show("User information updated successfully!");
                    ChangeInfoUserFrame.Navigate(new Uri("ProfileSettingsUser.xaml", UriKind.Relative));
                }
                else
                {
                    MessageBox.Show("Failed to update user information. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("No changes detected to update.");
            }
        }
        private bool IsValidEmail(string email)
        {

            return email.Contains("@") && email.Split('@')[1].Contains(".");
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            ChangeInfoUserFrame.Navigate(new Uri("ProfileSettingsUser.xaml", UriKind.Relative));
        }
    }
}
  
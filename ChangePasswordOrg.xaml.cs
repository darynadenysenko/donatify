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
    /// Interaction logic for ChangePasswordOrg.xaml
    /// </summary>
    public partial class ChangePasswordOrg : Page
    {
        public ChangePasswordOrg()
        {
            InitializeComponent();
        }
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string oldPassword = CurrentPassword.Password;
            string newPassword = NewPassword.Password;
            string confirmNewPassword = ConfirmPassword.Password;

            var currentOrganisation = OrganisationSession.Instance.CurrentOrganisation;
            int OrgId = OrganisationSession.Instance.CurrentOrganisation.OrganizationID;

            string currentPassword = OrganisationSession.Instance.CurrentOrganisation.Password;

            if (oldPassword == currentPassword)
            {
                if (newPassword == confirmNewPassword)
                {
                    Data dataAccess = new Data();
                    bool success = dataAccess.UpdateOrganisationPassword(OrgId, newPassword);

                    if (success)
                    {
                        currentOrganisation.Password = newPassword;
                        MessageBox.Show("Password changed successfully!");
                        ChangePasswordOrgFrame.Navigate(new Uri("ProfileSettingsOrganisation.xaml", UriKind.Relative));

                    }
                    else
                    {
                        MessageBox.Show("Failed to update password. Please try again.");
                    }
                }
                else
                {
                    MessageBox.Show("New password and confirm new password do not match.");
                }
            }
            else
            {
                MessageBox.Show("Old password is incorrect.");
            }

        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordOrgFrame.Navigate(new Uri("ProfileSettingsOrganisation.xaml", UriKind.Relative));

        }
    }
}

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
    /// Interaction logic for ChangeOrgInfo.xaml
    /// </summary>
    public partial class ChangeOrgInfo : Page
    {
        public ChangeOrgInfo()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            var currentOrganisation = OrganisationSession.Instance.CurrentOrganisation;
            if (!string.IsNullOrWhiteSpace(Name.Text))
            {
                currentOrganisation.Name = Name.Text;
            }

            if (!string.IsNullOrWhiteSpace(Email.Text))
            {
                currentOrganisation.Email = Email.Text;
                if (!IsValidEmail(Email.Text))
                {
                    MessageBox.Show("Invalid email address format. Please enter a valid email address.");
                    return;
                }
            }

            if (!string.IsNullOrWhiteSpace(Phone.Text))
            {
                currentOrganisation.Phone = Phone.Text;
                if (Phone.Text.Length < 10)
                {
                    MessageBox.Show("Invalid phone number. Please enter a valid phone number.");
                    return;
                }
            }

            if (!string.IsNullOrWhiteSpace(Mission.Text))
            {
                currentOrganisation.Mission = Mission.Text;
            }
            

            Data dataAccess = new Data();
            bool success = dataAccess.UpdateOrganisationInfo(currentOrganisation);

            if (success)
            {
                MessageBox.Show("Organization information updated successfully!");
                ChangeInfoOrgFrame.Navigate(new Uri("ProfileSettingsOrganisation.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Failed to update organization information. Please try again.");
            }
        }
        private bool IsValidEmail(string email)
        {

            return email.Contains("@") && email.Split('@')[1].Contains(".");
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            ChangeInfoOrgFrame.Navigate(new Uri("ProfileSettingsOrganisation.xaml", UriKind.Relative));
        }
    }
}

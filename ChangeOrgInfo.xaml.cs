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
            currentOrganisation.Name = Name.Text;
            currentOrganisation.Email = Email.Text;
            currentOrganisation.Phone = Phone.Text;
            currentOrganisation.Mission = Mission.Text;
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
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            ChangeInfoOrgFrame.Navigate(new Uri("ProfileSettingsOrganisation.xaml", UriKind.Relative));
        }
    }
}

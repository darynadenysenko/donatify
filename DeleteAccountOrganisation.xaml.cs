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
    /// Interaction logic for DeleteAccountOrganisation.xaml
    /// </summary>
    public partial class DeleteAccountOrganisation : Page
    {
        public DeleteAccountOrganisation()
        {
            InitializeComponent();
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string password = Password.Password;
            var currentOrganisation = OrganisationSession.Instance.CurrentOrganisation;

            int orgId = currentOrganisation.OrganizationID;
            string currentPassword = "";
            Data data = new Data();
            string sessionType = data.GetCurrentSessionType();
            if (sessionType == "Admin")
            {
                currentPassword = AdminSession.Instance.CurrentAdmin.Password;
            }
            else if (sessionType == "Organisation")
            {
                currentPassword = OrganisationSession.Instance.CurrentOrganisation.Password;
            }

            if (password == currentPassword)
            {
                Data dataAccess = new Data();
                bool eventsDeleted = dataAccess.DeleteEventsByOrganisationId(orgId);

                if (eventsDeleted)
                {
                    bool organisationDeleted = dataAccess.DeleteOrganisationAccount(orgId);

                    if (organisationDeleted)
                    {
                        MessageBox.Show("Account deleted successfully!");
                        if (sessionType == "Organisation")
                        {
                            // Navigate to the main window after account deletion
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            Window.GetWindow(this).Close();
                        }
                        else if (sessionType == "Admin")
                        {
                            DeleteAccountOrgFrame.Navigate(new Uri("ListOfOrganizationsAdmin.xaml", UriKind.Relative));
                        }

                    }
                    else
                    {
                        MessageBox.Show("Failed to delete account. Please try again.");
                    }
                }
                else
                {
                    MessageBox.Show("Failed to delete events. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("Incorrect password. Please try again.");
            }
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            DeleteAccountOrgFrame.Navigate(new Uri("ProfileSettingsOrganisation.xaml", UriKind.Relative));

        }
    }
}

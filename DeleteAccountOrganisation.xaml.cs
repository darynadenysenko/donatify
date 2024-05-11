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
            int orgId = OrganisationSession.Instance.CurrentOrganisation.OrganizationID;
            string currentPassword = OrganisationSession.Instance.CurrentOrganisation.Password;

            if (password == currentPassword)
            {
                Data dataAccess = new Data();
                bool success = dataAccess.DeleteOrganisationAccount(orgId);

                if (success)
                {
                    MessageBox.Show("Account deleted successfully!");



                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Window.GetWindow(this).Close();
                }
                else
                {
                    MessageBox.Show("Failed to delete account. Please try again.");
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

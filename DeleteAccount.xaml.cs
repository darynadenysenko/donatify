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
    /// Interaction logic for DeleteAccount.xaml
    /// </summary>
    public partial class DeleteAccount : Page
    {
        public DeleteAccount()
        {
            InitializeComponent();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string password = Password.Password;
            int userId = UserSession.Instance.CurrentUser.UserID;
            Data data = new Data();
            string currentPassword = "";
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
                bool success = dataAccess.DeleteUserAccount(userId); 

                if (success)
                {

                    MessageBox.Show("Account deleted successfully!");
                   
                    if (sessionType == "Donator")
                    {
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        Window.GetWindow(this).Close();
                    }
                    else if (sessionType == "Admin")
                    {
                        DeleteAccountFrame.Navigate(new Uri("ListOfUsersAdmin.xaml",UriKind.Relative));
                    }
                    
                    
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
            DeleteAccountFrame.Navigate(new Uri("ProfileSettingsUser.xaml", UriKind.Relative));

        }
    }
}

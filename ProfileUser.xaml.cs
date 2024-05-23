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
    /// Interaction logic for ProfileUser.xaml
    /// </summary>
    public partial class ProfileUser : Page
    {
        public ProfileUser()
        {
            InitializeComponent();
            var currentUser = UserSession.Instance.CurrentUser;

            if (currentUser != null)
            {
                userName.Text = $"{currentUser.Name} {currentUser.LastName}";
                userEmail.Text= currentUser.Email;
            }
            else
            {
                userName.Text = "No user logged in";
            }
        }
        private void ProfileSettingsUser_Click(object sender, RoutedEventArgs e)
        {

            HomeUserFrame.Navigate(new Uri("ProfileSettingsUser.xaml", UriKind.Relative));

        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Data data = new Data();
            string currentSession = data.GetCurrentSessionType();
            if (currentSession == "Donator")
            {
                HomeUserFrame.Navigate(new Uri("HomePageUser.xaml", UriKind.Relative));
            }
            else
            {
                HomeUserFrame.Navigate(new Uri("ListOfUsersAdmin.xaml", UriKind.Relative));
            }

            
            
        }
        private void DonationHistory_Click(object sender, RoutedEventArgs e)
        {
            HomeUserFrame.Navigate(new Uri("DonationHistory.xaml", UriKind.Relative));
        }


    }
}

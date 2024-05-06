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
        }
        private void ProfileSettingsUser_Click(object sender, RoutedEventArgs e)
        {

            HomeUserFrame.Navigate(new Uri("ProfileSettingsUser.xaml", UriKind.Relative));

        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {

            HomeUserFrame.Navigate(new Uri("HomePageUser.xaml", UriKind.Relative));
            //if (NavigationService.CanGoBack)
            //{
            //    NavigationService.GoBack();
            //}
        }
        private void UpdateUserLabel()
        {
            Donator currentUser = UserSession.Instance.CurrentUser;

            if (currentUser != null)
            {
                userNameLabel.Content = $"{currentUser.Name} {currentUser.LastName}";
            }
            else
            {
                userNameLabel.Content = "No user logged in";
            }
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateUserLabel(); // Update the label with the current user's info
        }
    }
}

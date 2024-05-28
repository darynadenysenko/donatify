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
    /// Interaction logic for ProfileSettingsUser.xaml
    /// </summary>
    public partial class ProfileSettingsUser : Page
    {
        public ProfileSettingsUser()
        {
            InitializeComponent();
        }

        private void PersonalInfoChange_Click(object sender, RoutedEventArgs e)
        {
            ProfileSettingsUserFrame.Navigate(new Uri("ChangePersonalInfoUser.xaml", UriKind.Relative));
        }

        private void PasswordChangeButton_Click(object sender, RoutedEventArgs e)
        {
            ProfileSettingsUserFrame.Navigate(new Uri("ChangePasswordUser.xaml", UriKind.Relative));

        }

        private void DeleteAccountButton_Click(object sender, RoutedEventArgs e)
        {
            ProfileSettingsUserFrame.Navigate(new Uri("DeleteAccount.xaml", UriKind.Relative));

        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            ProfileSettingsUserFrame.Navigate(new Uri("ProfileUser.xaml", UriKind.Relative));

        }

    }
}

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
    /// Interaction logic for ProfileSettingsOrganisation.xaml
    /// </summary>
    public partial class ProfileSettingsOrganisation : Page
    {
        public ProfileSettingsOrganisation()
        {
            InitializeComponent();
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            ProfileSettingsOrgFrame.Navigate(new Uri("ProfileOrganisation.xaml", UriKind.Relative));

        }
        private void CompanyInfoChange_Click(object sender, RoutedEventArgs e)
        {
            ProfileSettingsOrgFrame.Navigate(new Uri("ChangeOrgInfo.xaml", UriKind.Relative));

        }
        private void PasswordChangeButton_Click(object sender, RoutedEventArgs e)
        {
            ProfileSettingsOrgFrame.Navigate(new Uri("ChangePasswordOrg.xaml", UriKind.Relative));

        }
        private void DeleteAccountButton_Click(object sender, RoutedEventArgs e)
        {
            ProfileSettingsOrgFrame.Navigate(new Uri("DeleteAccount.xaml", UriKind.Relative));

        }
    }
}

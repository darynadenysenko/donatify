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
    /// Interaction logic for ProfileOrganisation.xaml
    /// </summary>
    public partial class ProfileOrganisation : Page
    {
        public ProfileOrganisation()
        {
            InitializeComponent();
            var currentOrganisation = OrganisationSession.Instance.CurrentOrganisation;
            if (currentOrganisation != null)
            {
                userName.Content = currentOrganisation.Name;
                Email.Content= currentOrganisation.Email;
                PhoneNumber.Content = currentOrganisation.Phone;
                Type.Content = currentOrganisation.Type;
                Mission.Content = currentOrganisation.Mission;

            }
            else
            {
                userName.Content = "No user logged in";
            }
        }
        private void ProfileSettingsOrg_Click(object sender, RoutedEventArgs e)
        {
          HomeOrgFrame.Navigate(new Uri("ProfileSettingsOrganisation.xaml", UriKind.Relative));
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            HomeOrgFrame.Navigate(new Uri("HomePageOrganisation.xaml", UriKind.Relative));
        }
    }
}

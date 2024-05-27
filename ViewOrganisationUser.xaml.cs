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
    /// Interaction logic for ViewOrganisationUser.xaml
    /// </summary>
    public partial class ViewOrganisationUser : Page
    {
        private Organisation organisation;

        public ViewOrganisationUser(Organisation organisation)
        {
            InitializeComponent();
            this.organisation = organisation;
            DisplayOrganisationDetails();
        }

        private void DisplayOrganisationDetails()
        {
            userName.Content = organisation.Name;
            Email.Content = organisation.Email;
            PhoneNumber.Content = organisation.Phone;
            Type.Content = organisation.Type.ToString();
            Mission.Content = organisation.Mission;
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Data data = new Data();
            string currentSession = data.GetCurrentSessionType();
            if (currentSession == "Donator" )
            {
                ViewOrgFrame.Navigate(new Uri("HomePageUser.xaml", UriKind.Relative));
            }
            else if (currentSession == "Organisation")
            {
                ViewOrgFrame.Navigate(new Uri("HomePageOrganisation.xaml", UriKind.Relative));
            }
           
        }
        private void ViewEvents_Click(object sender, RoutedEventArgs e)
        {
            Data data = new Data();
            string currentSession = data.GetCurrentSessionType();
            if (currentSession == "Donator")
            {
                ViewOrgFrame.Navigate(new ViewEventsUser(organisation));
            }
            else if (currentSession == "Organisation")
            {
                ViewOrgFrame.Navigate(new ViewEventsOrg(organisation));
            }
           
        }
    }
}

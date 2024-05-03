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
    /// Interaction logic for HomePageOrganisation.xaml
    /// </summary>
    public partial class HomePageOrganisation : Page
    {
        public HomePageOrganisation()
        {
            InitializeComponent();
        }
        private void ProfileOrgButton_Click(object sender, RoutedEventArgs e)
        {

            HomeOrgFrame.Navigate(new Uri("ProfileOrganisation.xaml", UriKind.Relative));

        }
        private void EventsOrg_Click(object sender, RoutedEventArgs e)
        {

            HomeOrgFrame.Navigate(new Uri("EventPageOrg.xaml", UriKind.Relative));

        }

    }
}

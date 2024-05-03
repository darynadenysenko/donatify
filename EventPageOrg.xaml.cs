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
    /// Interaction logic for EventPageOrg.xaml
    /// </summary>
    public partial class EventPageOrg : Page
    {
        public EventPageOrg()
        {
            InitializeComponent();
        }
        private void AddEvent_Click(object sender, RoutedEventArgs e)
        {
            EventsOrgFrame.Navigate(new Uri("AddEvent.xaml", UriKind.Relative));

        }
        private void EventSettings_Click(object sender, RoutedEventArgs e)
        {
            EventsOrgFrame.Navigate(new Uri("EventSettings.xaml", UriKind.Relative));

        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            EventsOrgFrame.Navigate(new Uri("HomePageOrganisation.xaml", UriKind.Relative));

        }
    }
}

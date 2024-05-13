using Microsoft.Extensions.Logging;
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
    /// Interaction logic for EventSettings.xaml
    /// </summary>
    public partial class EventSettings : Page
    {
        private int selectedEventId;

      

        public EventSettings()
        {
            InitializeComponent();
            
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Set the SelectedEventId property here, for example, if you have access to the data or navigation parameter
            // For demonstration, let's directly set it to a value passed from the EventPageOrg
            if (NavigationService.Content is EventPageOrg eventPageOrg)
            {
                selectedEventId = eventPageOrg.SelectedEventId;
            }
        }

        private void EventSettings_Click(object sender, RoutedEventArgs e)
        {
            eventSettingsFrame.Navigate(new Uri("ChangeEventInfo.xaml", UriKind.Relative));

        }
        private void DeleteEvent_Click(object sender, RoutedEventArgs e)
        {
            eventSettingsFrame.Navigate(new Uri("DeleteEvent.xaml", UriKind.Relative));
        }
       
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            eventSettingsFrame.Navigate(new Uri("EventPageOrg.xaml", UriKind.Relative));

        }
    }
}

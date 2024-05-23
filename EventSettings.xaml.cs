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
        
        
        private Event selectedEvent;

      


        public EventSettings(Event ev)
        {
            InitializeComponent();
            this.selectedEvent = ev;

        }
       
        private void EventSettings_Click(object sender, RoutedEventArgs e)
        {
            ChangeEventInfo changeEventInfoPage = new ChangeEventInfo(selectedEvent);
            eventSettingsFrame.Navigate(changeEventInfoPage);

        }
        private void DeleteEvent_Click(object sender, RoutedEventArgs e)
        {
            DeleteEvent deleteEvent = new DeleteEvent(selectedEvent);
           eventSettingsFrame.Navigate(deleteEvent);
        }
       
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Data data = new Data();
            string currentSession = data.GetCurrentSessionType();
            if (currentSession == "Organisation")
            {
                eventSettingsFrame.Navigate(new Uri("EventPageOrg.xaml", UriKind.Relative));

            }
            else if (currentSession == "Admin")
            {
                EventInfoAdmin eventInfoPage = new EventInfoAdmin(selectedEvent);
                eventSettingsFrame.Navigate(eventInfoPage);
            }

        }
    }
}

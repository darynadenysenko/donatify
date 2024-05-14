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
    /// Interaction logic for EventInfoAdmin.xaml
    /// </summary>
    public partial class EventInfoAdmin : Page
    {
        private Event selectedEvent;

        public EventInfoAdmin(Event ev)
        {
            InitializeComponent();
            this.selectedEvent = ev;
            PopulateEventDetails();
        }

        private void PopulateEventDetails()
        {
            // Populate the UI elements with event details
            eventNameTextBlock.Text = selectedEvent.Name;
            eventDatesTextBlock.Text = $"{selectedEvent.StartDate} - {selectedEvent.EndDate}";
            eventDescriptionTextBlock.Content = selectedEvent.Description;
            // Populate other details as needed
        }
        private void SettingsEventAdmin_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to EventSettings page and pass the selected event
            EventSettings eventSettingsPage = new EventSettings(selectedEvent);
            NavigationService.Navigate(eventSettingsPage);
        }

    }
}

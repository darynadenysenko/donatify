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
            
            eventNameTextBlock.Text = selectedEvent.Name;
            eventDatesTextBlock.Text = $"{DateOnly.FromDateTime(selectedEvent.StartDate)} - {DateOnly.FromDateTime(selectedEvent.EndDate)}";
            eventDescriptionTextBlock.Content = selectedEvent.Description;
            amountTextBlock.Text = $"{selectedEvent.CurrentAmountRaised} €";
            
        }
        private void SettingsEventAdmin_Click(object sender, RoutedEventArgs e)
        {
            
            EventSettings eventSettingsPage = new EventSettings(selectedEvent);
            EventInfoAdminFrame.Navigate(eventSettingsPage);
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            EventInfoAdminFrame.Navigate(new Uri("ListOfEventsAdmin.xaml", UriKind.Relative));
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            LoadEvents();
        }

        private void LoadEvents()
        {
            var currentOrganisation = OrganisationSession.Instance.CurrentOrganisation;
            Data dataAccess = new Data();
            List<Event> events = dataAccess.GetOrgEvents(currentOrganisation);



            // Create a Label with a Button for each event and add it to the StackPanel
            foreach (var evt in events)
            {
                StackPanel eventContainer = new StackPanel();
                eventContainer.Orientation = Orientation.Vertical;
                eventContainer.HorizontalAlignment = HorizontalAlignment.Stretch;
                eventContainer.VerticalAlignment = VerticalAlignment.Stretch;

                // Create and configure the TextBlock
                TextBlock textBlock = new TextBlock();
                textBlock.Background = Brushes.White;
                textBlock.Margin = new Thickness(10, 0, 10, 0);
                textBlock.Height = 200;
                textBlock.Text = evt.Name + "\n\n" + DateOnly.FromDateTime(evt.StartDate) + " - " + DateOnly.FromDateTime(evt.EndDate) + "\n\n" + evt.Description;
                textBlock.TextWrapping = TextWrapping.Wrap;
                textBlock.Width = 200; // Allow the TextBlock to stretch horizontally
                textBlock.HorizontalAlignment = HorizontalAlignment.Stretch; // Allow the TextBlock to stretch horizontally
                textBlock.Height = double.NaN; // Allow the TextBlock to stretch vertically
                textBlock.VerticalAlignment = VerticalAlignment.Stretch;
                textBlock.TextAlignment = TextAlignment.Center;
                textBlock.FontFamily = new FontFamily(new Uri("pack://application:,,,/CharityApplication;component/"), "./Font/#Julius Sans One");
                textBlock.FontSize = 18;

                // Create and configure the Button
                Button button = new Button();
                button.Content = "Settings";
                button.Click += (sender, e) => ShowEventInfo(evt); //EventSettings_Click(sender, e, evt); // Pass the event to the click event handler
                button.Background = Brushes.White;
                button.FontFamily = new FontFamily(new Uri("pack://application:,,,/CharityApplication;component/"), "./Font/#Julius Sans One");
                button.FontSize = 18;
                button.Height = 33;
                button.Width = 100;
                button.BorderBrush = Brushes.Transparent;

                // Add the TextBlock and Button to the container
                eventContainer.Children.Add(textBlock);
                eventContainer.Children.Add(button);

                // Add the container (containing TextBlock and Button) to the eventsStackPanel
                eventsStackPanel.Children.Add(eventContainer);
            }
        }
        private void ShowEventInfo(Event ev)
        {
            // Navigate to EventInfoAdmin page and pass event details
            EventSettings eventSettingsPage = new EventSettings(ev);
            NavigationService.Navigate(eventSettingsPage);
        }

        private void AddEvent_Click(object sender, RoutedEventArgs e)
        {
            EventsOrgFrame.Navigate(new Uri("AddEvent.xaml", UriKind.Relative));

        }
        private void EventSettings_Click(object sender, RoutedEventArgs e, Event selectedEvent/*int eventId*/)
        {
            EventSettings eventSettingsPage = new EventSettings(selectedEvent); // Pass the selected event object
            NavigationService.Navigate(eventSettingsPage);
            //   selectedEventId = eventId;
            //    EventsOrgFrame.Navigate(new EventSettings(eventId));


        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            EventsOrgFrame.Navigate(new Uri("HomePageOrganisation.xaml", UriKind.Relative));

        }
    }
}
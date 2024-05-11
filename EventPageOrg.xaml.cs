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
        private int selectedEventId;
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
                Label label = new Label();
                label.Background = Brushes.White;
                label.HorizontalAlignment = HorizontalAlignment.Stretch;
                label.Margin = new Thickness(10, 0, 10, 0);
                label.VerticalAlignment = VerticalAlignment.Stretch;
                label.HorizontalContentAlignment = HorizontalAlignment.Center;
                label.VerticalContentAlignment = VerticalAlignment.Bottom;
                label.Height = 100;


                Button button = new Button();
                button.Content = "Settings";
                button.Click += (sender, e) => EventSettings_Click(sender, e, evt.EventId); // Pass the event to the click event handler
                button.Background = Brushes.White;
                button.FontFamily = new FontFamily("Font/#Julius Sans One");
                button.FontSize = 18;
                button.Height = 33;
                button.Width = 137;
                button.BorderBrush = Brushes.Transparent;

                
                label.Content = evt.Name +"\n"+ evt.Description +"\n";
                label.Content = button;
                

                eventsStackPanel.Children.Add(label);
            }
        }
        
        private void AddEvent_Click(object sender, RoutedEventArgs e)
        {
            EventsOrgFrame.Navigate(new Uri("AddEvent.xaml", UriKind.Relative));

        }
        private void EventSettings_Click(object sender, RoutedEventArgs e, int eventId)
        {
            selectedEventId = eventId;
            EventsOrgFrame.Navigate(new Uri("EventSettings.xaml", UriKind.Relative));
            NavigationService.Navigate(new ChangeEventInfo(selectedEventId));


        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            EventsOrgFrame.Navigate(new Uri("HomePageOrganisation.xaml", UriKind.Relative));

        }
    }
}

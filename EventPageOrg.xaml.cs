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


            DateTime currentDate = DateTime.Now;
            // Create a Label with a Button for each event and add it to the StackPanel
            foreach (var evt in events)
            {
                if (evt.EndDate >= currentDate)
                {
                    // Create a border for the event
                    Border eventBorder = new Border();
                    eventBorder.Background = Brushes.White;
                    eventBorder.BorderBrush = Brushes.LightGray;
                    eventBorder.BorderThickness = new Thickness(1);
                    eventBorder.CornerRadius = new CornerRadius(10);
                    eventBorder.Padding = new Thickness(10);
                    eventBorder.Margin = new Thickness(10);
                    eventBorder.Width = 300; 
                    eventBorder.Height = 250;
                   
                    StackPanel eventPanel = new StackPanel();
                    eventPanel.Orientation = Orientation.Vertical;

                    // Create and configure the TextBlock for event information
                    TextBlock textBlock = new TextBlock();
                    textBlock.Text = $"Event: {evt.Name}\n\nDate: {DateOnly.FromDateTime(evt.StartDate)} - {DateOnly.FromDateTime(evt.EndDate)}\n\nCurrent amount: {evt.CurrentAmountRaised}€\n\nDescription: {evt.Description}";
                    textBlock.TextWrapping = TextWrapping.Wrap;
                    textBlock.FontFamily = new FontFamily(new Uri("pack://application:,,,/CharityApplication;component/"), "./Font/#Julius Sans One");
                    textBlock.FontSize = 18;
                    textBlock.TextAlignment = TextAlignment.Center;
                    textBlock.Background = Brushes.White;

                    // Create a ScrollViewer for event information
                    ScrollViewer scrollViewer = new ScrollViewer();
                    scrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                    scrollViewer.Content = textBlock;
                    scrollViewer.Height = 180;

                    // Create and configure the Button for event settings
                    Button button = new Button();
                    button.Content = "Settings";
                    button.Click += (sender, e) => ShowEventInfo(evt);
                    button.Margin = new Thickness(0, 10, 0, 0);
                    button.Background = Brushes.Black;
                    button.Foreground = Brushes.White;
                    button.FontFamily = new FontFamily(new Uri("pack://application:,,,/CharityApplication;component/"), "./Font/#Julius Sans One");
                    button.FontSize = 18;
                    button.Height = 33;
                    button.Width = 100;
                    button.BorderBrush = Brushes.Transparent;

                    // Add the ScrollViewer and Button to the eventPanel
                    eventPanel.Children.Add(scrollViewer);
                    eventPanel.Children.Add(button);

                    // Set the StackPanel as the content of the eventBorder
                    eventBorder.Child = eventPanel;

                    // Add the eventBorder to the eventsWrapPanel
                    eventsWrapPanel.Children.Add(eventBorder);
                }
            }
        }
        private void ShowEventInfo(Event ev)
        {
            // Navigate to EventInfoAdmin page and pass event details
            EventSettings eventSettingsPage = new EventSettings(ev);
            EventsOrgFrame.Navigate(eventSettingsPage);
        }

        private void AddEvent_Click(object sender, RoutedEventArgs e)
        {
            EventsOrgFrame.Navigate(new Uri("AddEvent.xaml", UriKind.Relative));

        }
        private void EventSettings_Click(object sender, RoutedEventArgs e, Event selectedEvent/*int eventId*/)
        {
            EventSettings eventSettingsPage = new EventSettings(selectedEvent); // Pass the selected event object
            EventsOrgFrame.Navigate(eventSettingsPage);
            //   selectedEventId = eventId;
            //    EventsOrgFrame.Navigate(new EventSettings(eventId));


        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            EventsOrgFrame.Navigate(new Uri("HomePageOrganisation.xaml", UriKind.Relative));

        }
    }
}
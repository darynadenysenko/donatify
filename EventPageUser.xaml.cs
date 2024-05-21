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
    /// Interaction logic for EventPageUser.xaml
    /// </summary>
    public partial class EventPageUser : Page
    {
        public EventPageUser()
        {
            InitializeComponent();
            LoadEvents();
        }

        private void Donate_Click(object sender, RoutedEventArgs e, int eventId)
        {
            EventsUserFrame.Navigate(new Uri("DonateForEvent.xaml", UriKind.Relative));

        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            EventsUserFrame.Navigate(new Uri("HomePageUser.xaml", UriKind.Relative));

        }
        private void LoadEvents()
        {

            //var currentUser = UserSession.Instance.CurrentUser;
            Data dataAccess = new Data();
            List<Event> events = dataAccess.GetAllEvents();



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
                textBlock.Height = 100;
                textBlock.Text = evt.Name + "\n\n" + evt.StartDate + "-" + evt.EndDate + "\n\n" + evt.Description;
                textBlock.TextWrapping = TextWrapping.Wrap;
                textBlock.Width = 100; // Allow the TextBlock to stretch horizontally
                textBlock.HorizontalAlignment = HorizontalAlignment.Stretch; // Allow the TextBlock to stretch horizontally
                textBlock.Height = double.NaN; // Allow the TextBlock to stretch vertically
                textBlock.VerticalAlignment = VerticalAlignment.Stretch;
                textBlock.FontFamily = new FontFamily(new Uri("pack://application:,,,/CharityApplication;component/"), "./Font/#Julius Sans One");
                textBlock.TextAlignment = TextAlignment.Center;

                // Create and configure the Button
                Button button = new Button();
                button.Content = "Donate";
                button.Click += (sender, e) => ShowDonatePage(evt); // Pass the event to the click event handler
                button.Background = Brushes.White;
                button.FontFamily = new FontFamily(new Uri("pack://application:,,,/CharityApplication;component/"), "./Font/#Julius Sans One");
                button.FontSize = 18;
                button.Height = 33;
                button.Width = 100;
                button.BorderBrush = Brushes.Transparent;
                button.HorizontalContentAlignment = HorizontalAlignment.Center;
                button.VerticalContentAlignment = VerticalAlignment.Center;

                // Add the TextBlock and Button to the container
                eventContainer.Children.Add(textBlock);
                eventContainer.Children.Add(button);

                // Add the container (containing TextBlock and Button) to the eventsStackPanel
                eventsStackPanel.Children.Add(eventContainer);
            }
        }

    
        private void ShowDonatePage(Event ev)
        {
            // Navigate to EventInfoAdmin page and pass event details
            DonateForEvent donatePage = new DonateForEvent(ev);
            NavigationService.Navigate(donatePage);
        }
    }
}

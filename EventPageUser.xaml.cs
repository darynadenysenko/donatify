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
           
            Data dataAccess = new Data();
            List<Event> events = dataAccess.GetAllEvents();



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
                label.Width = 300;
                label.Height = 100;
                label.Content = evt.Name + "\n" + evt.Description + "\n";


                Button button = new Button();
                button.Content = "Donate";
                button.Click += (sender, e) => ShowDonatePage(evt); // Pass the event to the click event handler
                button.Background = Brushes.White;
                button.FontFamily = new FontFamily("Font/#Julius Sans One");
                button.FontSize = 18;
                button.Height = 33;
                button.Width = 137;
                button.BorderBrush = Brushes.Transparent;


                //label.Content = evt.Name +"\n"+ evt.Description +"\n";
                label.Content = button;


                eventsStackPanel.Children.Add(label);
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

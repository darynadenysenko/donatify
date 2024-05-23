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
    /// Interaction logic for ListOfEventsAdmin.xaml
    /// </summary>
    public partial class ListOfEventsAdmin : Page
    {
        private List<Event> events;
        public ListOfEventsAdmin()
        {
            InitializeComponent();
            Data data = new Data();
            this.events = data.FetchEventsFromDatabase();
            PopulateEvents(events);
        }
        private void PopulateEvents(List<Event> events)
        {
            eventsWrapPanel.Children.Clear();
            if (events.Count == 0)
            {
                NoEventsTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                NoEventsTextBlock.Visibility = Visibility.Collapsed;
                foreach (var ev in events)
                {
                    Button button = new Button();
                    button.Content = ev.Name;
                    button.FontFamily = new FontFamily(new Uri("pack://application:,,,/CharityApplication;component/"), "./Font/#Julius Sans One");
                    button.FontSize = 22;
                    button.Padding = new Thickness(10, 10, 10, 10);
                    button.Margin = new Thickness(0, 5, 0, 0);
                    button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B8B1AB"));
                    button.Foreground = Brushes.Black;
                    button.BorderThickness = new Thickness(1);
                    button.BorderBrush = Brushes.Gray;
                    button.HorizontalContentAlignment = HorizontalAlignment.Center;
                    button.VerticalContentAlignment = VerticalAlignment.Center;
                    button.HorizontalAlignment = HorizontalAlignment.Center;
                    button.Height = 70;
                    button.Width = 1500;
                    button.Click += (sender, e) => ShowEventInfo(ev);
                    eventsWrapPanel.Children.Add(button);
                }
            }
        }
        private void ShowEventInfo(Event ev)
        {
            // Navigate to EventInfoAdmin page and pass event details
            EventInfoAdmin eventInfoPage = new EventInfoAdmin(ev);
            ListOfEventsFrame.Navigate(eventInfoPage);
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            ListOfEventsFrame.Navigate(new Uri("MainPageAdmin.xaml", UriKind.Relative));
        }
        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {

            if (SearchTextBox.Text == "Search")
            {
                SearchTextBox.Text = "";
            }
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchText) || searchText == "search")
            {
                PopulateEvents(events);
            }
            else
            {
                var filteredDonators = events.Where(user => user.Name.ToLower().Contains(searchText)).ToList();
                PopulateEvents(filteredDonators);
            }
        }
        

        private void SearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                SearchTextBox.Text = "Search";
            }
        }
    }
}

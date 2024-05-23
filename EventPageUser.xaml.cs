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
        private List<Event> allEvents;

        public EventPageUser()
        {
            InitializeComponent();
            LoadEvents();


        }



        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            EventsUserFrame.Navigate(new Uri("HomePageUser.xaml", UriKind.Relative));

        }
        private void LoadEvents()
        {
            Data dataAccess = new Data();
            allEvents = dataAccess.GetAllEvents();
            DisplayEvents(allEvents);
        }


        private void DisplayEvents(List<Event> events)
        {
            eventsWrapPanel.Children.Clear();
            DateTime currentDate = DateTime.Now;

            if (events.Count == 0)
            {
                NoEventsTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                NoEventsTextBlock.Visibility = Visibility.Collapsed;

                foreach (var evt in events)
                {
                    if (evt.EndDate >= currentDate)
                    {
                        Border eventContainer = new Border
                        {
                            Background = Brushes.White,
                            BorderBrush = Brushes.LightGray,
                            BorderThickness = new Thickness(1),
                            CornerRadius = new CornerRadius(10),
                            Padding = new Thickness(10),
                            Margin = new Thickness(10),
                            Width = 300,  // Adjusted width
                            Height = 250  // Adjusted height to make the scroll more obvious
                        };

                        StackPanel stackPanel = new StackPanel
                        {
                            Orientation = Orientation.Vertical,
                            HorizontalAlignment = HorizontalAlignment.Stretch,
                            VerticalAlignment = VerticalAlignment.Stretch
                        };

                        // Create a ScrollViewer to allow scrolling
                        ScrollViewer scrollViewer = new ScrollViewer
                        {
                            VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                            HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled,
                            Height = 180,  // Set height to allow space for scrolling
                            Content = new TextBlock
                            {
                                Margin = new Thickness(10, 0, 10, 0),
                                Text = $"{evt.Name}\n\n{DateOnly.FromDateTime(evt.StartDate)} - {DateOnly.FromDateTime(evt.EndDate)}\n\n{evt.Description}\n\nCurrent amount raised: {evt.CurrentAmountRaised}",
                                TextWrapping = TextWrapping.Wrap,
                                HorizontalAlignment = HorizontalAlignment.Stretch,
                                VerticalAlignment = VerticalAlignment.Top,
                                FontFamily = new FontFamily(new Uri("pack://application:,,,/CharityApplication;component/"), "./Font/#Julius Sans One"),
                                FontSize = 18,  // Adjusted font size for better fitting
                                TextAlignment = TextAlignment.Center
                            }
                        };

                        Button button = new Button
                        {
                            Content = "Donate",
                            Background = Brushes.Black,
                            Foreground = Brushes.White,
                            FontFamily = new FontFamily(new Uri("pack://application:,,,/CharityApplication;component/"), "./Font/#Julius Sans One"),
                            FontSize = 18,
                            Height = 33,
                            Width = 100,
                            BorderBrush = Brushes.Transparent,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Margin = new Thickness(0, 10, 0, 0)
                        };
                        button.Click += (sender, e) => ShowDonatePage(evt);

                        stackPanel.Children.Add(scrollViewer);
                        stackPanel.Children.Add(button);

                        eventContainer.Child = stackPanel;

                        eventsWrapPanel.Children.Add(eventContainer);
                    }
                }
            }
        }




        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchText) || searchText == "search")
            {
                DisplayEvents(allEvents);
            }
            else
            {
                var filteredEvents = allEvents.Where(evt => evt.Name.ToLower().Contains(searchText) || evt.Description.ToLower().Contains(searchText)).ToList();
                DisplayEvents(filteredEvents);
            }
        }



        private void ShowDonatePage(Event ev)
        {
            // Navigate to EventInfoAdmin page and pass event details
            DonateForEvent donatePage = new DonateForEvent(ev);
            EventsUserFrame.Navigate(donatePage);
        }

        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // If the default text is present, clear it
            if (SearchTextBox.Text == "Search")
            {
                SearchTextBox.Text = "";
            }
        }

        private void SearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // If there's no text after losing focus, set the placeholder
            if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                SearchTextBox.Text = "Search";
            }
        }

        /*private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();
            if(eventsStackPanel.Children.Count > 0)
            {
                foreach (UIElement child in eventsStackPanel.Children)
                {
                    if (child is StackPanel eventContainer)
                    {
                        TextBlock textBlock = eventContainer.Children.OfType<TextBlock>().FirstOrDefault();
                        if (textBlock != null)
                        {
                            string eventName = textBlock.Text.Split('\n')[0].ToLower();

                            eventContainer.Visibility = eventName.Contains(searchText) ? Visibility.Visible : Visibility.Collapsed;
                        }
                    }
                }
            }

        }*/
    }
}
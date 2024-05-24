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
    /// Interaction logic for ViewEventsUser.xaml
    /// </summary>
    public partial class ViewEventsUser : Page
    {
        private List<Event> events;
        private Organisation selectedOrganisation;
        public ViewEventsUser(Organisation organisation)
        {
            InitializeComponent();
            selectedOrganisation = organisation;
            LoadEvents(organisation);
            
            
        }

        private void LoadEvents(Organisation organisation)
        {
            Data dataAccess = new Data(); 
            events = dataAccess.GetOrgEvents(organisation);
            PopulateEvents(events);
        }

        private void PopulateEvents(List<Event> events)
        {
            eventsStackPanel.Children.Clear();
            DateTime currentDate = DateTime.Now;

            if (events == null || events.Count == 0)
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
                        StackPanel eventContainer = new StackPanel
                        {
                            Orientation = Orientation.Vertical,
                            HorizontalAlignment = HorizontalAlignment.Stretch,
                            VerticalAlignment = VerticalAlignment.Stretch
                        };

                        TextBlock textBlock = new TextBlock
                        {
                            Background = Brushes.White,
                            Margin = new Thickness(10, 0, 10, 0),
                            Text = $"{evt.Name}\n\n{evt.StartDate:dd-MM-yyyy} - {evt.EndDate:dd-MM-yyyy}\n\n{evt.Description}\n\nCurrent amount raised: {evt.CurrentAmountRaised}",
                            TextWrapping = TextWrapping.Wrap,
                            HorizontalAlignment = HorizontalAlignment.Stretch,
                            VerticalAlignment = VerticalAlignment.Stretch,
                            FontFamily = new FontFamily(new Uri("pack://application:,,,/CharityApplication;component/"), "./Font/#Julius Sans One"),
                            TextAlignment = TextAlignment.Center
                        };

                        Button button = new Button
                        {
                            Content = "Donate",
                            Background = Brushes.White,
                            FontFamily = new FontFamily(new Uri("pack://application:,,,/CharityApplication;component/"), "./Font/#Julius Sans One"),
                            FontSize = 18,
                            Height = 33,
                            Width = 100,
                            BorderBrush = Brushes.Transparent,
                            HorizontalContentAlignment = HorizontalAlignment.Center,
                            VerticalContentAlignment = VerticalAlignment.Center
                        };
                        button.Click += (sender, e) => ShowDonatePage(evt);

                        eventContainer.Children.Add(textBlock);
                        eventContainer.Children.Add(button);

                        eventsStackPanel.Children.Add(eventContainer);
                    }
                }
            }
        }
        private void ShowDonatePage(Event ev)
        {
            DonateForEvent donatePage = new DonateForEvent(ev);
            EventsFrame.Navigate(donatePage);
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {

            ViewOrganisationUser view = new ViewOrganisationUser(selectedOrganisation);
            EventsFrame.Navigate(view);
        }

    }
}

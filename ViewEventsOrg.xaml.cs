using Microsoft.Extensions.Logging;
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
    /// Interaction logic for ViewEventsOrg.xaml
    /// </summary>
    public partial class ViewEventsOrg : Page
    {
        private List<Event> events;
        private Organisation selectedOrganisation;
        public ViewEventsOrg(Organisation organisation)
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
                            Height = 200  // Adjusted height to make the scroll more obvious
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

                        

                        stackPanel.Children.Add(scrollViewer);
                        

                        eventContainer.Child = stackPanel;

                        eventsWrapPanel.Children.Add(eventContainer);
                    }
                }
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {

            ViewOrganisationUser view = new ViewOrganisationUser(selectedOrganisation);
            EventsFrame.Navigate(view);
        }
    }
}

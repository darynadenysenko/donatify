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
    /// Interaction logic for HomePageUser.xaml
    /// </summary>
    public partial class HomePageUser : Page
    {
        private List<Organisation> allOrganisations;
        public HomePageUser()
        {
            InitializeComponent();
            
            //this.organisations = organisations;
            LoadOrgs();
        }
        private void LoadOrgs()
        {
            Data dataAccess = new Data();
            allOrganisations = dataAccess.FetchOrganisationsFromDatabase();
            DisplayOrganisations(allOrganisations);
        }

        private void DisplayOrganisations(List<Organisation> organisations)
        {
            orgWrapPanel.Children.Clear();

            if (organisations.Count == 0)
            {
                NoOrgTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                NoOrgTextBlock.Visibility = Visibility.Collapsed;

                foreach (var org in organisations)
                {
                    Border orgContainer = new Border
                    {
                        Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B8B1AB")),
                        BorderBrush = Brushes.LightGray,
                        BorderThickness = new Thickness(1),
                        CornerRadius = new CornerRadius(10),
                        Padding = new Thickness(10),
                        Margin = new Thickness(10),
                        Width = 250,
                        Height = 200
                    };

                    ScrollViewer scrollViewer = new ScrollViewer
                    {
                        VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                        HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled
                    };

                    Button orgButton = new Button
                    {
                        Content = new TextBlock
                        {
                            Text = $"Name: {org.Name}\n\nType: {org.Type}\n\nMission: {org.Mission}",
                            TextWrapping = TextWrapping.Wrap,
                            FontFamily = new FontFamily(new Uri("pack://application:,,,/CharityApplication;component/"), "./Font/#Julius Sans One"),
                            FontSize = 22,
                            TextAlignment = TextAlignment.Center
                        },
                        Background = Brushes.Transparent,
                        BorderBrush = Brushes.Transparent,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Stretch
                    };

                    orgButton.Click += (s, e) => OrgButton_Click(org);

                    scrollViewer.Content = orgButton;
                    orgContainer.Child = scrollViewer;
                    orgWrapPanel.Children.Add(orgContainer);
                }
            }
        }

        private void OrgButton_Click(Organisation organisation)
        {
            ViewOrganisationUser view = new ViewOrganisationUser(organisation);
            HomeUserFrame.Navigate(view);
        }



        private void TypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TypeComboBox.SelectedItem != null)
            {
                string selectedType = ((ComboBoxItem)TypeComboBox.SelectedItem).Content.ToString();
                if (selectedType == "All types")
                {
                    DisplayOrganisations(allOrganisations);
                }
                else
                {
                    Types type = (Types)Enum.Parse(typeof(Types), selectedType.Replace(" ", ""));
                    var filteredOrganisations = allOrganisations.Where(org => org.Type == type).ToList();
                    DisplayOrganisations(filteredOrganisations);
                    
                }
            }
        }
     

       

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchText) || searchText == "search")
            {
                DisplayOrganisations(allOrganisations);
            }
            else
            {
                var filteredOrganisations = allOrganisations.Where(org => org.Name.ToLower().Contains(searchText) || org.Mission.ToLower().Contains(searchText)).ToList();
                DisplayOrganisations(filteredOrganisations);
            }
        }
    
        private void ProfileUserButton_Click(object sender, RoutedEventArgs e)
        {

            HomeUserFrame.Navigate(new Uri("ProfileUser.xaml", UriKind.Relative));

        }

      

        private void EventsUser_Click(object sender, RoutedEventArgs e)
        {
            HomeUserFrame.Navigate(new Uri("EventPageUser.xaml", UriKind.Relative));

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
    }
}

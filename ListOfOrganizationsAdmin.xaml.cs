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
    /// Interaction logic for ListOfOrganizationsAdmin.xaml
    /// </summary>
    public partial class ListOfOrganizationsAdmin : Page
    {
        private List<Organisation> organisations;
        public ListOfOrganizationsAdmin()
        {
            InitializeComponent();
            Data data = new Data();
            this.organisations = data.FetchOrganisationsFromDatabase();
            DisplayOrganisations(organisations);
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
                    Button button = new Button();
                    button.Content = org.Name;
                    button.FontFamily = new FontFamily(new Uri("pack://application:,,,/CharityApplication;component/"), "./Font/#Julius Sans One");
                    button.FontSize = 22;
                    button.Padding = new Thickness(10,10,10,10);
                    button.Margin = new Thickness(0, 5, 0, 0); 
                    button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B8B1AB")); 
                    button.Foreground = Brushes.Black; 
                    button.BorderThickness = new Thickness(1); 
                    button.BorderBrush = Brushes.Gray; 
                    button.HorizontalContentAlignment = HorizontalAlignment.Center; 
                    button.VerticalContentAlignment = VerticalAlignment.Center; 
                    button.HorizontalAlignment = HorizontalAlignment.Center; 
                    button.Click += (sender, e) => ShowOrgProfile(org);
                    button.Height = 70;
                    button.Width = 1500; 
                    orgWrapPanel.Children.Add(button);

                }
            }
        }
        private void ShowOrgProfile(Organisation organisation)
        {
            // Set the current user in the UserSession
            OrganisationSession.Instance.SetCurrentOrganisation(organisation);

            // Navigate to the ProfileUser page
            ListOfOrganizationsFrame.Navigate(new Uri("ProfileOrganisation.xaml", UriKind.Relative));
        }
        private void TypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TypeComboBox.SelectedItem != null)
            {
                string selectedType = ((ComboBoxItem)TypeComboBox.SelectedItem).Content.ToString();
                if (selectedType == "All types")
                {
                    DisplayOrganisations(organisations);
                }
                else
                {
                    Types type = (Types)Enum.Parse(typeof(Types), selectedType.Replace(" ", ""));
                    var filteredOrganisations = organisations.Where(org => org.Type == type).ToList();
                    DisplayOrganisations(filteredOrganisations);

                }
            }
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            ListOfOrganizationsFrame.Navigate(new Uri("MainPageAdmin.xaml", UriKind.Relative));
        }
        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // If the default text is present, clear it
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
                DisplayOrganisations(organisations);
            }
            else
            {
                var filteredOrganisations = organisations.Where(org => org.Name.ToLower().Contains(searchText)).ToList();
                DisplayOrganisations(filteredOrganisations);
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

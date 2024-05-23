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
    public partial class ListOfUsersAdmin : Page
    {
        private List<Donator> donators;
        public ListOfUsersAdmin()
        {
            InitializeComponent();
            Data data = new Data();
            this.donators = data.FetchDonatorsFromDatabase();
            PopulateDonators(donators);
        }
        private void PopulateDonators(List<Donator> donators)
        {
            usersWrapPanel.Children.Clear();
            if (donators.Count == 0)
            {
                NoUserTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                NoUserTextBlock.Visibility = Visibility.Collapsed;
                foreach (var donator in donators)
                {
                    Button button = new Button();
                    button.Content = donator.Name;
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
                    button.Click += (sender, e) => ShowUserProfile(donator);
                    usersWrapPanel.Children.Add(button);
                }
            }
            
        }
        private void ShowUserProfile(Donator donator)
        {
            // Set the current user in the UserSession
            UserSession.Instance.SetCurrentUser(donator);

            // Navigate to the ProfileUser page
            ListOfUsersFrame.Navigate(new Uri("ProfileUser.xaml", UriKind.Relative));
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            ListOfUsersFrame.Navigate(new Uri("MainPageAdmin.xaml", UriKind.Relative));
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
                PopulateDonators(donators);
            }
            else
            {
                var filteredDonators = donators.Where(user => user.Name.ToLower().Contains(searchText)).ToList();
                PopulateDonators(filteredDonators);
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

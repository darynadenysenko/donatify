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
        public HomePageUser()
        {
            InitializeComponent();
            //this.organisations = organisations;
            LoadOrgs();
        }
        private void LoadOrgs()
        {
            Data dataAccess = new Data();
            List < Organisation > organisations = dataAccess.FetchOrganisationsFromDatabase();
            foreach (var org in organisations)
            {
                // Create a container StackPanel for each organization
                StackPanel orgContainer = new StackPanel
                {
                    Orientation = Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Margin = new Thickness(0, 0, 0, 10) // Add margin below each container
                };

                // Create and configure the TextBlock
                TextBlock textBlock = new TextBlock
                {
                    Background = Brushes.White,
                    Margin = new Thickness(10, 0, 10, 0),
                    Text = $"Name: {org.Name}\nType: {org.Type}\nMission: {org.Mission}",
                    TextWrapping = TextWrapping.Wrap,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    FontFamily = new FontFamily(new Uri("pack://application:,,,/CharityApplication;component/"), "./Font/#Julius Sans One"),
                    TextAlignment = TextAlignment.Center
                };

                // Add the TextBlock to the container StackPanel
                orgContainer.Children.Add(textBlock);

                // Add the container StackPanel to the main StackPanel
                orgStackPanel.Children.Add(orgContainer);
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
    }
}

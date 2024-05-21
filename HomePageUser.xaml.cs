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
                Label label = new Label()
                {
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B8B1AB")),
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Margin = new Thickness(10, 0, 10, 0),
                    Content=org.Name+"\n\n"+org.Mission
                };
                orgStackPanel.Children.Add(label);
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

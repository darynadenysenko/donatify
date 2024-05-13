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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CharityApplication
{
    /// <summary>
    /// Interaction logic for MainPageAdmin.xaml
    /// </summary>
    public partial class MainPageAdmin : Page
    {
        public MainPageAdmin()
        {
            InitializeComponent();
        }
        private void ListOfOrganizations_Click(object sender, RoutedEventArgs e)
        {
            
            mainAdminFrame.Navigate(new Uri("ListOfOrganizationsAdmin.xaml", UriKind.Relative));
        }
        private void ListOfEvents_Click(object sender, RoutedEventArgs e)
        {

            mainAdminFrame.Navigate(new Uri("ListOfEventsAdmin.xaml", UriKind.Relative));
        }
        private void ListOfUsers_Click(object sender, RoutedEventArgs e)
        {

            mainAdminFrame.Navigate(new Uri("ListOfUsersAdmin.xaml", UriKind.Relative));
        }
        
    }
}

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
        }
        private void ProfileUserButton_Click(object sender, RoutedEventArgs e)
        {

            HomeUserFrame.Navigate(new Uri("ProfileUser.xaml", UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

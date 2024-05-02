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
    /// Interaction logic for ChangePasswordUser.xaml
    /// </summary>
    public partial class ChangePasswordUser : Page
    {
        public ChangePasswordUser()
        {
            InitializeComponent();
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordFrame.Navigate(new Uri("ProfileSettingsUser.xaml", UriKind.Relative));

        }
    }
}

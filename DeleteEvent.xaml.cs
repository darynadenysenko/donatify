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
    /// Interaction logic for DeleteEvent.xaml
    /// </summary>
    public partial class DeleteEvent : Page
    {
        public DeleteEvent()
        {
            InitializeComponent();
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            DeleteEventFrame.Navigate(new Uri("EventSettings.xaml", UriKind.Relative));

        }
    }
}

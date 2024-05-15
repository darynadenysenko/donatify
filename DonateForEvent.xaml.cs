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
    /// Interaction logic for DonateForEvent.xaml
    /// </summary>
    public partial class DonateForEvent : Page
    {
        private Event selectedEvent;
        public DonateForEvent(Event ev)
        {
            InitializeComponent();
            this.selectedEvent = ev;
            EventName.Content = ev.Name;
        }
        private void DonateButton_Click(object sender, RoutedEventArgs e)
        {
            // Perform data validation
            if (!decimal.TryParse(DonationAmount.Text, out decimal amount))
            {
                MessageBox.Show("Invalid donation amount. Please enter a valid number.");
                return;
            }

            if (!int.TryParse(CardNumber.Text, out int cardNumber))
            {
                MessageBox.Show("Invalid card number. Please enter a valid integer.");
                return;
            }

            // Proceed with donation
            int eventId = selectedEvent.EventId;
            Data dataAccess = new Data();
            bool success = dataAccess.DonateToEvent(eventId, amount);

            if (success)
            {
                MessageBox.Show("You donated successfully!");
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Failed to donate. Please try again.");
                NavigationService?.GoBack();
            }
        }

       
    private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            DonateFrame.Navigate(new Uri("EventPageUser.xaml", UriKind.Relative));
        }
    }
}

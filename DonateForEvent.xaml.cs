using MySqlConnector;
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
            
            selectedEvent = ev;
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

            if (!int.TryParse(CardNumber.Text, out int cardNumber) || CardNumber.Text.Length != 16)
            {
                MessageBox.Show("Invalid card number. Please enter a valid number.");
                return;
            }

            // Proceed with donation
            
            int eventId = selectedEvent.EventId;
            int donatorId = UserSession.Instance.CurrentUser.UserID;
            int receiverId = selectedEvent.OrgId;
            DateTime date = DateTime.Now;
            Data dataAccess = new Data();

            if (string.IsNullOrWhiteSpace(cardNumber.ToString()) || string.IsNullOrWhiteSpace(amount.ToString()))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                // Update the donation amount raised for the event
                bool updateSuccess = dataAccess.DonateToEvent(eventId, amount);

                if (updateSuccess)
                {
                    // Store donation data in the database
                    bool donationSuccess = dataAccess.InsertDonation(amount, donatorId, eventId, receiverId, date);

                    if (donationSuccess)
                    {
                        MessageBox.Show("You donated successfully!");
                        NavigationService.GoBack();
                    }
                    else
                    {
                        MessageBox.Show("Failed to store donation data. Please try again.");
                        // Rollback donation amount update
                        
                        NavigationService?.GoBack();
                    }
                }
                else
                {
                    MessageBox.Show("Failed to update donation amount for the event. Please try again.");
                    NavigationService?.GoBack();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Failed to donate or store donation data. Error: {ex.Message}. ReceiverID: {receiverId}");
            }
        }

    

       
    private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            DonateFrame.Navigate(new Uri("EventPageUser.xaml", UriKind.Relative));
        }
    }
}

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
    /// Interaction logic for DonationHistory.xaml
    /// </summary>
    public partial class DonationHistory : Page
    {
        public DonationHistory()
        {
            InitializeComponent();
            LoadEvents();

        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            DonationHistoryFrame.Navigate(new Uri("ProfileUser.xaml", UriKind.Relative));

        }
        
        private void LoadEvents()
        {
            var currentUser=UserSession.Instance.CurrentUser;
            
            Data dataAccess = new Data();
            List<Donation> donations = dataAccess.GetUserDonations(currentUser);
            


            // Create a Label with a Button for each event and add it to the StackPanel
            foreach (var donation in donations)
            {
                Organisation org = dataAccess.GetOrgById(donation.OrgId);
                string orgName = org.Name;

                StackPanel donationContainer = new StackPanel();
                donationContainer.Orientation = Orientation.Vertical;
                donationContainer.HorizontalAlignment = HorizontalAlignment.Stretch;
                donationContainer.VerticalAlignment = VerticalAlignment.Stretch;

                // Create and configure the TextBlock
                TextBlock textBlock = new TextBlock();
                textBlock.Background = Brushes.White;
                textBlock.Margin = new Thickness(10, 0, 10, 0);
                textBlock.Height = 100;
                textBlock.Text = donation.Amount + "€ amount\n\nDate: " + donation.Date + "\n\nTo: " + orgName;
                textBlock.TextWrapping = TextWrapping.Wrap;
                textBlock.Width = 100; // Allow the TextBlock to stretch horizontally
                textBlock.HorizontalAlignment = HorizontalAlignment.Stretch; // Allow the TextBlock to stretch horizontally
                textBlock.Height = double.NaN; // Allow the TextBlock to stretch vertically
                textBlock.VerticalAlignment = VerticalAlignment.Stretch;
                textBlock.FontFamily = new FontFamily(new Uri("pack://application:,,,/CharityApplication;component/"), "./Font/#Julius Sans One");
                textBlock.TextAlignment = TextAlignment.Center;




                // Add the TextBlock and Button to the container
                donationContainer.Children.Add(textBlock);
                

                // Add the container (containing TextBlock and Button) to the eventsStackPanel
                donationsStackPanel.Children.Add(donationContainer);
            }
        }
    }
}

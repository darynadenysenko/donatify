using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for AddEvent.xaml
    /// </summary>
    public partial class AddEvent : Page
    {
        public AddEvent()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            int orgId = OrganisationSession.Instance.CurrentOrganisation.OrganizationID;
            string eventName = EventName.Text;
            string eventDescription = Description.Text;
            int targetAmount = int.Parse(TargetAmount.Text);
            DateTime startDate = StartDatePicker.SelectedDate ?? DateTime.MinValue; ;
            DateTime endDate = EndDatePicker.SelectedDate ?? DateTime.MinValue;

            Event newEvent = new Event(eventName, eventDescription, targetAmount, orgId, startDate, endDate);
            Data dataAccess = new Data();
            bool success = dataAccess.AddEvent(newEvent);

                if (success)
                {
                    MessageBox.Show("Event added successfully!");
                    // Optionally, navigate to a different page or perform other actions
                }
                else
                {
                    MessageBox.Show("Failed to add event. Please try again.");
                }
            

        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            AddEventFrame.Navigate(new Uri("EventPageOrg.xaml", UriKind.Relative));
        }
    }
}

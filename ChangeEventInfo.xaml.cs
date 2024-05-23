using Microsoft.Extensions.Logging;
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
    /// Interaction logic for ChangeEventInfo.xaml
    /// </summary>
    public partial class ChangeEventInfo : Page
    {
        private Event selectedEvent;


        public ChangeEventInfo(Event ev)
        {
            InitializeComponent();
            this.selectedEvent = ev;
            

        }
        
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            EventSettings settings = new EventSettings(selectedEvent);
            changeEventFrame.Navigate(settings);

        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            bool isUpdated = false;

            // Check if Name has input and is different from the existing value
            if (!string.IsNullOrWhiteSpace(Name.Text) && !Name.Text.Equals(selectedEvent.Name))
            {
                selectedEvent.Name = Name.Text;
                isUpdated = true;
            }

            // Check if StartDatePicker has a selected date and it is different from the existing value
            if (startDatePicker.SelectedDate.HasValue && startDatePicker.SelectedDate.Value != selectedEvent.StartDate)
            {
                selectedEvent.StartDate = startDatePicker.SelectedDate.Value;
                isUpdated = true;
            }

            // Check if EndDatePicker has a selected date and it is different from the existing value
            if (endDatePicker.SelectedDate.HasValue && endDatePicker.SelectedDate.Value != selectedEvent.EndDate)
            {
                selectedEvent.EndDate = endDatePicker.SelectedDate.Value;
                isUpdated = true;
            }

            // Check if Description has input and is different from the existing value
            if (!string.IsNullOrWhiteSpace(Description.Text) && !Description.Text.Equals(selectedEvent.Description))
            {
                selectedEvent.Description = Description.Text;
                isUpdated = true;
            }

            if (isUpdated)
            {
                Data dataAccess = new Data();
                bool success = dataAccess.UpdateEvent(selectedEvent);

                if (success)
                {
                    MessageBox.Show("Event information updated successfully!");
                    EventSettings settings = new EventSettings(selectedEvent);
                    changeEventFrame.Navigate(settings);

                }
                else
                {
                    MessageBox.Show("Failed to update event information. Please try again.");
                    EventSettings settings = new EventSettings(selectedEvent);
                    changeEventFrame.Navigate(settings);

                }
            }
            else
            {
                MessageBox.Show("No changes were made to the event information.");
                EventSettings settings = new EventSettings(selectedEvent);
                changeEventFrame.Navigate(settings);

            }
        }

    }
}
        
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
        private int selectedEventId;


        public ChangeEventInfo(int eventId)
        {
            InitializeComponent();
         
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Set the SelectedEventId property here, for example, if you have access to the data or navigation parameter
            // For demonstration, let's directly set it to a value passed from the EventPageOrg
            if (NavigationService.Content is EventPageOrg eventPageOrg)
            {
                selectedEventId = eventPageOrg.SelectedEventId;
            }
        }
        private DateTime selectedStartDate = DateTime.MinValue;
        private DateTime selectedEndDate = DateTime.MaxValue;
        public ChangeEventInfo()
        {
            InitializeComponent();
            startDatePicker.SelectedDateChanged += StartDatePicker_SelectedDateChanged;
            endDatePicker.SelectedDateChanged += EndDatePicker_SelectedDateChanged;
            
    }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            changeEventFrame.Navigate(new Uri("EventSettings.xaml", UriKind.Relative));

        }
        private void StartDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DatePicker startDatePicker)
            {
                selectedStartDate = startDatePicker.SelectedDate ?? DateTime.MinValue;
                
            }
        }

        private void EndDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DatePicker endDatePicker)
            {
                selectedEndDate = endDatePicker.SelectedDate ?? DateTime.MinValue;
                
            }
        }
        
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            Data dataAccess = new Data();
            var currentEvent = dataAccess.GetEventById(selectedEventId);

            currentEvent.Name = Name.Text;
            currentEvent.Description=Description.Text;
            currentEvent.StartDate = selectedStartDate;
            currentEvent.EndDate = selectedEndDate;



            bool success = dataAccess.UpdateEventInfo(currentEvent);

            if (success)
            {
                MessageBox.Show("Organization information updated successfully!");
                changeEventFrame.Navigate(new Uri("EventPageOrg.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Failed to update event information. Please try again.");
            }
        }
    }
}

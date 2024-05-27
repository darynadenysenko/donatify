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
    /// Interaction logic for AddEvent.xaml
    /// </summary>
    public partial class AddEvent : Page
    {
        public AddEvent()
        {
            InitializeComponent();
        }
        private DateTime selectedStartDate = DateTime.MinValue;
        private DateTime selectedEndDate = DateTime.MaxValue;
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            AddEventFrame.Navigate(new Uri("EventPageOrg.xaml", UriKind.Relative));
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
            if (string.IsNullOrWhiteSpace(Name.Text))
            {
                MessageBox.Show("Please enter an event name.");
                return;
            }

            if (string.IsNullOrWhiteSpace(Description.Text))
            {
                MessageBox.Show("Please enter an event description.");
                return;
            }

            if (selectedStartDate == DateTime.MinValue)
            {
                MessageBox.Show("Please select a valid start date.");
                return;
            }

            if (selectedEndDate == DateTime.MaxValue)
            {
                MessageBox.Show("Please select a valid end date.");
                return;
            }

            if (selectedEndDate < selectedStartDate)
            {
                MessageBox.Show("End date cannot be before start date.");
                return;
            }
            Data dataAccess = new Data();
            var newEvent = new Event();
            var currentOrganisation = OrganisationSession.Instance.CurrentOrganisation;


            newEvent.Name = Name.Text;
            newEvent.Description = Description.Text;
            newEvent.StartDate = selectedStartDate;
            newEvent.EndDate = selectedEndDate;
            newEvent.OrgId=currentOrganisation.OrganizationID;



            bool success = dataAccess.AddEvent(newEvent);

            if (success)
            {
                MessageBox.Show("Event added successfully!");
                AddEventFrame.Navigate(new Uri("EventPageOrg.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Failed to add event. Please try again.");
            }
        }

    }
}

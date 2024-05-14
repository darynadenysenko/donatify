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
        
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
           
            selectedEvent.Name = Name.Text;
            selectedEvent.StartDate = startDatePicker.SelectedDate ?? DateTime.MinValue;
            selectedEvent.EndDate = endDatePicker.SelectedDate ?? DateTime.MinValue;
            selectedEvent.Description = Description.Text;
            

            Data dataAccess = new Data();
            bool success = dataAccess.UpdateEvent(selectedEvent);

            if (success)
            {
                MessageBox.Show("Event information updated successfully!");
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Failed to update event information. Please try again.");

                
                NavigationService?.GoBack();
            }
        }
    }
}
        
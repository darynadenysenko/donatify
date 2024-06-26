﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        private Event selectedEvent;
        public DeleteEvent(Event ev)
        {
            InitializeComponent();
            this.selectedEvent = ev;
        }
        private void DeleteEvent_Click(object sender, RoutedEventArgs e)
        {
            int eventId = selectedEvent.EventId;
            string password = Password.Password;
            Data dataAccess = new Data();
            string currentPassword = "";
            string sessionType = dataAccess.GetCurrentSessionType();
            if (sessionType == "Admin")
            {
                currentPassword = AdminSession.Instance.CurrentAdmin.Password;
            }
            else if (sessionType == "Organisation")
            {
                currentPassword = OrganisationSession.Instance.CurrentOrganisation.Password;
            }
            if (password == currentPassword)
            {
                bool success = dataAccess.DeleteEvent(eventId);

                if (success)
                {
                    MessageBox.Show("Event deleted successfully!");
                    if (sessionType == "Organisation")
                    {
                        DeleteEventFrame.Navigate(new Uri("EventPageOrg.xaml", UriKind.Relative));
                    }
                    else if (sessionType == "Admin")
                    {
                        DeleteEventFrame.Navigate(new Uri("ListOfEventsAdmin.xaml", UriKind.Relative));
                    }
                    
                }
                else
                {
                    MessageBox.Show("Failed to delete event. Please try again.");
                }

            }
            else
            {
                MessageBox.Show("Wrong password! Please try again.");
            }

           
            
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            EventSettings settings = new EventSettings(selectedEvent);
            DeleteEventFrame.Navigate(settings);

        }
    }
}

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
    /// Interaction logic for ListOfEventsAdmin.xaml
    /// </summary>
    public partial class ListOfEventsAdmin : Page
    {
        private List<Event> events;
        public ListOfEventsAdmin()
        {
            InitializeComponent();
            this.events = events;
            PopulateEvents();
        }
        private void PopulateEvents()
        {
            Data dataAccess = new Data();
            events = dataAccess.FetchEventsFromDatabase();
            foreach (var ev in events)
            {
                Button button = new Button();
                button.Content = ev.Name;
                button.Click += (sender, e) => ShowEventInfo(ev);
                eventsStackPanel.Children.Add(button);
            }
        }
        private void ShowEventInfo(Event ev)
        {
            // Navigate to EventInfoAdmin page and pass event details
            EventInfoAdmin eventInfoPage = new EventInfoAdmin(ev);
            NavigationService.Navigate(eventInfoPage);
        }

    }
}

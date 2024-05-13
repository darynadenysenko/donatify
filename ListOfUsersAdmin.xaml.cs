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
    public partial class ListOfUsersAdmin : Page
    {
        private List<Donator> donators;
        public ListOfUsersAdmin()
        {
            InitializeComponent();
            this.donators = donators;
            PopulateDonators();
        }
        private void PopulateDonators()
        {
            Data dataAccess = new Data();
            donators = dataAccess.FetchDonatorsFromDatabase();
            foreach (var donator in donators)
            {
                Button button = new Button();
                button.Content = donator.Name;
                button.Click += (sender, e) => ShowUserProfile(donator);
                donatorsStackPanel.Children.Add(button);
            }
        }
        private void ShowUserProfile(Donator donator)
        {
            // Set the current user in the UserSession
            UserSession.Instance.SetCurrentUser(donator);

            // Navigate to the ProfileUser page
            NavigationService.Navigate(new Uri("ProfileUser.xaml", UriKind.Relative));
        }

    }
}

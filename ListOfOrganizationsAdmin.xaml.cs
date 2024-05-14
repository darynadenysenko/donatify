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
    /// Interaction logic for ListOfOrganizationsAdmin.xaml
    /// </summary>
    public partial class ListOfOrganizationsAdmin : Page
    {
        private List<Organisation> organisations;
        public ListOfOrganizationsAdmin()
        {
            InitializeComponent();
            this.organisations = organisations;
            PopulateOrganisations();
        }
        private void PopulateOrganisations()
        {
            Data dataAccess = new Data();
            organisations = dataAccess.FetchOrganisationsFromDatabase();
            foreach (var org in organisations)
            {
                Button button = new Button();
                button.Content = org.Name;
                button.Click += (sender, e) => ShowOrgProfile(org);
                orgStackPanel.Children.Add(button);
            }
        }
        private void ShowOrgProfile(Organisation organisation)
        {
            // Set the current user in the UserSession
            OrganisationSession.Instance.SetCurrentOrganisation(organisation);

            // Navigate to the ProfileUser page
            NavigationService.Navigate(new Uri("ProfileOrganisation.xaml", UriKind.Relative));
        }
    }
    
}

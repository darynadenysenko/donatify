using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CharityApplication
{
    /// <summary>
    /// Interaction logic for ViewOrganisationUser.xaml
    /// </summary>
    public partial class ViewOrganisationUser : Page
    {
        private Organisation organisation;

        public ViewOrganisationUser(Organisation organisation)
        {
            InitializeComponent();
            this.organisation = organisation;
            DisplayOrganisationDetails();
        }

        private void DisplayOrganisationDetails()
        {
            Data data = new Data();
            userName.Content = organisation.Name;
            Email.Content = organisation.Email;
            PhoneNumber.Content = organisation.Phone;
            Type.Content = organisation.Type.ToString();
            Mission.Content = organisation.Mission;
            byte[] imageData = data.GetProfilePicture(organisation);
            if (imageData != null)
            {
               
                ProfileImage.Source = LoadImage(imageData);
            }
        }
        public BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0)
                return null;

            BitmapImage image = new BitmapImage();
            using (MemoryStream memStream = new MemoryStream(imageData))
            {
                memStream.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = memStream;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Data data = new Data();
            string currentSession = data.GetCurrentSessionType();
            if (currentSession == "Donator" )
            {
                ViewOrgFrame.Navigate(new Uri("HomePageUser.xaml", UriKind.Relative));
            }
            else if (currentSession == "Organisation")
            {
                ViewOrgFrame.Navigate(new Uri("HomePageOrganisation.xaml", UriKind.Relative));
            }
           
        }
        private void ViewEvents_Click(object sender, RoutedEventArgs e)
        {
            Data data = new Data();
            string currentSession = data.GetCurrentSessionType();
            if (currentSession == "Donator")
            {
                ViewOrgFrame.Navigate(new ViewEventsUser(organisation));
            }
            else if (currentSession == "Organisation")
            {
                ViewOrgFrame.Navigate(new ViewEventsOrg(organisation));
            }
           
        }
    }
}

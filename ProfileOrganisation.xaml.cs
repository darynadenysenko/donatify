using Microsoft.Win32;
using MySqlConnector;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CharityApplication
{
    /// <summary>
    /// Interaction logic for ProfileOrganisation.xaml
    /// </summary>
    public partial class ProfileOrganisation : Page
    {
        
        public ProfileOrganisation()
        {
            InitializeComponent();
            var currentOrganisation = OrganisationSession.Instance.CurrentOrganisation;
            if (currentOrganisation != null)
            {
                userName.Content = currentOrganisation.Name;
                Email.Content= currentOrganisation.Email;
                PhoneNumber.Content = currentOrganisation.Phone;
                Type.Content = currentOrganisation.Type;
                Mission.Content = currentOrganisation.Mission;

            }
            else
            {
                userName.Content = "No user logged in";
            }
        }
        private void ProfileSettingsOrg_Click(object sender, RoutedEventArgs e)
        {
          HomeOrgFrame.Navigate(new Uri("ProfileSettingsOrganisation.xaml", UriKind.Relative));
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            HomeOrgFrame.Navigate(new Uri("HomePageOrganisation.xaml", UriKind.Relative));
        }
        private void UploadPicture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFileName = openFileDialog.FileName;
                BitmapImage bitmap = new BitmapImage(new Uri(selectedFileName));
                ProfileImage.Source = bitmap;

                byte[] imageData;
                using (FileStream fs = new FileStream(selectedFileName, FileMode.Open, FileAccess.Read))
                {
                    imageData = new byte[fs.Length];
                    fs.Read(imageData, 0, (int)fs.Length);
                }
                Data dataAccess = new Data();
                var currentOrganisation = OrganisationSession.Instance.CurrentOrganisation;
                int organizationId = currentOrganisation.OrganizationID;
                bool success=dataAccess.SaveProfilePictureToDatabase(organizationId, imageData);
                if (success)
                {
                    MessageBox.Show("Profile picture updated successfully!");
                    ProfileUploadButton.Visibility = Visibility.Collapsed;
                }
                else
                {
                    MessageBox.Show("Failed to upload profile picture!");
                }
            }
        }
        

    }
}
    


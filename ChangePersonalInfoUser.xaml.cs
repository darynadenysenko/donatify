﻿using System;
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
    /// Interaction logic for ChangePersonalInfoUser.xaml
    /// </summary>
    public partial class ChangePersonalInfoUser : Page
    {
        public ChangePersonalInfoUser()
        {
            InitializeComponent();
        }
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = UserSession.Instance.CurrentUser;
            currentUser.Name = NameTextBox.Text;
            currentUser.LastName = LastNameTextBox.Text;
            currentUser.Email = EmailTextBox.Text;

            Data dataAccess = new Data();
            bool success = dataAccess.UpdateUserInfo(currentUser);

            if (success)
            {
                MessageBox.Show("User information updated successfully!");
                ChangeInfoUserFrame.Navigate(new Uri("ProfileSettingsUser.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Failed to update user information. Please try again.");
            }
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            ChangeInfoUserFrame.Navigate(new Uri("ProfileSettingsUser.xaml", UriKind.Relative));

        }
    }
}

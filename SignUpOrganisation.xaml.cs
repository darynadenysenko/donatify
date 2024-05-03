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
    /// Interaction logic for SignUpOrganisation.xaml
    /// </summary>
    public partial class SignUpOrganisation : Page
    {
        public SignUpOrganisation()
        {
            InitializeComponent();
        }
        private void SignUpOrgButton_Click(object sender, RoutedEventArgs e)
        {
            signUpOrgFrame.Navigate(new Uri("HomePageOrganisation.xaml", UriKind.Relative));
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            signUpOrgFrame.Navigate(new Uri("SignUpChoose.xaml", UriKind.Relative));
        }

    }
}

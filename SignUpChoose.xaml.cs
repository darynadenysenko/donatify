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
    /// Interaction logic for Page.xaml
    /// </summary>
    public partial class SignUpChoose : Page
    {
        public SignUpChoose()
        {
            InitializeComponent();
        }
       
        private void DonatorChoice_Click(object sender, RoutedEventArgs e)
        {
            SignUpUser signUpUser = new SignUpUser();
            signUpUser.ShowDialog();
        }
        private void OrganisationChoice_Click(object sender, RoutedEventArgs e)
        {
            SignUpOrganisation signUpOrg = new SignUpOrganisation();
            signUpOrg.ShowDialog();
        }
    }
}

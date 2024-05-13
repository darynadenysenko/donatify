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
    public partial class ListOfDonatorsAdmin : Page
    {
        private List<Donator> donators;

        public ListOfDonatorsAdmin(List<Donator> donators)
        {
            InitializeComponent();
            this.donators = donators;
            PopulateDonators();
        }

        private void PopulateDonators()
        {
            foreach (var donator in donators)
            {
                Button button = new Button();
                button.Content = donator.Name;
                // Add event handler to navigate to donator profile or perform other actions
                donatorsStackPanel.Children.Add(button);
            }
        }
    }
}

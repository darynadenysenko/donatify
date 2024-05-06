using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace CharityApplication
{
    public class Donator 
    {
        public string LastName { get; set; }
        public int DonatorID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        private Data data = new Data();

        


        //public Dictionary<Event, Amount> DonationHistory { get; set; }
        public void Donate(Event @event, decimal amount)
        {
            // Add donation to event88

            //@event.ReceiveDonation(this, amount);

            // Update total donation amount
            //TotalDonationAmount += amount;
        }
        public void AddUser(Donator donator)
        {
            // Logic to add a user
        }

        public void UpdateUser(Donator donator)
        {
            // Logic to update a user
        }

        public void DeleteUser(Donator donator)
        {
            // Logic to delete a user
        }
    }
}

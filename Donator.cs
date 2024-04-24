using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityApplication
{
    public class Donator : User
    {
        public string LastName { get; set; }
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

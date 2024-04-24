using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityApplication
{
    public class Organisation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Mission { get; set; }
        public Types Type { get; set; }
       // public  decimal Balance { get; set; }
        public List<Event> Events { get; set; }


        public void CreateEvent(Event newEvent)
        {
            Events.Add(newEvent);
        }
        public void DeleteEvent(Event deletedEvent)
        {
            Events.Remove(deletedEvent);
        }
        public void UpdateEvent(Event updatedEvent)
        {
           
        }
        public void AddOrganization(Organisation organization)
        {
            // Logic to add an organization
        }

        public void UpdateOrganization(Organisation organization)
        {
            // Logic to update an organization
        }

        public void DeleteOrganization(Organisation organization)
        {
            // Logic to delete an organization
        }


    }
}

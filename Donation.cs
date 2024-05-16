using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityApplication
{
    public class Donation
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int DonatorId { get; set; }
        public Event Event { get; set; }
        public  int OrgId { get; set; }
        public  DateTime Date { get; set; }

    }
}

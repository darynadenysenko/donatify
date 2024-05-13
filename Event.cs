﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityApplication
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal CurrentAmountRaised { get; set; }
        public int OrganizerID { get; set; }
        public List<Donation> Donations { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Event(string name, string description, decimal targetAmount, int organizerID, DateTime startDate, DateTime endDate)
        {
            Name = name;
            Description = description;
            TargetAmount = targetAmount;
            OrganizerID = organizerID;
            StartDate = startDate;
            EndDate = endDate;
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge
{
    public enum EventType { Golf, Bowling, AmusementPark, Concert }
    public class OutingInformation
    {
        public EventType Type { get; set; }
        public int NumberOfAttendants { get; set; }
        public DateTime DateOfEvent { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal EventCost { get; set; }

        public OutingInformation(EventType type, int attendants, DateTime eventDate, decimal costPerPerson, decimal eventCost)
        {
            Type = type;
            NumberOfAttendants = attendants;
            DateOfEvent = eventDate;
            CostPerPerson = costPerPerson;
            EventCost = eventCost;
        }
        public OutingInformation()
        {


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge
{
    public class OutingRepository
    {
        List<OutingInformation> _outingInfo = new List<OutingInformation>();

        public void AddOutingToList(OutingInformation outing)
        {
            _outingInfo.Add(outing);
        }

        public List<OutingInformation> GetOutingList()
        {
            return _outingInfo;
        }

        public decimal TotalCost()
        {
            decimal totalCost = 0;
            foreach (OutingInformation outing in _outingInfo)
            {
                totalCost += outing.EventCost;
            }
            return totalCost;
        }

        //public decimal CostByType(EventType type)
        //{
        //    decimal total = 0m;
            
        //    foreach (OutingInformation outing in _outingInfo)
        //    {
        //        if (type == outing.Type)
        //            total += outing.EventCost;
        //        else if (type == outing.Type)
        //            total += outing.EventCost;
        //        else if (type == outing.Type)
        //            total += outing.EventCost;
        //        else if (type == outing.Type)
        //            total += outing.EventCost;
        //    }
        //    return total;
        //}

        public decimal CalculateCostByType(EventType type)
        {
            decimal totalCost = 0m;
            foreach (OutingInformation outing in _outingInfo)
            {
                if (type == outing.Type)
                {
                    switch (type)
                    {
                        case EventType.Golf:
                            totalCost += outing.EventCost;
                            break;
                        case EventType.Bowling:
                            totalCost += outing.EventCost;
                            break;
                        case EventType.AmusementPark:
                            totalCost += outing.EventCost;
                            break;
                        case EventType.Concert:
                            totalCost += outing.EventCost;
                            break;
                    }
                }
            }
            return totalCost;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge
{
    public class ClaimRepository
    {
        Queue<ClaimInformation> _claimInfo = new Queue<ClaimInformation>();

        public void AddClaimToQueue(ClaimInformation claimInfo)
        {
            _claimInfo.Enqueue(claimInfo);
        }

        public Queue<ClaimInformation>GetClaimInformation()
        {
            return _claimInfo;
        }

        public void RemoveClaimFromQueue()
        {
            _claimInfo.Dequeue();
        }

        public ClaimInformation PeekAtClaimQueue()
        {
            return _claimInfo.Peek();
        }

        //public void ClaimValidity()
        //{
        //    foreach (ClaimInformation claim in _claimInfo)
        //    {
        //        int timespan = (claim.DateOfClaim - claim.DateOfIncident).Days;

        //        if (timespan > 30)
        //            claim.IsValid = false;
        //        break;
        //    }
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge
{
    public enum ClaimType { Car, Home, Theft }
    public class ClaimInformation
    {
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public ClaimInformation(int claimID, ClaimType claimType, string description, decimal claimAmount, DateTime incidentDate, DateTime claimDate)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = incidentDate;
            DateOfClaim = claimDate;
            IsValid = DateOfClaim - DateOfIncident < TimeSpan.FromDays(30);
        }

        public ClaimInformation()
        {

        }
    }
}

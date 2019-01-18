using System;
using System.Collections.Generic;

namespace _02_Challenge
{
    class ProgramUI
    {
        private ClaimRepository _claimRepo;
        private Queue<ClaimInformation> _claimInfo;

        public ProgramUI()
        {
            _claimRepo = new ClaimRepository();
            _claimInfo = _claimRepo.GetClaimInformation();
        }

        public void Run()
        {

            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Hello, what would you like to do?\n" +
                    "1. Display All Claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit application");

                string inputAsString = Console.ReadLine();
                int input = int.Parse(inputAsString);

                switch (input)
                {
                    case 1:
                        DisplayAllClaims();
                        break;
                    case 2:
                        ShowNextClaim();
                        break;
                    case 3:
                        EnterNewClaim();
                        break;
                    case 4:
                        running = false;
                        break;
                }
            }

        }
        //private void Validity()
        //{
        //    _claimRepo.ClaimValidity();
        //}

        private void EnterNewClaim()
        {
            Console.WriteLine("Please enter the claim ID");
            int claimID = ParseInput();

            Console.WriteLine("Please select your claim type:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            int claimType = ParseInput();

            ClaimType type;
            switch (claimType)
            {
                default:
                case 1:
                    type = ClaimType.Car;
                    break;
                case 2:
                    type = ClaimType.Home;
                    break;
                case 3:
                    type = ClaimType.Theft;
                    break;
            }

            Console.WriteLine("Please enter a claim description");
            string description = Console.ReadLine();

            Console.WriteLine("Please enter the claim amount");
            decimal claimAmount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the date of the accident (dd/mm/yy)");
            DateTime dateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the date of the claim (dd/mm/yy)");
            DateTime dateOfClaim = DateTime.Parse(Console.ReadLine());

            ClaimInformation claim = new ClaimInformation(claimID, type, description, claimAmount, dateOfIncident, dateOfClaim);

            _claimRepo.AddClaimToQueue(claim);

            Console.WriteLine($"\"Claim ID#{claim.ClaimID}\" has been added to the list.");
            Console.ReadKey();
        }

        private void DisplayAllClaims()
        {
            string[] claimCategories = { "Claim ID", "Type", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid" };
            Console.WriteLine("Claim ID  " + "Type\t" + "Description\t " + "Amount\t \t" + "DateOfAccident \t \t" + "DateOfClaim\t \t" + "IsValid");
            foreach (ClaimInformation claim in _claimInfo)
            {
                Console.WriteLine($" {claim.ClaimID}\t  {claim.ClaimType}\t  {claim.Description}\t\t {claim.ClaimAmount}\t {claim.DateOfIncident} \t {claim.DateOfClaim}\t {claim.IsValid}");
            }
            Console.ReadKey();
        }

        private int ParseInput()
        {
            int input = int.Parse(Console.ReadLine());
            return input;
        }

        private void ShowNextClaim()
        {
            
            ClaimInformation claim = _claimRepo.PeekAtClaimQueue();
            Console.WriteLine($"Claim ID:{claim.ClaimID}\n + ClaimType:{claim.ClaimType}\n + Description:{claim.Description}\n + Amount of Damage: {claim.ClaimAmount}\n + Date Of Incident:{claim.DateOfIncident}\n + Date of Claim:{claim.DateOfClaim}\n + This claim is valid:{claim.IsValid}");
            Console.WriteLine("Do you want to deal with this claim now? (y/n)");
            string response = Console.ReadLine().ToLower();
            if (response == "y")
            {
                _claimRepo.RemoveClaimFromQueue();
            }
            else
            {
                
            }
        }
    }
}
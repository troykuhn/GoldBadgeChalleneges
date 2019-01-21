using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge
{
    class ProgramUI
    {
        private OutingRepository _outingRepo;
        private List<OutingInformation> _outingInfo;

        public ProgramUI()
        {
            _outingRepo = new OutingRepository();
            _outingInfo = _outingRepo.GetOutingList();
        }

        public void Run()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Hello, what would you like to do?\n" +
                    "1. Create New Outing\n" +
                    "2. Display Total Cost of All Outings\n" +
                    "3. Display Outing Cost by Type\n" +
                    "4. Exit application");

                string inputAsString = Console.ReadLine();
                int input = int.Parse(inputAsString);

                switch (input)
                {
                    case 1:
                        CreateNewOuting();
                        break;
                    case 2:
                        DisplayTotalCostOfAllOutings();
                        break;
                    case 3:
                        DisplayTotalOutingCostByType();
                        break;
                    case 4:
                        running = false;
                        break;
                }
            }
        }

        private void DisplayTotalCostOfAllOutings()
        {
            decimal finalCost = _outingRepo.TotalCost();
            Console.WriteLine($"The combined cost of all outings is ${finalCost}");
            Console.ReadKey();
        }

        private void DisplayTotalOutingCostByType()
        {
            Console.WriteLine("Enter the number for the event type of the outing:\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert");
            int eventType = ParseInput();

            EventType type;
            switch (eventType)
            {
                default:
                case 1:
                    type = EventType.Golf;
                    break;
                case 2:
                    type = EventType.Bowling;
                    break;
                case 3:
                    type = EventType.AmusementPark;
                    break;
                case 4:
                    type = EventType.Concert;
                    break;
            }

            decimal totalCost =_outingRepo.Calculate
                CostByType(type);
            Console.WriteLine($"\"{type}\" outings have a total cost of  ${totalCost}");
            Console.ReadKey();
        }

        private void CreateNewOuting()
        {
            Console.WriteLine("Enter the number for the event type of the outing:\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert");
            int eventType = ParseInput();

            EventType type;
            switch (eventType)
            {
                default:
                case 1:
                    type = EventType.Golf;
                    break;
                case 2:
                    type = EventType.Bowling;
                    break;
                case 3:
                    type = EventType.AmusementPark;
                    break;
                case 4:
                    type = EventType.Concert;
                    break;
            }

            Console.WriteLine($"Please enter the number of attendants");
            int attendants = ParseInput();

            Console.WriteLine("Please enter the date of the event(dd/mm/yy)");
            DateTime dateOfEvent = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter the cost per person for the event");
            decimal costPerPerson = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the total cost of the event");
            decimal eventCost = decimal.Parse(Console.ReadLine());

            OutingInformation outing = new OutingInformation(type, attendants, dateOfEvent, costPerPerson, eventCost);

            _outingRepo.AddOutingToList(outing);
            Console.WriteLine($"\"{outing.Type}\" on {outing.DateOfEvent} has been added to list.");
            Console.ReadKey();
        }

        private int ParseInput()
        {
            int input = int.Parse(Console.ReadLine());
            return input;
        }
    }
}

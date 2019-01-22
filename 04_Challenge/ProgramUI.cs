using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Challenge
{
    class ProgramUI
    {
        private BadgeRepository _badgeRepo;
        private Dictionary<int, List<string>> _badges;

        public ProgramUI()
        {
            _badgeRepo = new BadgeRepository();
            _badges = _badgeRepo.GetBadgeInfo();
        }

        public void Run()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Hello Security Admin, what would you like to do?\n" +
                    "1. Add a Badge\n" +
                    "2. Edit a Badge\n" +
                    "3. List All Badges\n" +
                    "4. Exit application");

                string inputAsString = Console.ReadLine();
                int input = int.Parse(inputAsString);

                switch (input)
                {
                    case 1:
                        AddBadge();
                        break;
                    case 2:
                        UpdateBadge();
                        break;
                    case 3:
                        ListAllBadges();
                        break;
                    case 4:
                        running = false;
                        break;
                }
            }
        }

        private void AddBadge()
        {
            Console.WriteLine("What is the number on the badge?");
            int badgeID = ParseInput();

            List<string> doorNames = new List<string>();
            Console.WriteLine("List a door that this badge needs access to.");
            string response = Console.ReadLine();
            doorNames.Add(response);

            bool addDoor = true;
            while (addDoor)
            {
                Console.WriteLine("Any other doors? (y/n) ");
                string yesNo = Console.ReadLine().ToUpper();
                if (yesNo == "Y")
                {
                    Console.WriteLine("List a door that this badge needs access to.");
                    string doorName = Console.ReadLine().ToUpper();
                    doorNames.Add(doorName);
                }
                else
                {
                    addDoor = false;
                }
            }


            Badge badge = new Badge(badgeID, doorNames);
            _badgeRepo.AddBadge(badge);
        }

        private void UpdateBadge()
        {
            Console.WriteLine("What is the badge number to update?");
            int badgeID = ParseInput();
            Console.WriteLine("What would you like to do?");


            foreach (KeyValuePair<int, List<string>> badge in _badges)
            {
                Console.WriteLine($"Badge ID#{badgeID} has access to:");
                foreach (string door in badge.Value)
                {
                    Console.Write($"{door}");
                }
                if (badge.Key == badgeID)
                {
                    _badgeRepo.GetBadgeInfo();
                }
            }
            Console.WriteLine("What would you like to do?\n" +
                    "1. Remove a Door\n" +
                    "2. Add a Door");

            string inputAsString = Console.ReadLine();
            int input = int.Parse(inputAsString);

            switch (input)
            {
                case 1:
                    Console.WriteLine("Which door would you like to remove?");
                    string remove = Console.ReadLine().ToUpper();
                    badge Remove(remove);
                    break;
                case 2:
                    Console.WriteLine("Which door would you like to add?");
                    string add = Console.ReadLine().ToUpper();
                    doorNames.Add(add);
                    break;
            }
            Console.ReadLine();

            foreach
            List<string> values = _badges[badgeID];
            _badges[badgeID] = new List<string>();
            Console.WriteLine(_badges[badgeID]);
            //_badgeRepo.GetBadgeInfo(values);
            Console.WriteLine($"{values}");
            Console.ReadKey();
            //_badges[]
            //foreach (badgeID, List<string>> in _badges)
            //{
            //    if()
            //}


        }

        private void ListAllBadges()
        {
            foreach (KeyValuePair<int, List<string>> badge in _badges)
            {
                Console.WriteLine("Badge ID#\t\t Door Access");
                Console.Write($" {badge.Key}\t\t");
                foreach (string door in badge.Value)
                {
                    Console.Write($"\t\t{door}");
                }
            }
            Console.ReadLine();
        }

        private int ParseInput()
        {
            int input = int.Parse(Console.ReadLine());
            return input;
        }
    }
}

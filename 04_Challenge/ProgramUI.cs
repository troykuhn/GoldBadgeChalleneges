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
            SeedList();
        }

        private void SeedList()
        {
            List<string> doorsOne = new List<string> { "A1", "A2", "B1", "B2" };
            List<string> doorsTwo = new List<string> { "C1", "C2", "D1", "D2" };
            Badge badge = new Badge(123, doorsOne);
            Badge badgeTwo = new Badge(124, doorsTwo);

            _badgeRepo.AddBadge(badge);
            _badgeRepo.AddBadge(badgeTwo);
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
            string response = Console.ReadLine().ToUpper();
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

            foreach (KeyValuePair<int, List<string>> badge in _badges)
            {
                foreach (string door in badge.Value)
                {
                    if (badge.Key == badgeID)
                        Console.WriteLine($"Badge ID#{badgeID} has access to: {door} ");
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
                    foreach (KeyValuePair<int, List<string>> badge in _badges)
                    {
                        foreach (string door in badge.Value)
                        {
                            if (_badges.ContainsKey(badgeID))
                            {
                                badge.Value.Remove(remove);
                                break;
                            }
                            Console.WriteLine($"{remove} Door has been removed.");
                            foreach (string remainingDoor in badge.Value)
                            {
                                Console.WriteLine($"Badge ID#{badgeID} has access to: {remainingDoor}");
                            }

                        }
                    }
                    break;
                case 2:
                    Console.WriteLine("Which door would you like to add?");
                    string add = Console.ReadLine().ToUpper();
                    foreach (KeyValuePair<int, List<string>> badge in _badges)
                    {
                        foreach (string door in badge.Value)
                        {
                            bool run = true;
                            while (run)
                            {
                                if (badgeID == badge.Key)
                                {
                                    badge.Value.Add(add);
                                    Console.WriteLine($"Badge ID#{badgeID} has access to: {add}");
                                }
                                Console.WriteLine("Would you like to add another door? y/n");
                                string boolResponse = Console.ReadLine();
                                if (boolResponse == "y")
                                {
                                    run = true;
                                    Console.WriteLine("Which door would you like to add?");
                                    add = Console.ReadLine().ToUpper();
                                }
                                else
                                    run = false;
                            }
                            break;
                        }
                        break;
                    }
                    break;
            }

            Console.ReadKey();
            Run();
        }

        private void ListAllBadges()
        {
            Console.WriteLine("Badge ID#\t\t Door Access");
            foreach (KeyValuePair<int, List<string>> badge in _badges)
            {
                Console.WriteLine($" {badge.Key}\t\t");
                foreach (string door in badge.Value)
                {
                    Console.WriteLine($"\t\t\t{door}");
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

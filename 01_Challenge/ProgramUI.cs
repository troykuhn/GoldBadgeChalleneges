using System;
using System.Collections.Generic;

namespace _01_Challenge
{
    class ProgramUI
    {
        private MenuRepository _menuRepository;
        private List<MenuItems> _menuItems;

        public ProgramUI()
        {
            _menuRepository = new MenuRepository();
            _menuItems = _menuRepository.GetMenuItems();
        }

        public void Run()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Hello, what would you like to do?\n" +
                    "1. Create Menu Item\n" +
                    "2. Delete Menu Item\n" +
                    "3. Display Menu Items\n" +
                    "4. Exit application");

                string inputAsString = Console.ReadLine();
                int input = int.Parse(inputAsString);

                switch (input)
                {
                    case 1:
                        CreateMenuItem();
                        break;
                    case 2:
                        DeleteMenuItem();
                        break;
                    case 3:
                        DisplayAllMenuItems();
                        break;
                    case 4:
                        running = false;
                        break;
                }
            }
        }

        public void CreateMenuItem()
        {
            Console.WriteLine("Please enter the number you would like to assign to this meal.");
            int mealNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the name of the meal.");
            string mealName = Console.ReadLine();

            Console.WriteLine("Enter all of the ingredients for this meal");

            List<string> ingredients = new List<string>();
            Console.WriteLine("Please enter an ingredient.");

            bool addMore = true;
            while (addMore)
            {
                string input = Console.ReadLine();

                if (input == "no")
                    addMore = false;
                else
                    addMore = true;

                ingredients.Add(input);
                Console.WriteLine("Would you like to enter another ingredient?");
            }

            Console.WriteLine("Enter the a description.");
            string description = Console.ReadLine();

            Console.WriteLine("Please enter the price.");
            decimal price = decimal.Parse(Console.ReadLine());

            MenuItems menuItem = new MenuItems(mealNumber, mealName, description, ingredients, price);

            _menuRepository.AddItemToMenu(menuItem);

            Console.WriteLine($"\"{menuItem.MealName}\" added to list.");
            Console.ReadKey();
        }

        private void DeleteMenuItem()
        {
            DisplayAllMenuItems();
            Console.WriteLine("Please select the meal number you would like to remove");
            int removalNumber = int.Parse(Console.ReadLine());

            _menuRepository.RemoveSpecificItem(removalNumber);

            Console.WriteLine($"\"{removalNumber}\" has been removed from the menu.");
            Console.ReadKey();
        }

        private void DisplayAllMenuItems()
        {
            foreach (MenuItems menuItem in _menuItems)
            {
                Console.WriteLine($" {menuItem.MealNumber} {menuItem.MealName} {menuItem.Ingredients} {menuItem.Description} {menuItem.Price}");
            }
        }
    }
}
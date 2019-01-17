using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challenge
{
    public class MenuRepository
    {
        List<MenuItems> _menuItems = new List<MenuItems>();

        public void AddItemToMenu(MenuItems menuItem)
        {
            _menuItems.Add(menuItem);
        }

        public void AddIngredientToList()
        {
            
        }

        public List<MenuItems> GetMenuItems()
        {
            return _menuItems;
        }

        public void RemoveMenuItem(MenuItems menuItem)
        {
            _menuItems.Remove(menuItem);
        }

        public void RemoveSpecificItem(int removalNumber)
        {
            foreach (MenuItems menuItems in _menuItems)
            {
                if (removalNumber == menuItems.MealNumber)
                    RemoveMenuItem(menuItems);
                break;
            }
        }
    }
}

using System;
using _01_Challenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_Challenge_Tests
{
    [TestClass]
    public class MenuRepository_Tests
    {
            [TestMethod]
        public void MenuItemsRepository_AddItemToMenu_ShouldReturnCorrectCount()
        {
            //Arrange
            MenuItems menuItem = new MenuItems();
            MenuItems itemTwo = new MenuItems();
            MenuRepository repo = new MenuRepository();

            //Act
            repo.AddItemToMenu(menuItem);
            repo.AddItemToMenu(itemTwo);

            int actual = repo.GetMenuItems().Count;
            int expected = 2;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MenuItemsRepository_RemoveItemFromMenu_ShouldReturnCorrectCount()
        {
            MenuItems menuItem = new MenuItems();
            MenuItems itemTwo = new MenuItems();
            MenuItems itemThree = new MenuItems();
            MenuRepository repo = new MenuRepository();

            //Act
            repo.AddItemToMenu(menuItem);
            repo.AddItemToMenu(itemTwo);
            repo.AddItemToMenu(itemThree);
            repo.RemoveMenuItem(itemTwo);

            int actual = repo.GetMenuItems().Count;
            int expected = 2;
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

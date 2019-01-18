using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimRepository_Tests
{
    [TestClass]
    public class ClaimRepository_Tests
    {
        [TestMethod]
        public void ClaimRepository_AddClaimToList_ShouldReturnCorrectCount()
        {
            //Arrange
            ClaimInformation claim = new ClaimInformation();
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
    }
}

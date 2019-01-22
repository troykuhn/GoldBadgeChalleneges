using System;
using System.Collections.Generic;
using _04_Challenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _04_Challenge_Tests
{
    [TestClass]
    public class BadgeRepository_Tests
    {
        [TestMethod]
        public void BadgeRepository_AddBadge_ShouldReturnCorrectCount()
        {
            //Arrange
            Badge badgeOne = new Badge(123, new List<string> { "A1" });
            Badge badgeTwo = new Badge(1234, new List<string> { "A2", "B3" });
            BadgeRepository repo = new BadgeRepository();

            //Act
            repo.AddBadge(badgeOne);
            repo.AddBadge(badgeTwo);

            int actual = repo.GetBadgeInfo().Count;
            int expected = 2;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BadgeRepository_RemoveBadge_ShouldReturnCorrectCount()
        {
            //Arrange
            Badge badgeOne = new Badge(123, new List<string> { "A1" });
            Badge badgeTwo = new Badge(1234, new List<string> { "A2", "B3" });
            Badge badgeThree = new Badge(12345, new List<string> {"A5", "B7" });
            BadgeRepository repo = new BadgeRepository();

            //Act
            repo.AddBadge(badgeOne);
            repo.AddBadge(badgeTwo);
            repo.AddBadge(badgeThree);
            repo.RemoveBadge(badgeTwo);

            int actual = repo.GetBadgeInfo().Count;
            int expected = 2;
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

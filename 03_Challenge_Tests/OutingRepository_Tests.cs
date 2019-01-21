using System;
using _03_Challenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Challenge_Tests
{
    [TestClass]
    public class OutingRepository_Tests
    {
        [TestMethod]
        public void OutingRepository_AddOutingToList_ShouldReturnCorrectCount()
        {
            //Arrange
            OutingInformation outing = new OutingInformation();
            OutingInformation outingTwo = new OutingInformation();
            OutingRepository repo = new OutingRepository();

            //Act
            repo.AddOutingToList(outing);
            repo.AddOutingToList(outingTwo);

            int actual = repo.GetOutingList().Count;
            int expected = 2;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OutingRepository_AddOutingCostByType_ShouldReturnCorrectCost()
        {
            //EventType type, int attendants, DateTime eventDate, decimal costPerPerson, decimal eventCost
            EventType type = EventType.Bowling;
            OutingRepository outingRepo = new OutingRepository();
            OutingInformation outing = new OutingInformation(EventType.Bowling, 45, DateTime.Now, 5.50m, 25000);
            OutingInformation outingOne = new OutingInformation(EventType.Bowling, 45, DateTime.Now, 5.50m, 25000);
            OutingInformation outingTwo = new OutingInformation(EventType.Bowling, 45, DateTime.Now, 5.50m, 25000);
            OutingInformation outingFour = new OutingInformation(EventType.Golf, 45, DateTime.Now, 5.50m, 25000);
            outingRepo.AddOutingToList(outing);
            outingRepo.AddOutingToList(outingOne);
            outingRepo.AddOutingToList(outingTwo);
            outingRepo.AddOutingToList(outingFour);

            decimal actual = outingRepo.CalculateCostByType(type);
            decimal expected = 75000m;

            Assert.AreEqual(expected, actual);

        }
    }
}

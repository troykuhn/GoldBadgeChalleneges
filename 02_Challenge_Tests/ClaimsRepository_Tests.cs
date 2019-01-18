using System;
using _02_Challenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Challenge_Tests
{
    [TestClass]
    public class ClaimsRepository_Tests
    {
        [TestMethod]
        public void ClaimsRepository_AddClaimToQueue_ShouldReturnCorrectCount()
        {
            //Arrange
            ClaimInformation claim = new ClaimInformation();
            ClaimInformation claimTwo = new ClaimInformation();
            ClaimRepository repo = new ClaimRepository();

            //Act
            repo.AddClaimToQueue(claim);
            repo.AddClaimToQueue(claimTwo);

            int actual = repo.GetClaimInformation().Count;
            int expected = 2;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClaimsRepository_RemoveClaimFromQueue_ShouldReturnCorrectCount()
        {
            //Arrange
            ClaimInformation claim = new ClaimInformation();
            ClaimInformation claimTwo = new ClaimInformation();
            ClaimInformation claimThree = new ClaimInformation();
            ClaimRepository repo = new ClaimRepository();

            //Act
            repo.AddClaimToQueue(claim);
            repo.AddClaimToQueue(claimTwo);
            repo.AddClaimToQueue(claimThree);
            repo.RemoveClaimFromQueue(claimTwo);

            int actual = repo.GetClaimInformation().Count;
            int expected = 2;
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

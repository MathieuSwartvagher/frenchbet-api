using FrenchBet.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Interfaces;
using Models.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace UnitTest
{
    public class FrenchBetTest
    {        
        private Mock<IFrenchBet> _FrenchBetServiceMock;
        private CommunityController _CommunityController;
        private Community community;

        [SetUp]
        public void Setup()
        {
            try
            {
                _FrenchBetServiceMock = new Mock<IFrenchBet>();
                _CommunityController = new CommunityController(_FrenchBetServiceMock.Object);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [TearDown]
        public void DeInitialize()
        {
            community = new Community();
        }

        [Test]
        public void TestGetUserExist()
        {
            //Arrange
            community = new Community() { ComName = "Les tontons parieurs", ComDesc = "On dégaine plus vite de Mbappe" };
            _FrenchBetServiceMock.Setup(x => x.GetCommunityByName("Les tontons parieurs")).Returns(community);

            //Act
            Community result = _CommunityController.GetUser(community);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsAssignableFrom<Community>(result);
            Assert.That(result.ComName, Is.EqualTo(community.ComName));
        }

        [Test]
        public void TestGetUserDontExist()
        {
            //Arrange
            community = new Community() { ComName = "Les parieurs"};
            _FrenchBetServiceMock.Setup(x => x.GetCommunityByName(It.IsAny<string>())).Returns(() => null);

            //Act
            Community result = _CommunityController.GetUser(community);

            //Assert
            Assert.IsNull(result);
        }
    }
}
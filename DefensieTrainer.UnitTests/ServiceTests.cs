using DefensieTrainer.Domain.DTO;
using DefensieTrainer.Domain.IRepositories;
using DefensieTrainer.Domain.IServices;
using DefensieTrainer.Domain.Service;
using Microsoft.AspNetCore.Authentication;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DefensieTrainer.UnitTests
{
    public class ServiceTests
    {
        [TestFixture]
        public class ClusterServiceTests
        {
            private Mock<IClusterRepository> _clusterRepositoryMock;
            private ClusterService _clusterService;
            private Mock<IPersonRepository> _personRepositoryMock;
            private PersonService _personService;


            [SetUp]
            public void SetUp()
            {
                _clusterRepositoryMock = new Mock<IClusterRepository>();
                _clusterService = new ClusterService(_clusterRepositoryMock.Object);
                _personRepositoryMock = new Mock<IPersonRepository>();
                _personService = new PersonService(_personRepositoryMock.Object);
            }

            [Test]
            public void GetAllClusters_ShouldReturnAllClusters()
            {
                //Arrange
                var clustersFromRepository = new List<ClusterDto>
            {
                new ClusterDto { ClusterLevel = 1, Description = "Cluster 1" },
                new ClusterDto { ClusterLevel = 2, Description = "Cluster 2" }
            };
                _clusterRepositoryMock.Setup(repo => repo.GetAllClusters()).Returns(clustersFromRepository);

                //Act
                var result = _clusterService.GetAllClusters();

                //Assert
                Assert.AreEqual(2, result.Count);
                Assert.AreEqual(1, result[0].ClusterLevel);
                Assert.AreEqual("Cluster 1", result[0].Description);
                Assert.AreEqual(2, result[1].ClusterLevel);
                Assert.AreEqual("Cluster 2", result[1].Description);

                _clusterRepositoryMock.Verify(repo => repo.GetAllClusters(), Times.Once);
            }


            [Test]
            public void AuthenticateUser_ShouldReturnUser_WhenEmailAndPasswordMatch()
            {
                // Arrange
                var email = "Admin@Admin.com";
                var password = "admin";
                var user = new PersonDto { Email = email, Password = password };
                _personRepositoryMock.Setup(repo => repo.GetUserByEmail(email)).Returns(user);

                //Act
                var result = _personService.AuthenticateUser(email, password);

                //Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(email, result.Email);
                Assert.AreEqual(password, result.Password);

                _personRepositoryMock.Verify(repo => repo.GetUserByEmail(email), Times.Once);
            }

            [Test]
            public void AuthenticateUser_ShouldReturnNull_WhenEmailDoesNotExist()
            {
                //Arrange
                var email = "Admin@Admin,com";
                var password = "Admin";
                _personRepositoryMock.Setup(repo => repo.GetUserByEmail(email)).Returns((PersonDto)null);

                //Act
                var result = _personService.AuthenticateUser(email, password);

                //Assert
                Assert.IsNull(result);
                _personRepositoryMock.Verify(repo => repo.GetUserByEmail(email), Times.Once);
            }
        }
    }
}

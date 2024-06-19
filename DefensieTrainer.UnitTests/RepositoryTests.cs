using DefensieTrainer.Domain.DTO;
using DefensieTrainer.Domain.IRepositories;
using DefensieTrainer.Domain.Service;
using Moq;

namespace DefensieTrainer.UnitTests
{
    [TestFixture]
    public class RepositoryTests
    {
        private Mock<IPersonRepository> _personRepositoryMock;
        private PersonService _personService;

        ReadPersonDto person1 = new()
        {
            Name = "Sirname",
            LastName = "Last",
            Length = 10,
            ArmedForce = "Marine",
            ArrivalDate = DateTime.Now,
            ClusterId = 2,
            Email = "sirname@sir.com",
            Id = 8,
            Password = "hashed",
            Role = Domain.Enums.Role.User,
            Weight = 88,
        };

        ReadPersonDto person2 = new()
        {
            Name = "Sirname2",
            LastName = "Last2",
            Length = 11,
            ArmedForce = "landmacht",
            ArrivalDate = DateTime.Now,
            ClusterId = 1,
            Email = "sirnamesir.com",
            Id = 10,
            Password = "hashed",
            Role = Domain.Enums.Role.User,
            Weight = 99,
        };

        [SetUp]
        public void SetUp()
        {
            _personRepositoryMock = new Mock<IPersonRepository>();
            _personService = new PersonService(_personRepositoryMock.Object);
            
        }

        [Test]
        public void GetAllUsers_ShouldReturnAllUsers()
        {
            //arrange
            List<ReadPersonDto> listPersonDto = new List<ReadPersonDto>();
            listPersonDto.Add(person1);
            listPersonDto.Add(person2 );
            _personRepositoryMock.Setup(repo => repo.GetAllUsers()).Returns(listPersonDto);
            //act
            var result = _personService.GetAllUsers();
            //assert
            Assert.That( result, Is.Not.Null );
            foreach ( ReadPersonDto personDto in result )
            {
                Assert.That(personDto.Email, Contains.Substring("@"));
                Assert.That(personDto.Id, Is.Positive);
            }
            _personRepositoryMock.Verify(repo => repo.GetAllUsers(), Times.Once);
        }
    }
}

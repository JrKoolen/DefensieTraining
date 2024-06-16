using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DefensieTrainer.Infrastructure;

namespace DefensieTrainer.UnitTests
{
    [TestFixture]
    internal class InfrastructureTests
    {
        [Test]
    public void GetSetting_ShouldReturnCorrectValue()
        {
            //Arrange
            var provider = new ConfigurationProvider();

            //Act
            string value = provider.GetConnectionString();

            //Assert
            Assert.IsNotNull(value);
            StringAssert.Contains("Database", value);
        }
    }
}

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

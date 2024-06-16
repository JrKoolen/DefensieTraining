using DefensieTrainer.Domain.Enums;

namespace UnitTestsDefensie
{
    public class EnumAndConstantsTests
    {

        [Test]
        public void RoleEnum_ShouldContainExpectedValues()
        {
            //assert
            Assert.AreEqual(1, (int)Role.User, "Role.User should have the value 1");
            Assert.AreEqual(2, (int)Role.Coach, "Role.Coach should have the value 2");
            Assert.AreEqual(3, (int)Role.Manager, "Role.Manager should have the value 3");
        }
    }
}

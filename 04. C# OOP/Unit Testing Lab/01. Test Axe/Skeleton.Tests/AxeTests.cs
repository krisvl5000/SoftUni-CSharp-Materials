using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private int attackPoints;
        private int durabilityPoints;

        [SetUp]
        public void Setup()
        {
            attackPoints = 10;
            durabilityPoints = 15;
            Axe axe = new Axe(attackPoints, durabilityPoints);
        }

        [Test]
        public void Test_AxeConstructorShouldSetDataProperly()
        {
            Assert.AreEqual(10, axe.AttackPoints);
            Assert.AreEqual(15, axe.DurabilityPoints);
        }
    }
}
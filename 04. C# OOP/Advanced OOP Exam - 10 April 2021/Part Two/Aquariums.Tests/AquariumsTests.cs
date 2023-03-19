using NUnit.Framework;

namespace Aquariums.Tests
{
    using System;

    public class AquariumsTests
    {
        private Fish fish;
        private Aquarium aquarium;

        [SetUp]
        public void SetUp()
        {
            fish = new Fish("Fish");
            aquarium = new Aquarium("Aquarium", 3);
        }

        [Test]
        public void Test_IsTheConstructorWorking()
        {
            Assert.That( aquarium.Name == "Aquarium" &&aquarium.Capacity == 3 && aquarium.Count == 0);
        }

        [Test]
        public void Test_IsTheConstructorThrowingForAnEmptyName()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                aquarium = new Aquarium("", 5);
            });
        }
    }
}

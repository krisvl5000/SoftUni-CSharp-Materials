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
            Assert.That(aquarium.Name == "Aquarium" && aquarium.Capacity == 3 && aquarium.Count == 0);
        }

        [Test]
        public void Test_IsTheConstructorThrowingForAnEmptyName()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                aquarium = new Aquarium("", 5);
            });
        }

        [Test]
        public void Test_IsTheConstructorThrowingForNegativeCapacity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                aquarium = new Aquarium("Name", -1);
            });
        }

        [Test]
        public void Test_IsAddWorking()
        {
            aquarium.Add(fish);
            Assert.That(aquarium.Count == 1);
        }

        [Test]
        public void Test_IsAddThrowingWhenWeSurpassTheCapacity()
        {
            aquarium.Add(fish);
            aquarium.Add(fish);
            aquarium.Add(fish);

            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(fish);
            });
        }

        [Test]
        public void Test_IsRemoveFishWorking()
        {
            aquarium.Add(fish);
            aquarium.RemoveFish("Fish");
            Assert.That(aquarium.Count == 0);
        }

        [Test]
        public void Test_IsRemoveFishThrowingIfWePassANameForANonExistentFish()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish("Some Other Name");
            });
        }

        [Test]
        public void Test_IsSellFishWorking()
        {
            aquarium.Add(fish);
            Assert.That(fish == aquarium.SellFish("Fish") && fish.Available == false);
        }

        [Test]
        public void Test_IsSellFishThrowingIfWePassANameForANonExistentFish()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.SellFish("Some Other Name");
            });
        }

        [Test]
        public void Test_IsReportWorking()
        {
            aquarium.Add(fish);
            Assert.That(aquarium.Report() == $"Fish available at Aquarium: Fish"); 
        }
    }
}

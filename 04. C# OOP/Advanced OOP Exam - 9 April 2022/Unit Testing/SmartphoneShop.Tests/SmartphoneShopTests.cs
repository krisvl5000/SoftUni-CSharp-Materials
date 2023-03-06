using System;
using System.ComponentModel.DataAnnotations;
using NUnit.Framework;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Smartphone smartphone;
        private Shop shop;
        private string modelName = "IPhone 13 Pro Max";
        private int maximumBatteryCharge = 100;
        private int capacity = 3;

        [SetUp]
        public void SetUp()
        {
            smartphone = new Smartphone(modelName, maximumBatteryCharge);
            shop = new Shop(3);
        }

        [Test]
        public void Test_ConstructorIsSettingCorrectly()
        {
            Assert.AreEqual(capacity, shop.Capacity);
            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void Test_NegativeOrZeroCapacityShouldThrow()
        {
            Assert.Throws<ArgumentException>(() => { shop = new Shop(-5); });
        }

        [Test]
        public void Test_AddSmartphoneShouldWork()
        {
            shop.Add(smartphone);
            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void Test_AddSmartphoneThatExistsShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(smartphone);
                shop.Add(smartphone);
            });
        }

        [Test]
        public void Test_ThrowsIfCapacityIsFull()
        {
            shop.Add(new Smartphone("1", 1));
            shop.Add(new Smartphone("2", 1));
            shop.Add(new Smartphone("3", 1));

            Assert.Throws<InvalidOperationException>(() => { shop.Add(new Smartphone("4", 1)); });
        }

        [Test]
        public void Test_RemoveSmartphoneShouldWork()
        {
            shop.Add(smartphone);
            shop.Remove(smartphone.ModelName);

            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void Test_ShouldThrowWhenPhoneIsNotFound()
        {
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() => { shop.Remove("Test"); });
        }

        [Test]
        public void Test_TestPhoneShouldReduceBatteryCharge()
        {
            shop.Add(smartphone);
            shop.TestPhone(modelName, 50);

            Assert.AreEqual(maximumBatteryCharge - 50, smartphone.CurrentBateryCharge);
        }

        [Test]
        public void Test_TestPhoneShouldThrowWhenPhoneIsNotFound()
        {
            Assert.Throws<InvalidOperationException>(() => { shop.TestPhone("Test", 10); });
        }

        [Test]
        public void Test_TestPhoneShouldNotWorkOnUnchargedPhones()
        {
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() => { shop.TestPhone(modelName, maximumBatteryCharge + 100); });
        }

        [Test]
        public void Test_ChargePhoneShouldThrowWhenPhoneIsNotFound()
        {
            Assert.Throws<InvalidOperationException>(() => { shop.ChargePhone("Test"); });
        }

        [Test]
        public void Test_ChargePhoneShouldSetBatteryToMax()
        {
            shop.Add(smartphone);

            shop.TestPhone(modelName, 50);

            shop.ChargePhone(modelName);

            Assert.AreEqual(maximumBatteryCharge, smartphone.CurrentBateryCharge);
        }
    }
}
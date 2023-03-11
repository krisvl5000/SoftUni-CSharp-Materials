using System;
using NUnit.Framework;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            private Car car;
            private Garage garage;

            [SetUp]
            public void SetUp()
            {
                car = new Car("Model", 5);
                garage = new Garage("Garage", 1);
            }

            [Test]
            public void Test_IsTheGarageConstructorWorking()
            {
                Assert.That(garage.Name == "Garage" && garage.MechanicsAvailable == 5);
            }

            [Test]
            public void Test_IsTheCarListInstantiated()
            {
                Assert.That(garage.CarsInGarage == 0);
            }

            [Test]
            public void Test_AreTheCarsProperlyAdded()
            {
                garage.AddCar(car);
                Assert.That(garage.CarsInGarage == 1);
            }

            [Test]
            public void Test_DoesItThrowForInvalidName()
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    garage = new Garage("", 5);
                });
            }

            [Test]
            public void Test_DoesItThrowForInvalidMechanics()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    garage = new Garage("Name", -5);
                });
            }

            [Test]
            public void Test_DoesItThrowWhenThereAreNoAvailableMechanics()
            {
                garage.AddCar(car);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.AddCar(car);
                });
            }
        }
    }
}
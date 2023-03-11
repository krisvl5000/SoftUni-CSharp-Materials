using System;
using System.Security.Cryptography.X509Certificates;
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
                Assert.That(garage.Name == "Garage" && garage.MechanicsAvailable == 1);
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

            [Test]
            public void Test_DoesItThrowWhenThereAreIsNoSuchCar()
            {
                garage.AddCar(car);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar("SomeOtherModel");
                });
            }

            [Test]
            public void Test_IsTheFixCarMethodWorkingProperly()
            {
                garage.AddCar(car);
                garage.FixCar("Model");

                Assert.That(car.NumberOfIssues == 0);
            }

            [Test]
            public void Test_IsTheFixCarMethodReturningTheCar()
            {
                garage.AddCar(car);
                Assert.AreEqual(car, garage.FixCar("Model"));
            }

            [Test]
            public void Test_IsRemoveFixedCarThrowingWhenThereAreNoCarsToRepair()
            {
                garage.AddCar(car);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();
                });
            }

            [Test]
            public void Test_RemoveFixedCarWorkingProperly()
            {
                garage.AddCar(car);
                garage.FixCar("Model");
                garage.RemoveFixedCar();

                Assert.That(garage.CarsInGarage == 0);
            }

            [Test]
            public void Test_ReportWorkingProperly()
            {
                garage.AddCar(car);

                Assert.AreEqual($"There are 1 which are not fixed: Model.", garage.Report());
            }
        }
    }
}
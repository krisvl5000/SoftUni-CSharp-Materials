using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            private Planet planet;

            [SetUp]
            public void SetUp()
            {
                planet = new Planet("Name", 10.0);
            }

            [Test]
            public void TestingConstructorNameForPlanet()
            {
                Assert.AreEqual("Name", planet.Name);
            }

            [Test]
            public void TestingConstructorPriceForPlanet()
            {
                Assert.AreEqual(10.0, planet.Budget);
            }

            [Test]
            public void TestingConstructorWeaponsForPlanet()
            {
                Assert.AreEqual(planet.Weapons, new List<Weapon>());
            }

            [Test]
            public void Test_DoesPlanetThrowExceptionForInvalidName()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    planet = new Planet("", 10.0);
                });
            }

            [Test]
            public void Test_DoesPlanetThrowExceptionForInvalidBudget()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    planet = new Planet("Name", -5);
                });
            }

            [Test]
            public void Test_IsProfitWorking()
            {
                planet.Profit(50);

                Assert.AreEqual(60.0, planet.Budget);
            }

            [Test]
            public void Test_IsSpendFundsWorkingWithValidValues()
            {
                planet.SpendFunds(5.0);
                Assert.AreEqual(5.0, planet.Budget);
            }

            [Test]
            public void Test_IsSpendFundsThrowingWithInvalidValues()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(11.0);
                });
            }
        }
    }
}

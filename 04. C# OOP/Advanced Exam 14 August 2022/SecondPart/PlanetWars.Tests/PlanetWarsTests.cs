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
            private Planet weakerPlanet;
            private Planet strongerPlanet;

            private Weapon weapon;
            private Weapon weakerWeapon;
            private Weapon strongerWeapon;

            [SetUp]
            public void SetUp()
            {
                planet = new Planet("Name", 10.0);
                weakerPlanet = new Planet("WeakerPlanet", 5.0);
                strongerPlanet = new Planet("StrongerPlanet", 15.0);

                weapon = new Weapon("Name", 10.0, 10);
                weakerWeapon = new Weapon("WeakerWeapon", 10, 5);
                strongerWeapon = new Weapon("StrongerWeapon", 10, 15);
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

            [Test]
            public void Test_IsAddWeaponWorkingProperly()
            {
                planet.AddWeapon(weapon);
                Assert.AreEqual(1, planet.Weapons.Count);
            }

            [Test]
            public void Test_IsAddWeaponThrowingWhenTheSameNameIsAdded()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(weapon);
                    var newWeapon = new Weapon("Name", 10.0, 10);
                    planet.AddWeapon(newWeapon);
                });
            }

            [Test]
            public void Test_IsRemoveWeaponWorkingProperly()
            {
                planet.AddWeapon(weapon);
                planet.RemoveWeapon("Name");
                Assert.AreEqual(0, planet.Weapons.Count);
            }

            [Test]
            public void Test_IsUpgradeWeaponWorkingProperly()
            {
                planet.AddWeapon(weapon);
                planet.UpgradeWeapon("Name");
                Assert.AreEqual(11, weapon.DestructionLevel);
            }

            [Test]
            public void Test_IsRemoveWeaponThrowingWhenNameIsNotFound()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon("NonExistentName");
                });
            }

            [Test]
            public void Test_IsDestroyOpponentWorkingProperly()
            {
                planet.AddWeapon(weapon);
                weakerPlanet.AddWeapon(weakerWeapon);
                Assert.AreEqual($"WeakerPlanet is destructed!", planet.DestructOpponent(weakerPlanet));
            }

            [Test]
            public void Test_IsDestroyThrowingWhenFightingStrongerPlanet()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(weapon);
                    strongerPlanet.AddWeapon(strongerWeapon);
                    planet.DestructOpponent(strongerPlanet);
                });
            }
        }
    }
}

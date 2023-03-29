using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            private Planet planet;
            private Weapon weapon;

            [SetUp]
            public void SetUp()
            {
                planet = new Planet("Planet", 10.0);
                weapon = new Weapon("Weapon", 10.0, 10);
            }

            [Test]
            public void Test_IsConstructorWorking()
            {
                Assert.That(planet.Budget == 10.0 && planet.Name == "Planet" && planet.Weapons.Count == 0);
            }

            [Test]
            public void Test_IsConstructorThrowingIfTheNameIsNullOrEmpty()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    planet = new Planet("", 10.0);
                });
            }

            [Test]
            public void Test_IsConstructorThrowingIfTheBudgetIsBelowZero()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    planet = new Planet("Name", -10.0);
                });
            }

            [Test]
            public void Test_IsMilitaryPowerRatioProperlyCalculated()
            {
                planet.AddWeapon(weapon);
                planet.AddWeapon(new Weapon("Second Weapon", 0.0, 10));
                planet.AddWeapon(new Weapon("Third Weapon", 0.0, 10));

                Assert.That(planet.MilitaryPowerRatio == 30.0);
            }

            [Test]
            public void Test_IsAddWeaponWorkingProperly()
            {
                planet.AddWeapon(weapon);

                Assert.That(planet.Weapons.Count == 1);
            }

            [Test]
            public void Test_IsAddWeaponThrowingWhenTheSameWeaponIsAddedAgain()
            {
                planet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(weapon);
                });
            }

            [Test]
            public void Test_ProfitWorkingProperly()
            {
                planet.Profit(20.0);

                Assert.That(planet.Budget == 30.0);
            }

            [Test]
            public void Test_SpendFundsWorkingProperly()
            {
                planet.SpendFunds(5.0);

                Assert.That(planet.Budget == 5.0);
            }

            [Test]
            public void Test_IsSpendFundsThrowingWhenSpendingMoreThanBudget()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(20.0);
                });
            }

            [Test]
            public void Test_IsRemoveWeaponWorkingProperly()
            {
                planet.AddWeapon(weapon);
                planet.RemoveWeapon("Weapon");

                Assert.That(planet.Weapons.Count == 0);
            }

            [Test]
            public void Test_IsUpgradeWeaponWorkingProperly()
            {
                planet.AddWeapon(weapon);
                planet.UpgradeWeapon("Weapon");

                Assert.That(planet.MilitaryPowerRatio == 11.0);
            }

            [Test]
            public void Test_IsUpgradeThrowingForNonExistentWeapon()
            {
                planet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon("NonExistentWeapon");
                });
            }

            [Test]
            public void Test_IsDestructOpponentWorkingProperly()
            {
                planet.AddWeapon(weapon);

                var opponent = new Planet("Opponent", 10.0);

                Assert.That(planet.DestructOpponent(opponent) == $"Opponent is destructed!");
            }

            [Test]
            public void Test_IsUpgradeThrowingForStrongerOrEqualOpponent()
            {
                var opponent = new Planet("Opponent", 10.0);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.DestructOpponent(opponent);
                });
            }
        }
    }
}

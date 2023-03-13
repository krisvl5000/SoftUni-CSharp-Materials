using System;
using NUnit.Framework;

namespace Gyms.Tests
{
    public class GymsTests
    {
        private Athlete athlete;
        private Gym gym;

        [SetUp]
        public void SetUp()
        {
            athlete = new Athlete("Athlete");
            gym = new Gym("Gym", 3);
        }

        [Test]
        public void Test_IsConstructorWorking()
        {
            Assert.That(gym.Name == "Gym" && gym.Capacity == 3);
        }

        [Test]
        public void Test_IsGymThrowingWhenInvalidNameIsGiven()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                gym = new Gym("", 3);
            });
        }

        [Test]
        public void Test_IsGymThrowingWhenInvalidCapacityIsGiven()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                gym = new Gym("Gym", -1);
            });
        }

        [Test]
        public void Test_CountWorking()
        {
            Assert.That(gym.Count == 0);
        }

        [Test]
        public void Test_IsAddAthleteWorking()
        {
            gym.AddAthlete(athlete);
            Assert.That(gym.Count == 1);
        }

        [Test]
        public void Test_IsAddAthleteThrowingWhenMoreThanCapAreAddedWorking()
        {
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(athlete);
            });
        }

        [Test]
        public void Test_IsRemoveAthleteWorking()
        {
            gym.AddAthlete(athlete);
            gym.RemoveAthlete("Athlete");

            Assert.That(gym.Count == 0);
        }

        [Test]
        public void Test_IsRemoveAthleteThrowingWhenNonExistentIsSearched()
        {
            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete("Name");
            });
        }

        [Test]
        public void Test_IsInjureAthleteWorking()
        {
            gym.AddAthlete(athlete);
            gym.InjureAthlete("Athlete");

            Assert.That(athlete.IsInjured);
        }

        [Test]
        public void Test_IsInjureAthleteThrowingWhenNonExistentIsSearched()
        {
            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete("Name");
            });
        }

        [Test]
        public void Test_IsReportWorking()
        {
            gym.AddAthlete(athlete);

            Assert.That(gym.Report() == "Active athletes at Gym: Athlete");
        }
    }
}

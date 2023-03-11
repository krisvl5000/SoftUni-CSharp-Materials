using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace FootballTeam.Tests
{
    public class Tests
    {
        private FootballPlayer player;
        private FootballTeam team;

        [SetUp]
        public void Setup()
        {
            player = new FootballPlayer("Name", 1, "Forward");
            team = new FootballTeam("Team", 20);
        }

        [Test]
        public void Test_IsPlayerConstructorWorking()
        {
            Assert.That(player.Name == "Name" && player.PlayerNumber == 1 && player.Position == "Forward");
        }

        [Test]
        public void Test_IsTeamConstructorWorking()
        {
            Assert.That(team.Name == "Team" && team.Capacity == 20 && team.Players.Count == 0);
        }

        [Test]
        public void Test_IsTeamThrowingIfTheNameIsInvalid()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                team = new FootballTeam("", 20);
            });
        }

        [Test]
        public void Test_IsTeamThrowingIfCapacityIsInvalid()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                team = new FootballTeam("Name", 5);
            });
        }

        [Test]
        public void Test_IsAddNewPlayerWorking()
        {
            Assert.That(team.AddNewPlayer(player) == $"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}");
        }

        [Test]
        public void Test_IsAddNewPlayerWorkingIfWeSurpassTheCapacity()
        {
            for (int i = 0; i < team.Capacity; i++)
            {
                team.AddNewPlayer(player);
            }

            Assert.That(team.AddNewPlayer(player) == "No more positions available!");
        }

        [Test]
        public void Test_PickPlayerWorking()
        {
            team.AddNewPlayer(player);
            Assert.That(team.PickPlayer("Name") == player);
        }

        [Test]
        public void Test_PickPlayerWorkingIfTeamIsEmpty()
        {
            Assert.That(team.PickPlayer("Name") == null);
        }

        [Test]
        public void Test_PlayerScoreWorking()
        {
            team.AddNewPlayer(player);
            Assert.That(team.PlayerScore(1) == $"{player.Name} scored and now has {player.ScoredGoals} for this season!");
        }

    }
}
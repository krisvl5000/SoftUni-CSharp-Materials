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

        //[Test]
        //public void Test_IsPlayerThrowingIfPositionIsInvalid()
        //{
        //    Assert.Throws<ArgumentException>(() =>
        //    {
        //        player = new FootballPlayer("Name", 5, "Something");

        //        team.AddNewPlayer(player);
        //    });
        //}

        [Test]
        public void Test_IsAddNewPlayerWorking()
        {
            //team.AddNewPlayer(player);
            Assert.That(team.AddNewPlayer(player) == $"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}");
        }

    }
}
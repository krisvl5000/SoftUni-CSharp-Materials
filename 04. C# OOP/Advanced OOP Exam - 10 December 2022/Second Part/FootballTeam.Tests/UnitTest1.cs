using System;
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
            player = new FootballPlayer("Player", 10, "Forward");

            team = new FootballTeam("Team", 25);
        }

        [Test]
        public void Test_IsConstructorWorking()
        {
            Assert.That(team.Name == "Team" && team.Capacity == 25 && team.Players.Count == 0);
        }

        [Test]
        public void Test_IsTeamThrowingForAnEmptyName()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                team = new FootballTeam("", 25);
            });
        }

        [Test]
        public void Test_IsTeamThrowingForAnInvalidCapacity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                team = new FootballTeam("Name", 5);
            });
        }

        [Test]
        public void Test_IsAddPlayerWorkingWhenReachingTheMax()
        {
            for (int i = 0; i < 25; i++)
            {
                team.AddNewPlayer(player);
            }

            Assert.AreEqual("No more positions available!", team.AddNewPlayer(player));
        }

        [Test]
        public void Test_IsAddPlayerWorkingWhenBelowTheLimit()
        {
            for (int i = 0; i < 20; i++)
            {
                team.AddNewPlayer(player);
            }

            Assert.AreEqual($"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}", team.AddNewPlayer(player));
        }

        [Test]
        public void Test_PickPlayerWorking()
        {
            team.AddNewPlayer(player);

            Assert.That(team.PickPlayer("Player").Name == player.Name);
        }

        [Test]
        public void Test_PickPlayerWorkingWhenThereIsNoSuchPlayer()
        {
            team.AddNewPlayer(player);

            Assert.That(team.PickPlayer("Non existent Player") == null);
        }

        [Test]
        public void Test_PlayerScoreWorking()
        {
            team.AddNewPlayer(player);

            Assert.That(team.PlayerScore(10) == $"{player.Name} scored and now has {player.ScoredGoals} for this season!");
        }
    }
}
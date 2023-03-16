﻿using NUnit.Framework;

namespace Robots.Tests
{
    using System;

    public class RobotsTests
    {
        private Robot robot;
        private RobotManager manager;

        [SetUp]
        public void SetUp()
        {
            robot = new Robot("Robot", 100);
            manager = new RobotManager(3);
        }

        [Test]
        public void Test_IsTheConstructorWorking()
        {
            Assert.That(manager.Capacity == 3 && manager.Count == 0);
        }

        [Test]
        public void Test_DoesTheConstructorThrowForInvalidValues()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                manager = new RobotManager(-1);
            });
        }

        [Test]
        public void Test_IsAddRobotWorking()
        {
            manager.Add(robot);
            Assert.That(manager.Count == 1);
        }

        [Test]
        public void Test_IsAddRobotThrowingIfWeAddAnAlreadyExistingRobot()
        {
            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Add(robot);
            });
        }

        [Test]
        public void Test_IsAddRobotThrowingIfWeAddMoreThanTheCapacity()
        {
            manager.Add(robot);
            manager.Add(new Robot("Name", 100));
            manager.Add(new Robot("Other Test Robot", 150));

            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Add(new Robot("Other Name", 100));
            });
        }
    }
}

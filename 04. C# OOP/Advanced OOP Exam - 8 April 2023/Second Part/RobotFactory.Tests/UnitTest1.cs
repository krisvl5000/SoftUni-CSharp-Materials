using NUnit.Framework;

namespace RobotFactory.Tests
{
    public class Tests
    {
        private Robot robot;
        private Supplement supplement;
        private Factory factory;

        [SetUp]
        public void Setup()
        {
            robot = new Robot("Model", 10.00, 10);
            supplement = new Supplement("Supplement", 10);
            factory = new Factory("Factory", 3);
        }

        [Test]
        public void Test_IsRobotConstructorWorking()
        {
            Assert.That(robot.Model == "Model" && robot.Price == 10.00 && robot.InterfaceStandard == 10);
        }

        [Test]
        public void Test_IsSupplementConstructorWorking()
        {
            Assert.That(supplement.Name == "Supplement" && supplement.InterfaceStandard == 10);
        }

        [Test]
        public void Test_IsFactoryConstructorWorking()
        {
            Assert.That(factory.Name == "Factory" && factory.Capacity == 3);
            Assert.That(factory.Robots.Count == 0);
            Assert.That(factory.Supplements.Count == 0);
        }

        [Test]
        public void Test_IsProduceRobotWorking()
        {
            Assert.That(factory.ProduceRobot("Robot", 10.00, 10) == "Produced --> Robot model: Robot IS: 10, Price: 10.00");
            Assert.That(factory.Robots.Count == 1);
        }

        [Test]
        public void Test_IsProduceRobotWorkingIfAboveCapacity()
        {
            factory.ProduceRobot("Robot", 10.00, 10);
            factory.ProduceRobot("Robot", 10.00, 10);
            factory.ProduceRobot("Robot", 10.00, 10);

            Assert.That(factory.ProduceRobot("Robot", 10.00, 10) == "The factory is unable to produce more robots for this production day!");
        }

        [Test]
        public void Test_IsProduceSupplementWorking()
        {
            Assert.That(factory.ProduceSupplement("Supplement", 10) == "Supplement: Supplement IS: 10");
            Assert.That(factory.Supplements.Count == 1);
        }

        [Test]
        public void Test_IsUpgradeRobotWorking()
        {
            Assert.That(factory.UpgradeRobot(robot, supplement));
            Assert.That(robot.Supplements.Count == 1);
        }

        [Test]
        public void Test_IsUpgradeRobotWorkingIfThereIsSuchASupplement()
        {
            factory.UpgradeRobot(robot, supplement);
            Assert.That(!factory.UpgradeRobot(robot, supplement));
        }

        [Test]
        public void Test_IsUpgradeRobotWorkingIfThereIsNoSuchInterfaceStandard()
        {
            factory.UpgradeRobot(robot, supplement);
            Assert.That(!factory.UpgradeRobot(new Robot("Robot2", 10.00, 11), supplement));
        }

        [Test]
        public void Test_IsSellRobotMethodWorking()
        {
            factory.ProduceRobot("Robot1", 5.00, 10);
            factory.ProduceRobot("Robot2", 10.00, 10);
            factory.ProduceRobot("Robot3", 15.00, 10);

            Assert.That(factory.SellRobot(10).Model == "Robot2");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Utilities.Messages;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private SupplementRepository supplements;
        private RobotRepository robots;
        public Controller()
        {
            supplements = new SupplementRepository();
            robots = new RobotRepository();
        }

        public string CreateRobot(string model, string typeName)
        {
            if (typeName != nameof(DomesticAssistant) && typeName != nameof(IndustrialAssistant))
            {
                return String.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }

            IRobot robot = null;

            if (typeName == nameof(DomesticAssistant))
            {
                robot = new DomesticAssistant(model);
            }
            else
            {
                robot = new IndustrialAssistant(model);
            }

            robots.AddNew(robot);

            return String.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
        }

        public string CreateSupplement(string typeName)
        {
            if (typeName != nameof(SpecializedArm) && typeName != nameof(LaserRadar))
            {
                return String.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }

            ISupplement supplement = null;

            if (typeName == nameof(SpecializedArm))
            {
                supplement = new SpecializedArm();
            }
            else
            {
                supplement = new LaserRadar();
            }

            supplements.AddNew(supplement);

            return String.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            var interfaceValue = supplements.Models().FirstOrDefault(x => x.GetType().Name == supplementTypeName)
                .InterfaceStandard;

            var robotsNotSupporting = robots.Models().Where(x => !x.InterfaceStandards.Contains(interfaceValue)).ToList();

            var robotsFromTheGivenModel = robotsNotSupporting.Where(x => x.Model == model).ToList();

            if (robotsFromTheGivenModel.Count == 0)
            {
                return String.Format(OutputMessages.AllModelsUpgraded, model);
            }

            var robotToUpgrade = robotsFromTheGivenModel.First();
            var supplementToUse = supplements.Models().FirstOrDefault(x => x.GetType().Name == supplementTypeName);

            robotToUpgrade.InstallSupplement(supplementToUse);
            supplements.RemoveByName(supplementTypeName);

            return String.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);
        }

        public string RobotRecovery(string model, int minutes)
        {
            var robotsToFeed = robots.Models()
                .Where(x => x.Model == model)
                .Where(x => x.BatteryLevel < x.BatteryCapacity / 2)
                .ToList();

            var counter = 0;

            foreach (var robot in robotsToFeed)
            {
                robot.Eating(minutes);
                counter++;
            }

            return String.Format(OutputMessages.RobotsFed, counter);
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            var robotsSupporting = robots.Models().Where(x => x.InterfaceStandards.Contains(intefaceStandard)).ToList();

            if (robotsSupporting.Count == 0)
            {
                return String.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }

            var orderedRobots = robotsSupporting.OrderByDescending(x => x.BatteryLevel).ToList();

            var sumOfBatteryLevel = orderedRobots.Sum(x => x.BatteryLevel);

            var powerNeeded = totalPowerNeeded - sumOfBatteryLevel;

            if (sumOfBatteryLevel < totalPowerNeeded)
            {
                return String.Format(OutputMessages.MorePowerNeeded, serviceName, powerNeeded);
            }

            int robotCounter = 0;

            foreach (var robot in orderedRobots)
            {
                robotCounter++;

                if (robot.BatteryLevel >= totalPowerNeeded)
                {
                    robot.ExecuteService(totalPowerNeeded);
                    break;
                }

                totalPowerNeeded -= robot.BatteryLevel;
                robot.ExecuteService(robot.BatteryLevel);
            }

            return String.Format(OutputMessages.PerformedSuccessfully, serviceName, robotCounter);
        }

        public string Report()
        {
            var orderedRobots = robots.Models()
                .OrderByDescending(x => x.BatteryLevel)
                .ThenBy(x => x.BatteryCapacity)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var robot in orderedRobots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}

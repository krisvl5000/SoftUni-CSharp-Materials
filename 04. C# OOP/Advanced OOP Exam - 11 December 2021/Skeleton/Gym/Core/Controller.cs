using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private List<IGym> gyms;
        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym newGym = null;

            if (gymType == nameof(BoxingGym))
            {
                newGym = new BoxingGym(gymName);
            }
            else if (gymType == nameof(WeightliftingGym))
            {
                newGym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidGymType));
            }

            gyms.Add(newGym);
            return String.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment newEquipment = null;

            if (equipmentType == nameof(BoxingGloves))
            {
                newEquipment = new BoxingGloves();
            }
            else if (equipmentType == nameof(Kettlebell))
            {
                newEquipment = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidEquipmentType));
            }

            equipment.Add(newEquipment);
            return String.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            var gym = gyms.First(x => x.Name == gymName);

            var equipment = this.equipment.FindByType(equipmentType);

            if (equipment == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            gym.AddEquipment(equipment);

            return String.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            var gym = gyms.First(x => x.Name == gymName);

            if (athleteType != nameof(Boxer) && athleteType != nameof(Weightlifter))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            IAthlete athlete = null;

            if (athleteType == nameof(Boxer))
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }

            if ((athlete.GetType().Name == nameof(Boxer) && gym.GetType().Name == nameof(WeightliftingGym)) || (athlete.GetType().Name == nameof(Weightlifter) && gym.GetType().Name == nameof(BoxingGym)))
            {
                return String.Format(OutputMessages.InappropriateGym);
            }

            gym.Athletes.Add(athlete);
            return String.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);


        }

        public string TrainAthletes(string gymName)
        {
            var gym = gyms.First(x => x.Name == gymName);

            gym.Exercise();

            return String.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }

        public string EquipmentWeight(string gymName)
        {
            throw new NotImplementedException();
        }

        public string Report()
        {
            throw new NotImplementedException();
        }
    }
}

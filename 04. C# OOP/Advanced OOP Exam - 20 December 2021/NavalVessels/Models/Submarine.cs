using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavalVessels.Models.Contracts;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const double INITIAL_ARMOR_THICKNESS = 200;
        public Submarine(string name, double mainMainWeaponCaliber, double speed) : base(name, mainMainWeaponCaliber, speed, INITIAL_ARMOR_THICKNESS)
        {
            SubmergeMode = false;
        }

        public override void RepairVessel()
        {
            ArmorThickness = INITIAL_ARMOR_THICKNESS;
        }

        public bool SubmergeMode { get; private set; }

        public void ToggleSubmergeMode()
        {
            SubmergeMode = !SubmergeMode;

            if (SubmergeMode)
            {
                MainWeaponCaliber += 40;
                Speed -= 4;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 4;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {Name}");
            sb.AppendLine($"*Type: {this.GetType().Name}");
            sb.AppendLine($"*Armor thickness: {ArmorThickness}");
            sb.AppendLine($"*Main weapon caliber: {MainWeaponCaliber}");
            sb.AppendLine($"*Speed: {Speed} knots");

            if (Targets.Count > 0)
            {
                sb.AppendLine($"Targets: {String.Join(", ", Targets)}");
            }
            else
            {
                sb.AppendLine("Targets: None");
            }

            sb.AppendLine(SubmergeMode ? $"*Submerge mode: ON" : $"*Submerge mode: OFF");

            return sb.ToString().Trim();
        }
    }
}

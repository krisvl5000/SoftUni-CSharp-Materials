using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavalVessels.Models.Contracts;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const double INITIAL_ARMOR_THICKNESS = 300;
        public Battleship(string name, double mainMainWeaponCaliber, double speed) : base(name, mainMainWeaponCaliber, speed, INITIAL_ARMOR_THICKNESS)
        {
            SonarMode = false;
        }

        public bool SonarMode { get; private set; }

        public void ToggleSonarMode()
        {
            SonarMode = !SonarMode;

            if (SonarMode)
            {
                MainWeaponCaliber += 40;
                Speed -= 5;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 5;
            }
        }

        public override void RepairVessel()
        {
            ArmorThickness = INITIAL_ARMOR_THICKNESS;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {Speed} knots");

            if (Targets.Count > 0)
            {
                sb.AppendLine($" *Targets: {String.Join(", ", Targets)}");
            }
            else
            {
                sb.AppendLine(" *Targets: None");
            }

            sb.AppendLine(SonarMode ? $" *Sonar mode: ON" : $" *Sonar mode: OFF");

            return sb.ToString().Trim();
        }
    }
}

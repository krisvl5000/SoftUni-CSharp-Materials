using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl
{
    public class Robot : IRobot
    {
        public Robot()
        {

        }

        public Robot(string model, int id) : this()
        {
            Model = model;
            Id = id;
        }

        public string Model {get;set;}

        public int Id {get;set;}
    }
}

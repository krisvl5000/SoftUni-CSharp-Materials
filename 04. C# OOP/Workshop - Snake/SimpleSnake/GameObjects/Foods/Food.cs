using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food : Point
    {
        protected Food(int leftX, int topY) : base(leftX, topY)
        {
        }

        public int FoodPoints { get; private set; }
    }
}

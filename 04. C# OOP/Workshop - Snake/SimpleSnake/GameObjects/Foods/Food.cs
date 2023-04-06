using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food : Point
    {
        private char foodSymbol;
        private Random random;
        private Wall wall;

        protected Food(Wall wall, char foodSymbol, int points) 
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.foodSymbol = foodSymbol;
            FoodPoints = points;
            random = new Random();
        }

        public int FoodPoints { get; private set; }

        public void SetRandomPosition(Queue<Point> snakeElements)
        {
            LeftX = random.Next(2, wall.LeftX - 2);
            TopY = random.Next(2, wall.TopY - 2);

            bool isPointOfSnake = snakeElements
                .Any(x => x.LeftX == LeftX && x.TopY == TopY);

            while (isPointOfSnake)
            {
                LeftX = random.Next(2, wall.LeftX - 2);
                TopY = random.Next(2, wall.TopY - 2);

                isPointOfSnake = snakeElements
                    .Any(x => x.LeftX == LeftX && x.TopY == TopY);
            }

            Console.BackgroundColor = ConsoleColor.Red;
            Draw(foodSymbol);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public bool IsFoodPoint(Point snakeHead) 
            => snakeHead.LeftX == LeftX && snakeHead.TopY == TopY;
    }
}

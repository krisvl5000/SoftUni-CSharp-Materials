using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using SimpleSnake.GameObjects.Foods;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const char SNAKE_SYMBOL = '\u25CF';
        private readonly Wall wall;
        private readonly Queue<Point> snakeElements;
        private readonly List<Point> foods;

        private int nextLeftX;
        private int nextTopY;
        private int foodIndex;

        public Snake()
        {
            snakeElements = new Queue<Point>();
        }

        private void CreateSnake()
        {
            for (int topY = 1; topY <= 6; topY++)
            {
                snakeElements.Enqueue(new Point(2, topY));
            }
        }

        private void GetFoods()
        {
            foods[0] = new FoodHash(wall);
            foods[1] = new FoodDollar(wall);
            foods[2] = new FoodAsterisk(wall);
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            nextLeftX = snakeHead.LeftX + direction.LeftX;
            nextTopY = snakeHead.TopY + direction.TopY;
        }

        public bool IsMoving(Point direction)
        {
            Point currentSnake = snakeElements.Last();
            GetNextPoint(direction, currentSnake);

            bool isPointOfSnake = snakeElements.Any(x => x.LeftX == nextLeftX && x.TopY == nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }

            Point newSnake = new(nextLeftX, nextTopY);

            if (wall.IsPointOfWall(newSnake))
            {
                return false;
            }

            snakeElements.Enqueue(newSnake);
            newSnake.Draw(SNAKE_SYMBOL);

            var food = foods[foodIndex];

            if (food.IsFoodPoint(newSnake))
            {
                Eat(direction, currentSnake);
            }

            return true;
        }

        public void Eat(Point direction, Point head)
        {
            int length = foods[foodIndex].FoodPoints;

            for (int i = 0; i < length; i++)
            {
                snakeElements.Enqueue(new Point(nextLeftX, nextTopY));
                GetNextPoint(direction, head);  
            }

            foodIndex = RandomFoodNumber();
            foods[foodIndex].SetRandomPosition(snakeElements);
        }

        private int RandomFoodNumber() => new Random().Next(0, foods.Count);
    }
}

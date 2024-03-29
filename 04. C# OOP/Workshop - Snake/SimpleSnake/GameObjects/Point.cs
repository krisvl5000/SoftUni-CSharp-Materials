﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public class Point
    {
        public Point(int leftX, int topY)
        {
            LeftX = leftX;
            TopY = topY;
        }

        public int LeftX { get; set; }

        public int TopY { get; set; }

        public int FoodPoints { get; protected set; }

        public void Draw(char symbol)
        {
            Console.SetCursorPosition(LeftX, TopY);
            Console.Write(symbol);
        }

        public void Draw(int leftX, int topY, char symbol)
        {
            Console.SetCursorPosition(leftX, topY);
            Console.Write(symbol);
        }

        public bool IsFoodPoint(Point snakeHead)
            => snakeHead.LeftX == LeftX && snakeHead.TopY == TopY;

        public int SetRandomPosition(Queue<Point> snake)
        {
            throw new NotImplementedException();
        }
    }
}

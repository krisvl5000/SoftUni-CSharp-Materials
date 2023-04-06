using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char wallSymbol = '\u25A0';

        public Wall(int leftX, int topY) 
            : base(leftX, topY)
        {
            InitializeWallBorders();
        }
        
        private void SetHorizontalLine(int topY)
        {
            for (int leftX = 0; leftX < LeftX; leftX++)
            {
                Draw(leftX, topY, wallSymbol);
            }
        }

        private void SetVerticalLine(int leftX)
        {
            for (int topY = 0; topY < TopY; topY++)
            {
                Draw(leftX, topY, wallSymbol);
            }
        }

        private void InitializeWallBorders()
        {
            SetHorizontalLine(0);
            SetHorizontalLine(TopY - 1); // added - 1 to make it start from the beginning

            SetVerticalLine(0);
            SetVerticalLine(LeftX - 1);
        }

        public bool IsPointOfWall(Point snake)
            => snake.TopY == 0 ||
               snake.LeftX == 0 ||
               snake.LeftX == LeftX - 1 || 
               snake.TopY == TopY;
    }
}

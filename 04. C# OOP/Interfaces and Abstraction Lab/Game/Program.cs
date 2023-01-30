using System;

namespace Game
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IDrawable> drawableObjects = new List<IDrawable>();

            drawableObjects.Add(new Bird());
            drawableObjects.Add(new Column());

            while (true)
            {
                Thread.Sleep(1000);

                foreach (var item in drawableObjects)
                {
                    item.Draw();
                }
            }

        }
    }
}
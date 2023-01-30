using System;

namespace AbstractionAndInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Caretaker caretaker = new Caretaker();

            caretaker.Feed(new Eagle());
            caretaker.Feed(new Crocodile());
            caretaker.Feed(new Fish());

            caretaker.Feed(new Baby());

            IFeedable feedable = new Lion();
        }
    }
}
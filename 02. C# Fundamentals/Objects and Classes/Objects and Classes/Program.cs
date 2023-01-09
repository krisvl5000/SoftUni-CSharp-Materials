//using System;

//namespace _01._Hello_Softuni
//{
//    class Cat
//    {
//        public Cat()
//        {
//            Console.WriteLine("New cat created");
//        }

//        public Cat(string name, int age)
//        {
//            this.Name = "Default catName";
//            this.Age = age;
//        }
//        public Cat(string name, int age, double weight)
//        {
//            this.Name = name;
//            this.Age = age;
//            this.Weight = weight;
//            this.IsAlive = true;
//        }
//        public string Name { get; set; }

//        public int Age { get; set; }

//        public double Weight { get; set; }

//        public bool IsAlive { get; set; }

//        public void SayName()
//        {
//            Console.WriteLine(this.Name);
//        }

//        public bool IsOverweight()
//        {
//            if (this.Weight > 10)
//            {
//                return true;
//            }
//            return false;
//        }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Cat firstCat = new Cat("Maria", 5, 5.4);

//            //  IS THE SAME AS THE ABOVE

//            //Cat firstCat = new Cat();
//            //firstCat.Name = "Maria";
//            //firstCat.Age = 5;
//            //firstCat.Weight = 5.4;
//            //firstCat.IsAlive = true;

//            firstCat.SayName();

//            Console.WriteLine($"Name: {firstCat.Name} Age: {firstCat.Age}");

//            Cat secondCat = new Cat();
//            {
//                secondCat.Name = "Maca";
//                secondCat.Age = 6;
//                secondCat.Weight = 33.3;
//                secondCat.IsAlive = true;
//            }

//            secondCat.SayName();

//            Console.WriteLine($"Name: {secondCat.Name} Age: {secondCat.Age}");

//            Cat thirdCat = new Cat("Galia", 5);
//            {
//                thirdCat.Weight = 3;
//            }

//            thirdCat.SayName();

//            Console.WriteLine($"Name: {thirdCat.Name} Age: {thirdCat.Age}");

//        }
//    }
//}

using System;

namespace _01._Hello_Softuni
{
    class Cat
    {
        public Cat()
        {
            this.Name = "Default catName";
            this.Weight = 5;
            this.Age = 1;
        }

        public Cat(string name, int age, double weight)
        {
            this.Name = name;
            this.Age = age;
            this.Weight = weight;
            this.IsAlive = true;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public double Weight { get; set; }

        public bool IsAlive { get; set; }

        public bool IsOverweight
        {
            get
            {
                if (this.Weight > 10)
                {
                    return true;
                }
                return false;
            }
            
        }

        //public bool IsOverweight()
        //{
        //    if (this.Weight > 10)
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        public void SayName()
        {
            Console.WriteLine(this.Name);
        }

        

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Cat firstCat = new Cat("Maria", 5, 5.4);

            //Cat firstCat = new Cat();
            //firstCat.Name = "Maria";
            //firstCat.Age = 5;
            //firstCat.Weight = 5.4;
            firstCat.SayName();
            bool isOverweight = firstCat.IsOverweight;

            Console.WriteLine($"Name: {firstCat.Name} Age: {firstCat.Age}");

            Cat secondCat = new Cat()
            {
                Name = "Maca",
                Age = 6,
                Weight = 33.3,
            };

            secondCat.SayName();

            Console.WriteLine($"Name: {secondCat.Name} Age: {secondCat.Age}");

            Cat thirdCat = new Cat("Galia", 4, 4.5);

            Console.WriteLine($"Name: {thirdCat.Name} Age: {thirdCat.Age}");



        }
    }
}
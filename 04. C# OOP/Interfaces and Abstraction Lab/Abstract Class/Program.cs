using System;

namespace AbstractClass
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Printer printer = new ThreeDPrinter();
            Printer paperPrinter = new PaperPrinter();
            paperPrinter.Print();
        }
    }
}
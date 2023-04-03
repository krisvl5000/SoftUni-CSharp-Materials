using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Common
{
    public class DateLogger : ILogger
    {
        private readonly DateTime date;

        public DateLogger(int day, int month, int year)
        {
            date = new DateTime(year, month, day);
        }

        public void Log(string message)
        {
            Console.WriteLine($"DATE: {date:dd/MM/yyyy}");
        }
    }
}

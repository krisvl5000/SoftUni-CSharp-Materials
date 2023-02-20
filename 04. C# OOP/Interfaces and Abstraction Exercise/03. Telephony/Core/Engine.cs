using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephony.Models;
using Telephony.Models.Interfaces;

namespace Telephony
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly IStationaryPhone stationaryPhone;
        private readonly ISmartphone smartphone;

        private Engine()
        {
            this.stationaryPhone = new StationaryPhone();
            this.smartphone = new SmartPhone();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] phoneNumbers = reader.ReadLine()
                .Split(' ');
            string[] urls = reader.ReadLine()
                .Split(' ');

            foreach (var item in phoneNumbers)
            {
                try
                {
                    if (item.Length == 10)
                    {
                        writer.WriteLine(smartphone.Call(item));
                    }
                    else if (item.Length == 7)
                    {
                        writer.WriteLine(stationaryPhone.Call(item));
                    }
                    else
                    {
                        throw new InvalidPhoneNumberException();
                    }
                }
                catch (InvalidPhoneNumberException ipne)
                {
                    writer.WriteLine(ipne.Message);
                }
                
            }

            foreach (var item in urls)
            {
                try
                {
                    writer.WriteLine(smartphone.BrowseURL(item));
                }
                catch (InvalidURLException iue)
                {
                    writer.WriteLine(iue.Message);
                }
                
            }
        }
    }
}

using System;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Programmer programmer = new Programmer();
            programmer.Name = "Dimitrichko";
            programmer.CreateBugs();
            programmer.GetPaid();

            TeamLead teamLead = new TeamLead();
            teamLead.FixBugs();
            teamLead.GetPaid();

        }
    }
}
using System;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Junior junior = new Junior("Goshko");

            Programmer programmer = new Programmer("Pesho");
            programmer.Name = "Dimitrichko";
            programmer.CreateBugs();
            programmer.GetPaid();

            TeamLead teamLead = new TeamLead();
            teamLead.FixBugs();
            teamLead.GetPaid();

        }
    }
}
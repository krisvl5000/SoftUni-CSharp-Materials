//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace _01._Hello_Softuni
//{
//    internal class Team
//    {
//        public Team(string teamName, string creatorName)
//        {
//            Name = teamName;
//            Creator = creatorName;

//            Members = new List<string>();
//        }

//        public string Name { get; set; }

//        public string Creator { get; set; }

//        public List<string> Members { get; set; }

//        public void AddMember(string member)
//        {
//            Members.Add(member);
//        }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            List<Team> teams = new List<Team>();
//            int n = int.Parse(Console.ReadLine());

//            RegisterTeams(teams, n);

//            string command;
//            while ((command = Console.ReadLine()) != "end of assignment")
//            {
//                string[] joinArgs = command.Split("->").ToArray();

//                string memberName = joinArgs[0];
//                string teamName = joinArgs[1];

//                Team searchedTeam = teams.FirstOrDefault(t => t.Name == teamName);

//                if (searchedTeam == null)
//                {
//                    Console.WriteLine($"Team {teamName} does not exist!");
//                    continue;
//                }

//                //if (teams.Any(t => t.Members.Contains(memberName)))
//                //{
//                //    Console.WriteLine($"Member {memberName} cannot join team {teamName}");
//                //    continue;
//                //}

//                if (IsAlreadyMemberOfTeam(teams, memberName))
//                {
//                    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
//                    continue;
//                }

//                if (teams.Any(t => t.Creator == memberName))
//                {
//                    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
//                    continue;
//                }

//                searchedTeam.AddMember(memberName);

//            }

//            List<Team> teamsWithMembers = teams
//                .Where(t => t.Members.Count > 0)
//                .OrderByDescending(t => t.Members.Count)
//                .ThenBy(t => t.Name)
//                .ToList();

//            List<Team> teamsToDisband = teams
//                .Where(t => t.Members.Count == 0)
//                .OrderBy(t => t.Name)
//                .ToList();

//            PrintValidTeams(teamsWithMembers);

//            PrintInvalidTeams(teamsToDisband);
//        }

//        static void PrintValidTeams(List<Team> validTeams)
//        {
//            foreach (Team validTeam in validTeams)
//            {
//                Console.WriteLine($"{validTeam.Name}");
//                Console.WriteLine($"- {validTeam.Creator}");

//                foreach (string currentMember in validTeam.Members.OrderBy(m => m))
//                {
//                    Console.WriteLine($"-- {currentMember}");
//                }
//            }

//        }

//        static void PrintInvalidTeams(List<Team> invalidTeams)
//        {
//            Console.WriteLine("Teams to disband:");

//            foreach (Team invalidTeam in invalidTeams)
//            {
//                Console.WriteLine($"{invalidTeam.Name}");
//            }
//        }

//        static bool IsAlreadyMemberOfTeam(List<Team> teams, string memberName)
//        {
//            foreach (Team team in teams)
//            {
//                if (team.Members.Contains(memberName))
//                {
//                    return true;
//                }
//            }

//            return false;
//        }

//        static void RegisterTeams(List<Team> teams, int n)
//        {
//            for (int i = 0; i < n; i++)
//            {
//                string[] teamArgs = Console.ReadLine().Split("-").ToArray();

//                string creatorName = teamArgs[0];
//                string teamName = teamArgs[1];

//                if (teams.Any(t => t.Name == teamName))
//                {
//                    //There is a duplicate of the team
//                    Console.WriteLine($"Team {teamName} was already created!");
//                    continue;
//                }

//                if (teams.Any(t => t.Creator == creatorName))
//                {
//                    Console.WriteLine($"{creatorName} cannot create another team!");
//                    continue;
//                }

//                Team newTeam = new Team(teamName, creatorName);
//                teams.Add(newTeam);
//                Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
//            }
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Hello_Softuni
{
    class Team
    {
        public Team(string name, string creator)
        {
            Name = name;
            Creator = creator;

            Members = new List<string>();
        }

        public string Name { get; set; }

        public string Creator { get; set; }

        public List<string> Members { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Team> list = new List<Team>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split("-").ToArray();
                string creatorName = input[0];
                string teamName = input[1];

                if (list.Any(t => t.Name == teamName))
                {
                    //team has the same name
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                if (list.Any(t => t.Creator == creatorName))
                {
                    //team has the same creator
                    Console.WriteLine($"{creatorName} cannot create another team!");
                    continue;
                }

                Team newTeam = new Team(creatorName, teamName);
                list.Add(newTeam);
                Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
            }

            string command;
            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] joinArgs = command.Split("->").ToArray();

                string memberName = joinArgs[0];
                string teamName = joinArgs[1];

                Team currentTeam = list.FirstOrDefault(t => t.Name == teamName);

                if (currentTeam == null)
                {
                    //there is not such team
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }
                
                if (list.Any(t => t.Name == memberName))
                {
                    //already a member of another team
                    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                    continue;
                }

                currentTeam.Members.Add(memberName);
                
            }

            List<Team> validTeams = list
                .Where(t => t.Members.Count > 0)
                .OrderByDescending(t => t.Members)
                .OrderBy(t => t.Name)
                .ToList();

            foreach (Team team in validTeams)
            {
                Console.WriteLine($"{team.Name}");
                Console.WriteLine($"- {team.Creator}");

                foreach (string member in team.Members.OrderBy(m => m))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            List<Team> invalidTeams = list
                .Where(t => t.Members.Count == 0)
                .OrderBy(t => t.Name)
                .ToList();

            Console.WriteLine("Teams to disband:");

            foreach (Team team in invalidTeams)
            {
                Console.WriteLine($"{team.Name}");
            }

        }
    }
}
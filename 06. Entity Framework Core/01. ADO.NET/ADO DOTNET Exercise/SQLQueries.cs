using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_DOTNET_Exercise
{
    internal static class SQLQueries
    {   
        public const string VILLAIN_NAME_WITH_THREE_OR_MORE_MINIONS_QUERY =
            @" SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                FROM Villains AS v 
                JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
            GROUP BY v.Id, v.Name 
              HAVING COUNT(mv.VillainId) > 3 
            ORDER BY COUNT(mv.VillainId)
            ";

        public const string SELECT_NAME_FROM_VILLAINS_QUERY = @"SELECT Name FROM Villains WHERE Id = @Id";

        public const string VILLAINS_AND_THEIR_MINIONS_QUERY = @"
                                    SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";
    }
}

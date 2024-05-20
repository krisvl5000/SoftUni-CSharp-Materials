using System.Text;
using Microsoft.Data.SqlClient;

namespace ADO_DOTNET_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(Config.CONNECTION_STRING);

            sqlConnection.Open();

            Console.WriteLine(VillainNames(sqlConnection));
        }

        static string VillainNames(SqlConnection sqlConnection)
        {
            StringBuilder sb = new StringBuilder();

            SqlCommand cmd = new SqlCommand(SQLQueries.VILLAIN_NAME_WITH_THREE_OR_MORE_MINIONS_QUERY, sqlConnection);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            { 
                string villainName = (string)reader["Name"];
                int minionsCount = (int)reader["MinionsCount"];

                sb.AppendLine($"{villainName} - {minionsCount}");
            }

            return sb.ToString().TrimEnd();
        }

        static async Task<string> GetAllMinionsNamesAndAgeForCurrentVillainIdAsync(SqlConnection connection)
        {
            int villainId = int.Parse(Console.ReadLine());

            SqlCommand getVillainNameCmd =
                new SqlCommand(SQLQueries.SELECT_NAME_FROM_VILLAINS_QUERY, connection);

            getVillainNameCmd.Parameters.AddWithValue("@Id", villainId);

            object? villainNameObj = await getVillainNameCmd.ExecuteScalarAsync();
            if (villainNameObj == null)
            {
                return $"No villain with ID {villainId} exists in the database.";
            }

            string villainName = (string)villainNameObj;

            SqlCommand getAllMinionsCmd =
                new SqlCommand(SQLQueries.VILLAINS_AND_THEIR_MINIONS_QUERY, connection);

            getAllMinionsCmd.Parameters.AddWithValue("@Id", villainId);

            SqlDataReader minionsReader = await getAllMinionsCmd.ExecuteReaderAsync();

            string output =
                GenerateVillainWithMinionsOutput(villainName, minionsReader);
            return output;
        }

        private static string GenerateVillainWithMinionsOutput(string villainName, SqlDataReader minionsReader)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Villain: {villainName}");
            if (!minionsReader.HasRows)
            {
                sb.AppendLine("(no minions)");
            }
            else
            {
                while (minionsReader.Read())
                {
                    long rowNum = (long)minionsReader["RowNum"];
                    string minionName = (string)minionsReader["Name"];
                    int minionAge = (int)minionsReader["Age"];

                    sb.AppendLine($"{rowNum}. {minionName} {minionAge}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
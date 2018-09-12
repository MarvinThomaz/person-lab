using Dapper;
using Person.Common.Builders;
using System.Data;

namespace Person.IntegrationTests.Seed
{
    public static class PersonRepositorySeed
    {
        public static string Query = $@"

            INSERT INTO Person.Persons

            (Persons.Key, Persons.Name, Persons.Age)

            VALUES

            ('{KeyBuilder.Build()}', 'Marvin', 27),
            ('{KeyBuilder.Build()}', 'Thomaz', 26),
            ('{KeyBuilder.Build()}', 'Nascimento', 25)

        ";

        public static void ExecuteSeed(IDbConnection connection, IDbTransaction transaction)
        {
            connection.Query(Query, transaction: transaction);
        }
    }
}
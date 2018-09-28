using Dapper;
using FizzWare.NBuilder;
using Person.Common.Builders;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Person.IntegrationTests.Seed
{
    public static class PersonRepositorySeed
    {
        public static List<Domain.Entities.Person> Persons = Builder<Domain.Entities.Person>
            .CreateListOfSize(10)
            .Build()
            .ToList();

        public static void ExecuteSeed(IDbConnection connection)
        {
            connection.Query(CreateQuery());
        }

        public static void FinishSeed(IDbConnection connection)
        {
            var persons = string.Join(',', Persons.Select(p => $"'{p.Key}'"));

            connection.Query($"DELETE FROM Person.Persons WHERE Persons.Key IN ({persons})");
        }

        private static string CreateQuery()
        {
            Persons.ForEach(p => p.Key = KeyBuilder.Build());

            var values = Persons
                .Select(p => $"('{KeyBuilder.Build()}', '{p.Name}', {p.Age})");

            var query = $@"

            INSERT INTO Person.Persons

            (Persons.Key, Persons.Name, Persons.Age)

            VALUES
            
            {string.Join(',', values)}
            ";

            return query;
        }
    }
}
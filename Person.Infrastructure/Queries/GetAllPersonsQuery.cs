namespace Person.Infrastructure.Queries
{
    public static class GetAllPersonsQuery
    {
        public const string Query = @"

            SELECT
                Persons.Key,
                Persons.Age,
                Persons.Name
            FROM 
                Person.Persons

        ";
    }
}
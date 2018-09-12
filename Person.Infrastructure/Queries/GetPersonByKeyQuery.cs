namespace Person.Infrastructure.Queries
{
    public static class GetPersonByKeyQuery
    {
        public const string Query = @"

            SELECT
                Persons.Key,
                Persons.Name,
                Persons.Age
            FROM
                Person.Persons

            WHERE Persons.Key = @Key                

        ";
    }
}
namespace Person.Infrastructure.Queries
{
    public static class CreatePersonQuery
    {
        public const string Query = @"

            INSERT INTO Person.Persons

            (persons.Key, persons.Name, persons.Age)

            VALUES

            (@Key, @Name, @Age)

        ";
    }
}
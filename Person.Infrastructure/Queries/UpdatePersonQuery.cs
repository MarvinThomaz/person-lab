namespace Person.Infrastructure.Queries
{
    public static class UpdatePersonQuery
    {
        public const string Query = @"

            UPDATE Person.Persons

            SET Persons.Name = @Name, Persons.Age = @Age

            WHERE Persons.Key = @Key

        ";
    }
}
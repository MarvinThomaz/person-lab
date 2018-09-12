namespace Person.Infrastructure.Queries
{
    public static class DeletePersonQuery
    {
        public const string Query = @"

            DELETE FROM Person.Persons

            WHERE Persons.Key = @Key

        ";
    }
}

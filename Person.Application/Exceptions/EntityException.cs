using System;

namespace Person.Application.Exceptions
{
    public class EntityException : Exception
    {
        public EntityException(string property, string message) : base(message)
        {
            Property = property;
        }

        public string Property { get; }
    }
}
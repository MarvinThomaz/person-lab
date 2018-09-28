using Microsoft.EntityFrameworkCore;

namespace Person.UnitTests.Fakes
{
    public class FakeDbSet : DbSet<Domain.Entities.Person>
    {
    }
}

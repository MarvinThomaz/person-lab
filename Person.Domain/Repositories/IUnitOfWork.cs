using System.Threading.Tasks;

namespace Person.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IPersonRepository PersonRepository { get; }

        Task SaveChangesAsync();
    }
}
using Microsoft.EntityFrameworkCore;
using Person.Domain.Repositories;
using Person.Infrastructure.Context;
using System.Threading.Tasks;

namespace Person.Infrastructure.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public EFUnitOfWork(IPersonRepository personRepository, PersonDbContext context)
        {
            PersonRepository = personRepository;

            _context = context;
        }

        public IPersonRepository PersonRepository { get; }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

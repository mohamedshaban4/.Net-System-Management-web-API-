using Microsoft.EntityFrameworkCore;
using SystemManagement.Core.IRepository;
using SystemManagement.Infrastructure.Data;

namespace SystemManagement.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
            => await _context.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(int id)
            => await _context.Set<T>().FindAsync(id);


        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);

            _context.SaveChanges();
        }

        public void Delete(T id)
        {
            _context.Set<T>().Remove(id);
            _context.SaveChanges();

        }



        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}

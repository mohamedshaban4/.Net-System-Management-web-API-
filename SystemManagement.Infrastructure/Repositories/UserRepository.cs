using Microsoft.EntityFrameworkCore;
using SystemManagement.Core.Entities;
using SystemManagement.Core.IRepository;
using SystemManagement.Infrastructure.Data;

namespace SystemManagement.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.UserName == username);
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }


        public async Task<User> GetByUserEmailAsync(string email)
           => await _context.Users.FirstOrDefaultAsync(e => e.Email == email);


        public async Task<User> GetByUserNameAsync(string userName)
            => await _context.Users.FirstOrDefaultAsync(user => user.UserName == userName);

        public async Task<User> GetUserByNameAsync(string userName)
        => await _context.Users.SingleOrDefaultAsync(u => u.UserName == userName);
    }
}

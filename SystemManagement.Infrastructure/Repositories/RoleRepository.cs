using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagement.Core.Entities;
using SystemManagement.Core.IRepository;
using SystemManagement.Infrastructure.Data;

namespace SystemManagement.Infrastructure.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Role> FindByNameAsync(string name)
            => await _context.Roles.FirstOrDefaultAsync(n => n.Name == name);



        public async Task<IEnumerable<User>> GetUsersInRoleAsync(int roleId)
        => await _context.Users.Where(u => u.RoleId == roleId).ToListAsync();
            
        
    }
}

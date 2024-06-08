using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SystemManagement.Core.Entities;
using SystemManagement.Core.IRepository;
using SystemManagement.Infrastructure.Data;

namespace SystemManagement.Infrastructure.Repositories
{
    public class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
    {
        private readonly AppDbContext _context;

        public PermissionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Permission>> GetByRoleAsync(int roleId)
        {
            return await _context.Permissions
                                 .Where(p => p.RoleId == roleId)
                                 .ToListAsync();
        }

        public async Task<bool> CheckPermissionsAsync(int userId, string permissionName)
        {
            return await _context.Users
                .AnyAsync(p => p.Id == userId) &&
                await _context.Permissions
                .AnyAsync(p => p.Name == permissionName);
        }

        public async Task GrantPermissionAsync(int userId, string permissionName)
        {
            var permission = new Permission { Id = userId, Name = permissionName };
            await _context.Permissions.AddAsync(permission);
            _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Permission>> GetByUserIdAsync(int userId)
        {
            return await _context.Users.Where(u => u.Id == userId)
                .SelectMany(p => p.Permissions).ToListAsync();

        }
    }
}

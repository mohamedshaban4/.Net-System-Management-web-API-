using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagement.Core.Entities;

namespace SystemManagement.Core.IRepository
{
    public interface IPermissionRepository : IGenericRepository<Permission>
    {
        Task<IEnumerable<Permission>> GetByRoleAsync(int roleId);
        Task<IEnumerable<Permission>> GetByUserIdAsync(int userId);

        Task<bool> CheckPermissionsAsync(int userId, string permissionName);
        Task GrantPermissionAsync (int userId, string permissionName);
    }
}

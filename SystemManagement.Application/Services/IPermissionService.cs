using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagement.Application.DTOs;

namespace SystemManagement.Application.Services
{
    public interface IPermissionService
    {
        Task<PermissionDto> GetPermissionByIdAsync(int id);
        Task<IEnumerable<PermissionDto>> GetPermissionsByUserIdAsync(int userId);

        Task<IEnumerable<PermissionDto>> GetAllPermissionsAsync();
        Task<PermissionDto> AddPermissionAsync(CreatePermissionDto createPermissionDto);
        Task UpdatePermissionAsync(int id, CreatePermissionDto updatePermissionDto);
        Task DeletePermissionAsync(int id);
        Task<IEnumerable<PermissionDto>> GetPermissionsByRoleAsync(int roleId);
        Task<bool> CheckPermissionAsync(int userId, string permissionName);
        Task GrantPermissionAsync(int userId, int roleId, string permissionName);
    }
}

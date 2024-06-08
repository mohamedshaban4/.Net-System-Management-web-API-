using SystemManagement.Application.DTOs;

namespace SystemManagement.Application.Services
{
    public interface IRoleService
    {
        Task<RoleDto> GetRoleByIdAsync(int id);
        Task<IEnumerable<RoleDto>> GetAllRolesAsync();
        Task AddRoleAsync(CreateRoleDto createRoleDto);
        Task UpdateRoleAsync(int id, UpdateRoleDto updateRoleDto);
        Task DeleteRoleAsync(int id);
    }
}

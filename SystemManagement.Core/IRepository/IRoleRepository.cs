using SystemManagement.Core.Entities;

namespace SystemManagement.Core.IRepository
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task<Role> FindByNameAsync(string name);
        Task<IEnumerable<User>> GetUsersInRoleAsync(int roleId);
    }
}

using SystemManagement.Core.Entities;

namespace SystemManagement.Core.IRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByUserNameAsync(string userName);
        Task<User> GetByUserEmailAsync(string email);
        Task<User> GetByUsernameAsync(string username);
        Task<User> GetUserByNameAsync(string userName);

        //Task<User> AuthenticateAsync(string username, string password);

    }
}

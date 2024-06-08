using SystemManagement.Core.IRepository;

namespace SystemManagement.Core.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ISettingRepository Settings { get; }
        ILogRepository Logs { get; }
        IPermissionRepository Permissions { get; }
        IRoleRepository Roles { get; }
        Task<int> CommitAsync();
    }
}

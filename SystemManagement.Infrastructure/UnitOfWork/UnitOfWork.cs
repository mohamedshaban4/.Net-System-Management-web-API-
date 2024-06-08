using SystemManagement.Core.IRepository;
using SystemManagement.Core.IUnitOfWork;
using SystemManagement.Infrastructure.Data;
using SystemManagement.Infrastructure.Repositories;

namespace SystemManagement.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        

        public IUserRepository Users { get; private set; }
        public ILogRepository Logs { get; private set; }
        public ISettingRepository Settings { get; private set; }

        public IPermissionRepository Permissions { get; private set; }
        public IRoleRepository Roles { get; private set; }  

        public UnitOfWork(
            AppDbContext context, IUserRepository userRepository,
            IPermissionRepository permissionRepository, IRoleRepository roleRepository
            , ILogRepository logs, ISettingRepository settingRepository)
        {
            _context = context;
            Users = userRepository;
            Permissions = permissionRepository;
            Roles = roleRepository;
            Logs = logs;
            Settings = settingRepository;
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

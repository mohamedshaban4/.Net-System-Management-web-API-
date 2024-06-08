using SystemManagement.Core.Entities;
using SystemManagement.Core.IRepository;
using SystemManagement.Infrastructure.Data;

namespace SystemManagement.Infrastructure.Repositories
{
    public class SettingRepository : GenericRepository<Setting>, ISettingRepository
    {
        private readonly AppDbContext _context;

        public SettingRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

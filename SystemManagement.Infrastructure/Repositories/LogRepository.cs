using Microsoft.EntityFrameworkCore;
using SystemManagement.Core.Entities;
using SystemManagement.Core.IRepository;
using SystemManagement.Infrastructure.Data;

namespace SystemManagement.Infrastructure.Repositories
{
    public class LogRepository : GenericRepository<Log>, ILogRepository
    {
        private readonly AppDbContext _context;

        public LogRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Log>> GetAllLogsAsync()      
           => await _context.Logs.ToListAsync();
        
            
        

        public async Task<Log> GetLogByIdAsync(int id)
          => await _context.Logs.FindAsync(id);


        public async Task<IEnumerable<Log>> GetLogsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Logs
                .Where(log => log.Timestamp >= startDate && log.Timestamp <= endDate)
                .ToListAsync();
        }



        public async Task<IEnumerable<Log>> GetLogsByUserIdAsync(int userId)
        => await _context.Logs.Where(log => log.UserId == userId).ToListAsync();
       
    }
}

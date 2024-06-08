using SystemManagement.Core.Entities;

namespace SystemManagement.Core.IRepository
{
    public interface ILogRepository : IGenericRepository<Log>
    {
        Task<IEnumerable<Log>> GetAllLogsAsync();
        Task<Log> GetLogByIdAsync(int id);
        Task<IEnumerable<Log>> GetLogsByUserIdAsync(int userId);
        Task<IEnumerable<Log>> GetLogsByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}

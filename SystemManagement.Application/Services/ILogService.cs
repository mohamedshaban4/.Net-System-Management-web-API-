using SystemManagement.Application.DTOs;
using SystemManagement.Core.Entities;

namespace SystemManagement.Application.Services
{
    public interface ILogService
    {
        Task<IEnumerable<LogDto>> GetAllLogsAsync();
        Task<LogDto> CreateLogAsync(CreateLogDto createLogDto);
        Task<LogDto> GetLogByIdAsync(int id);
        Task<IEnumerable<LogDto>> GetLogsByUserIdAsync(int userId);
        Task<IEnumerable<LogDto>> GetLogsByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}

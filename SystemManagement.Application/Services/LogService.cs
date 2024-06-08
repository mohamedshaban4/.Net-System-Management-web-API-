using AutoMapper;
using SystemManagement.Application.DTOs;
using SystemManagement.Core.Entities;
using SystemManagement.Core.IUnitOfWork;

namespace SystemManagement.Application.Services
{
    public class LogService : ILogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LogService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<LogDto>> GetAllLogsAsync()
        {
           var logs = await _unitOfWork.Logs.GetAllAsync();
            return _mapper.Map<IEnumerable<LogDto>>(logs);

        }

        public async Task<LogDto> GetLogByIdAsync(int id)
        {
            var log = await _unitOfWork.Logs.GetLogByIdAsync(id);
            if (log == null)
            {
                throw new KeyNotFoundException("Log not found");
            }

            return _mapper.Map<LogDto>(log);
        }


        public async Task<LogDto> CreateLogAsync(CreateLogDto createLogDto)
        {
            var log = _mapper.Map<Log>(createLogDto);
            await _unitOfWork.Logs.AddAsync(log);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<LogDto>(log);
        }

        public async Task<IEnumerable<LogDto>> GetLogsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
           var logsDate =  await _unitOfWork.Logs.GetLogsByDateRangeAsync(startDate, endDate);
            return _mapper.Map<IEnumerable<LogDto>>(logsDate);

        }

        public async Task<IEnumerable<LogDto>> GetLogsByUserIdAsync(int userId)
        {
            var logs = await _unitOfWork.Logs.GetLogsByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<LogDto>>(logs);

        }
    }
}

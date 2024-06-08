using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemManagement.Application.DTOs;
using SystemManagement.Application.Services;
using SystemManagement.Core.IUnitOfWork;

namespace SystemManagmentWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LogController : ControllerBase
    {
        
        private readonly ILogService _logService;
        private readonly ILogger<LogController> _logger;

        public LogController(ILogService logService, ILogger<LogController> logger)
        {
            
            _logService = logService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogDto>>> GetAllLogs()
        {
            try
            {
                var logs = await _logService.GetAllLogsAsync();
                return Ok(logs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<LogDto>> CreateLog(CreateLogDto createLogDto)
        {
            createLogDto.IpAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            var log = await _logService.CreateLogAsync(createLogDto);
            return CreatedAtAction(nameof(GetLogById), new { id = log.Id }, log);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<LogDto>> GetLogById(int id)
        {
            try
            {
                var log = await _logService.GetLogByIdAsync(id);
                if (log == null)
                {
                    return NotFound();
                }
                return Ok(log);
            }
            
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("daterange")]
        public async Task<ActionResult<IEnumerable<LogDto>>> GetLogsByDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                var logs = await _logService.GetLogsByDateRangeAsync(startDate, endDate);
                return Ok(logs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<LogDto>>> GetLogsByUserId(int userId)
        {
            try
            {
                var logs = await _logService.GetLogsByUserIdAsync(userId);
                return Ok(logs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

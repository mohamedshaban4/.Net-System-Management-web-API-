using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SystemManagement.Application.DTOs;
using SystemManagement.Application.Services;

namespace SystemManagmentWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly ILogger<RoleController> _logger;

        public RoleController(IRoleService roleService, ILogger<RoleController> logger)
        {
            _roleService = roleService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task <ActionResult> GetById(int id)
        {
            try
            {
                var role = await _roleService.GetRoleByIdAsync(id);
                if (role == null)
                {
                    return NotFound();
                }

                return Ok(role);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving role.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var roles = await _roleService.GetAllRolesAsync();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving roles.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<RoleDto>> AddRole(CreateRoleDto createRoleDto)
        {
            try
            {
                await _roleService.AddRoleAsync(createRoleDto);
                return Ok("Role added successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to add role.");
                return BadRequest($"Failed to add role: {ex.Message}");
            }
        }
        [HttpDelete]
        public async Task<ActionResult<RoleDto>> DeleteRole (int id)
        {

            try
            {
                await _roleService.DeleteRoleAsync(id);
                return Ok($"Role with Id '{id}' has been deleted.");
            }
            
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete role.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}

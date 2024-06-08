using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security;
using SystemManagement.Application.DTOs;
using SystemManagement.Application.Services;

namespace SystemManagmentWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionService _permissionService;
        private readonly ILogger<PermissionsController> _logger;

        public PermissionsController(IPermissionService permissionService, ILogger<PermissionsController> logger)
        {
            _permissionService = permissionService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PermissionDto>> GetPermissionById(int id)
        {
            try
            {
                var permission = await _permissionService.GetPermissionByIdAsync(id);
                if (permission == null)
                    return NotFound();

                return Ok(permission);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving permission by ID: {id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the permission.");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetAllPermission()
        {
            try
            {
                var permissions = await _permissionService.GetAllPermissionsAsync();
                return Ok(permissions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all permissions");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the permissions.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<PermissionDto>> AddPermission(CreatePermissionDto createPermissionDto)
        {
            try
            {
                var permission = await _permissionService.AddPermissionAsync(createPermissionDto);
                return CreatedAtAction(nameof(GetPermissionById), new { id = permission.Id }, permission);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating a new permission");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the permission.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePermission(int id, CreatePermissionDto updatePermission)
        {
            try
            {
                await _permissionService.UpdatePermissionAsync(id, updatePermission);
                return Ok("Permission has been Updated Successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating permission with ID: {id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the permission.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePermission(int id)
        {
            try
            {
                await _permissionService.DeletePermissionAsync(id);
                return Ok("Permission has been Deleted Successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting permission with ID: {id}", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the permission.");
            }
        }

        [HttpGet("role/{roleId}")]
        public async Task<ActionResult> GetPermissionsByRole(int roleId)
        {
            try
            {
                var permissions = await _permissionService.GetPermissionsByRoleAsync(roleId);
                return Ok(permissions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving permissions by role ID: {roleId}", roleId);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the permissions by role.");
            }
        }

        [HttpGet("check")]
        [AllowAnonymous]
        public async Task<IActionResult> CheckPermission(int userId, string permissionName)
        {
            try
            {
                var hasPermission = await _permissionService.CheckPermissionAsync(userId, permissionName);
                return Ok(hasPermission);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking permission for user ID: {userId}, permission: {permissionName}", userId, permissionName);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while checking the permission.");
            }
        }

        [HttpPost("grant")]
        public async Task<IActionResult> GrantPermission(int userId, int roleId, string permissionName)
        {
            try
            {
                await _permissionService.GrantPermissionAsync(userId, roleId, permissionName);
                return Ok("Permission has been granted successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error granting permission for user ID: {userId}, role ID: {roleId}, permission: {permissionName}", userId, roleId, permissionName);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while granting the permission.");
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult> GetPermissionsByUserId(int userId)
        {
            try
            {
                var permissions = await _permissionService.GetPermissionsByUserIdAsync(userId);
                return Ok(permissions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving permissions by user ID: {userId}", userId);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the permissions by user.");
            }
        }
    }
}
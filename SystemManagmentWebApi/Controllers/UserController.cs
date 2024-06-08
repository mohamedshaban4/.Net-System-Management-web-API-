using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SystemManagement.Application.Dtos;
using SystemManagement.Application.DTOs;
using SystemManagement.Application.Services;
using SystemManagement.Core.Entities;
using SystemManagement.Infrastructure.Data;

namespace SystemManagmentWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        private readonly JwtOptions _jwtOptions;

        public UserController(IUserService userService, ILogger<UserController> logger, JwtOptions jwtOptions)
        {
            _userService = userService;
            
            _logger = logger;
            _jwtOptions = jwtOptions;
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById (int id)
        {
            var user = await _userService.GetUserByIdAsync (id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();

                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving users.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }


        
        [HttpPost]
        public async Task<ActionResult<UserDto>> AddUser (CreateUserDto createUserDto)
        {
            try
            {
               var createdUserDto =  await _userService.AddUserAsync (createUserDto);

                return CreatedAtAction(nameof(GetUserById),new {id = createdUserDto.Id} ,createdUserDto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to add user: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task< ActionResult<UserDto>> DeleteUser (int id)
        {
            try
            {
                var user = await _userService.DeleteUserAsync (id);
                return Ok($"The user With Id '{id}' and Name '{user.Name}' has been Deleted!!");
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }


        }

        [HttpPut]
        public async Task<ActionResult<UserDto>> UpdateUser(int id, UpdateUserDto updateUserDto)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if(user is null)
                    return NotFound();

                await _userService.UpdateUserAsync(id, updateUserDto);
                return Ok($"The user With Id '{id}' and Name '{user.Name}' has been Updated!!");
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }


        }
    }
}

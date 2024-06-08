using SystemManagement.Application.Dtos;
using SystemManagement.Application.DTOs;
using SystemManagement.Core.Entities;
namespace SystemManagement.Application.Services;

public interface IUserService
{
    Task<UserDto> GetUserByIdAsync(int id);
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task<UserDto> AddUserAsync(CreateUserDto createUserDto);
    Task<UserDto> UpdateUserAsync(int id, UpdateUserDto updateUserDto);
    Task<UserDto> DeleteUserAsync(int id);
    Task<User> GetUserByNameAsync(string userName);

}

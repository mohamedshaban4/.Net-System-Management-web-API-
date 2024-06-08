using AutoMapper;
using SystemManagement.Application.Dtos;
using SystemManagement.Application.DTOs;
using SystemManagement.Core.Entities;
using SystemManagement.Core.IRepository;
using SystemManagement.Core.IUnitOfWork;

namespace SystemManagement.Application.Services
{
    public class UserService : IUserService
    {       
       private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserService( IMapper mapper, IUnitOfWork unitOfWork)
        {
           
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }
        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _unitOfWork.Users.GetAllAsync();

            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        

        public async Task<UserDto> AddUserAsync(CreateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);
            await _unitOfWork.Users.AddAsync(user);
           await _unitOfWork.CommitAsync();
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> DeleteUserAsync(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null)
                throw new KeyNotFoundException("User not found");

            _unitOfWork.Users.Delete(user);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<UserDto>(user);

        }



        public async Task<UserDto> UpdateUserAsync(int id, UpdateUserDto updateUserDto)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null)
                throw new KeyNotFoundException("User not found");

            _mapper.Map(updateUserDto, user);
            _unitOfWork.Users.Update(user);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<UserDto>(user);
        }

        public async Task<User> GetUserByNameAsync(string userName)
        {
            return await _unitOfWork.Users.GetUserByNameAsync(userName);
        }
    }
}

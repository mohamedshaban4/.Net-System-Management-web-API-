using AutoMapper;
using SystemManagement.Application.DTOs;
using SystemManagement.Core.Entities;
using SystemManagement.Core.IUnitOfWork;

namespace SystemManagement.Application.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PermissionService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<PermissionDto> AddPermissionAsync(CreatePermissionDto createPermissionDto)
        {
            var permission = _mapper.Map<Permission>(createPermissionDto);

            // Ensure UserId and RoleId are valid before saving
            if (permission.UserId <= 0 || permission.RoleId <= 0)
            {
                throw new ArgumentException("Invalid UserId or RoleId");
            }

            await _unitOfWork.Permissions.AddAsync(permission);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<PermissionDto>(permission);
        }

        public async Task<bool> CheckPermissionAsync(int userId, string permissionName)
             => await _unitOfWork.Permissions.CheckPermissionsAsync(userId, permissionName);
        

        public async Task DeletePermissionAsync(int id)
        {
            var permission = await _unitOfWork.Permissions.GetByIdAsync(id);
            if(permission == null)
                throw new KeyNotFoundException("Permission not found");

            _unitOfWork.Permissions.Delete(permission);
            await _unitOfWork.CommitAsync();



        }

        public async Task<IEnumerable<PermissionDto>> GetAllPermissionsAsync()
        {
            var permoissions = await _unitOfWork.Permissions.GetAllAsync();
            return _mapper.Map<IEnumerable<PermissionDto>>(permoissions);
        }

        public async Task<PermissionDto> GetPermissionByIdAsync(int id)
        {
            var permoission = await _unitOfWork.Permissions.GetByIdAsync(id);
            return _mapper.Map<PermissionDto>(permoission);
        }

        public async Task<IEnumerable<PermissionDto>> GetPermissionsByRoleAsync(int roleId)
        {
            var permissions = await _unitOfWork.Permissions.GetByRoleAsync(roleId);
            return _mapper.Map<IEnumerable<PermissionDto>>(permissions);
        }

        public async Task<IEnumerable<PermissionDto>> GetPermissionsByUserIdAsync(int userId)
        {
            var permissions = await _unitOfWork.Permissions.GetByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<PermissionDto>>(permissions);
        }

        public async Task GrantPermissionAsync(int userId, int roleId, string permissionName)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(userId);
            if (user == null)
                throw new Exception("User not found");

            var role = await _unitOfWork.Roles.GetByIdAsync(roleId);
            if (role == null)
                throw new Exception("Role not found");

            var permission = new Permission
            {
                UserId = userId,
                RoleId = roleId,
                Name = permissionName,
                Description = "Granted permission"
            };

            await _unitOfWork.Permissions.AddAsync(permission);
            await _unitOfWork.CommitAsync();
        }


        public async Task UpdatePermissionAsync(int id, CreatePermissionDto updatePermissionDto)
        {
            var permission = await _unitOfWork.Permissions.GetByIdAsync(id);
            if(permission != null)
            {
                _mapper.Map(updatePermissionDto, permission);
                _unitOfWork.Permissions.Update(permission);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}

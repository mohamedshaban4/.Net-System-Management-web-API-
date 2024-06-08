using AutoMapper;
using SystemManagement.Application.DTOs;
using SystemManagement.Core.Entities;
using SystemManagement.Core.IUnitOfWork;

namespace SystemManagement.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task AddRoleAsync(CreateRoleDto createRoleDto)
        {
            var role =  _mapper.Map<Role>(createRoleDto);
            await _unitOfWork.Roles.AddAsync(role);
            await _unitOfWork.CommitAsync();  

             
        }

        public async Task DeleteRoleAsync(int id)
        {
            var role = await _unitOfWork.Roles.GetByIdAsync(id);
            if (role == null)
            {
                throw new KeyNotFoundException("Role not found");
            }
             _unitOfWork.Roles.Delete(role);

            await _unitOfWork.CommitAsync();
        }

        
        public async Task<IEnumerable<RoleDto>> GetAllRolesAsync()
        {
            var roles = await _unitOfWork.Roles.GetAllAsync();

           return  _mapper.Map<IEnumerable<RoleDto>>(roles);
        }

        public async Task<RoleDto> GetRoleByIdAsync(int id)
        {
            var role = await _unitOfWork.Roles.GetByIdAsync(id);
            if (role == null)
            {
                throw new KeyNotFoundException("Role not found");
            }

            await _unitOfWork.CommitAsync();

            return _mapper.Map<RoleDto>(role);
        }

        public async Task UpdateRoleAsync(int id, UpdateRoleDto updateRoleDto)
        {
            var role = await _unitOfWork.Roles.GetByIdAsync(id);
            if (role == null)
            {
                throw new KeyNotFoundException("Role not found");
            }

            _mapper.Map(updateRoleDto, role);
            _unitOfWork.Roles.Update(role);

            await _unitOfWork.CommitAsync();
        }
    }
}

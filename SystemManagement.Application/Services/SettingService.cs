using AutoMapper;
using Castle.Core.Configuration;
using SystemManagement.Application.DTOs;
using SystemManagement.Core.Entities;
using SystemManagement.Core.IUnitOfWork;

namespace SystemManagement.Application.Services
{
    public class SettingService : ISettingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SettingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<SettingDto> GetSettingByIdAsync(int id)
        {
            var setting = await _unitOfWork.Settings.GetByIdAsync(id);
            return _mapper.Map<SettingDto>(setting);
        }

        public async Task<IEnumerable<SettingDto>> GetAllSettingsAsync()
        {
            var settings = await _unitOfWork.Settings.GetAllAsync();
            return _mapper.Map<IEnumerable<SettingDto>>(settings);
        }

        public async Task<SettingDto> AddSettingAsync(CreateSettingDto createSettingDto)
        {
            var settingEntity = _mapper.Map<Setting>(createSettingDto);
            await _unitOfWork.Settings.AddAsync(settingEntity);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<SettingDto>(settingEntity);
        }

        public async Task<SettingDto> UpdateSettingAsync(int id, UpdateSettingDto updateSettingDto)
        {
            var settingEntity = await _unitOfWork.Settings.GetByIdAsync(id);
            _mapper.Map(updateSettingDto, settingEntity);
             _unitOfWork.Settings.Update(settingEntity);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<SettingDto>(settingEntity);
        }

        public async Task<bool> DeleteSettingAsync(int id)
        {
            var setting = await _unitOfWork.Settings.GetByIdAsync(id);
            if (setting == null)
            {
                return false;
            }
             _unitOfWork.Settings.Delete(setting);
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}

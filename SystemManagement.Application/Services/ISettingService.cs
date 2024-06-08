using SystemManagement.Application.DTOs;

namespace SystemManagement.Application.Services
{
    public interface ISettingService
    {
        Task<SettingDto> GetSettingByIdAsync(int id);
        Task<IEnumerable<SettingDto>> GetAllSettingsAsync();
        Task<SettingDto> AddSettingAsync(CreateSettingDto createSettingDto);
        Task<SettingDto> UpdateSettingAsync(int id, UpdateSettingDto updateSettingDto);
        Task<bool> DeleteSettingAsync(int id);
    }
}

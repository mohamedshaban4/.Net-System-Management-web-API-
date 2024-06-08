using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using SystemManagement.Application.DTOs;
using SystemManagement.Application.Services;
using SystemManagement.Core.Entities;

namespace SystemManagmentWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly ISettingService _settingService;

        public SettingsController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SettingDto>>> GetAllSettings()
        {
            var settings = await _settingService.GetAllSettingsAsync();
            return Ok(settings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SettingDto>> GetSettingById(int id)
        {
            var setting = await _settingService.GetSettingByIdAsync(id);
            if (setting == null)
            {
                return NotFound();
            }
            return Ok(setting);
        }

        [HttpPost]
        [Authorize]

        public async Task<ActionResult<SettingDto>> AddSetting(CreateSettingDto createSettingDto)
        {
            var setting = await _settingService.AddSettingAsync(createSettingDto);
            return CreatedAtAction(nameof(GetSettingById), new { id = setting.Id }, setting);
        }

        [HttpPut("{id}")]
        [Authorize]

        public async Task<IActionResult> UpdateSetting(int id, UpdateSettingDto updateSettingDto)
        {
            var setting = await _settingService.GetSettingByIdAsync(id);
            if (setting == null)
            {
                return NotFound();
            }
            await _settingService.UpdateSettingAsync(id, updateSettingDto);
            return  Ok($"The user With Id '{id}' and Name '{setting.Name}' has been Updated!!");
        }

        [HttpDelete("{id}")]
        [Authorize]

        public async Task<IActionResult> DeleteSetting(int id)
        {
            var result = await _settingService.DeleteSettingAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok($"The user With Id '{id}' has been Updated!!");

        }
    }
}

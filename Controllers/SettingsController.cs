using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Models;
using Data;

namespace Controllers
{
    //[Produces("application/json")]
    [Route("api/settings")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly MockSettings _mockSettings = new MockSettings();

        [HttpGet]
        public ActionResult <IEnumerable<Settings>> GetAllSettings()
        {
            var settings = _mockSettings.GetAllSettings();
            return Ok(settings);
        }

        [HttpGet("{type}")]
        public ActionResult <Settings> GetSettingsByType(string type)
        {
            var settings = _mockSettings.GetSettingsByType(type);

            if (settings != null)
            {
                return Ok(settings);
            }

            return NotFound();
        }
    }
}
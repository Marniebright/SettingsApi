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

        [HttpGet("merge/{type1}/{type2}")]
        public ActionResult <Settings> GetMergedSettings(string type1, string type2)
        {
            var settings = _mockSettings.GetMergedSettings(type1, type2);

            if (settings != null)
            {
                return Ok(settings);
            }

            return NotFound();
        }
    }
}
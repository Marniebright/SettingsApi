using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Models;
using Services;
using Data;

namespace Controllers
{
    [Produces("application/json")]
    [Route("api/settings")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly SettingsService _service = new SettingsService();

        [HttpGet]
        public ActionResult <Dictionary<string, Settings>> GetAllSettings()
        {
            var settings = _service.GetAllSettings();
            return Ok(settings);
        }

        [HttpGet("{filename}")]
        public ActionResult <Settings> GetSettingsByConfigFile(string filename)
        {
            var settings = _service.GetSettingsByConfigFile(filename);

            if (settings != null)
            {
                return Ok(settings);
            }

            return NotFound();
        }

        //[HttpGet("merge?filename={filename1}&&filename={filename2}")]
        
        [HttpGet("merge/{fileName1}/{filename2}")]
        public ActionResult <Settings> GetMergedConfigFile(string filename1, string filename2)
        {
            var settings = _service.GetMergedConfigFile(filename1, filename2);

            if (settings != null)
            {
                return Ok(settings);
            }

            return NotFound();
        }
    }
}
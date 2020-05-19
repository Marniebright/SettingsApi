using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Models;
using Services;

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
            try 
            {
                var settings = _service.GetSettingsByConfigFile(filename);

                if (settings != null)
                {
                    return Ok(settings);
                }

                return NotFound();
            }
            catch 
            {
                return NotFound();
            }
        }

        [HttpGet("merge")]
        public ActionResult <Settings> GetMergedConfigFile(string filename1, string filename2)
        {
            try 
            {
                var settings = _service.GetMergedConfigFile(filename1, filename2);

                if (settings != null)
                {
                    return Ok(settings);
                }

                return NotFound();
            }
            catch
            {
                return NotFound();
            }

        }
    }
}
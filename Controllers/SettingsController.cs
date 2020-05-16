using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Controllers
{
    [Produces("application/json")]
    [Route("api/settings")]
    public class SettingsController
    {
        Settings[] settings = new Settings[] 
        {
            new Settings { Type = "FullStackDeveloperSettings"},
            new Settings { Type = "WebDeveloperSettings"},
        };

        [HttpGet]
        public IEnumerable<Settings> ListAllSettings()
        {
            return settings;
        }

        [HttpGet("type/{value}")]
        public IEnumerable<Settings> ListSettingsByType(string value)
        {
            IEnumerable<Settings> newValue = 
                from val in settings 
                where val.Type.Equals(value)
                select val;

            return newValue;
        }
    }
}
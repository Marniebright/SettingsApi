using System.Collections.Generic;
using System.Linq;
using Models;

namespace Data {
    public class MockSettings : ISettings
    {
        private List<Settings> settings = new List<Settings> 
        {
            new Settings { Id = 0, Type = "FullStackDeveloperSettings"},
            new Settings { Id = 1, Type = "WebDeveloperSettings"},
        };

        public IEnumerable<Settings> GetAllSettings()
        {
            return settings;
        }

        public Settings GetSettingsByType(string type)
        {
            return settings.FirstOrDefault(p => p.Type == type);  
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Data {
    public class MockSettings : ISettings
    {
        private WebDeveloperSettings webDeveloperSettings = new WebDeveloperSettings(
            new Settings {
                Id = 0,
                Type = "Beginner",
                Platform = "Wordpress"
            }
        );
        private FullStackDeveloperSettings fullStackDeveloperSettings = new FullStackDeveloperSettings(
           new Settings {
                Id = 0,
                Type = "Beginner",
                Platform = "Wordpress"
            }
        );
       
        private List<Settings> settings = new List<Settings>
        {
            new Settings { Id = 0, Type = "FullStackDeveloperSettings"},
            new Settings { Id = 1, Type = "WebDeveloperSettings"}
        };
        public IEnumerable<Settings> GetAllSettings()
        {
            return settings;
        }

        public Settings GetSettingsByType(string type)
        {
            return settings.FirstOrDefault(p => p.Type == type);  
        }

        public IEnumerable<Settings> GetMergedSettings(string type1, string type2)
        {
            Settings settings1 = settings.FirstOrDefault(p => p.Type == type1);
            Settings settings2 = settings.FirstOrDefault(p => p.Type == type2);

            List<Settings> settingsList = new List<Settings>()
            {
                settings1,
                settings2
            };
            
            return settingsList;
        }
    }
}
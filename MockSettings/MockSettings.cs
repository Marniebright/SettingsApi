using System.Collections.Generic;
using Models;

namespace Data {
    public class MockSettings : ISettings
    {
        public IEnumerable<Settings> GetAllSettings()
        {
            Settings[] settings = new Settings[] 
            {
                new Settings { Id = 0, Type = "FullStackDeveloperSettings"},
                new Settings { Id = 1, Type = "WebDeveloperSettings"},
            };

            return settings;
        }

        public Settings GetSettingsByType()
        {
           return new Settings { Id = 0, Type = "FullStackDeveloperSettings"};
        }
    }
}
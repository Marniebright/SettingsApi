
using System.Collections.Generic;
using Models;
using Data;
using Newtonsoft.Json;

namespace Services {
    public class SettingsService : ISettings
    {  
        static string json = @"{
            'ServerSettings':
            {
                'apiKey': 'xxxx',
                'apiUser': 'admin'
            },
            'WebsiteSettings':
            {
                'apiKey': 'xxxx',
                'apiUser': 'thiswillbeoverriden'
            }
        }";

        static string json2 = @"{
            'ServerSettings':
            {
                'apiKey': 'xxxx',
                'apiUser': 'admin'
            },
            'WebsiteSettings':
            {
                'apiKey': 'xxxx',
                'apiUser': 'thiswillbeoverriden'
            }
        }";

        //get all files in the folder
        
        public Dictionary<string, Settings> GetAllSettings()
        { 
            Dictionary<string, Settings> settingsDictionary = JsonConvert.DeserializeObject<Dictionary<string, Settings>>(json);
            Dictionary<string, Settings> settingsDictionary2 = JsonConvert.DeserializeObject<Dictionary<string, Settings>>(json2);
      
            return null; //settingsDictionary + settingsDictionary2;
        }

        //get by file
        public Dictionary<string, Settings> GetSettingsByConfigFile(string filename)
        {
            Dictionary<string, Settings> settingsDictionary = JsonConvert.DeserializeObject<Dictionary<string, Settings>>(json);
            return settingsDictionary;
        }

        //get by 2 files
        public Dictionary<string, Settings> GetMergedConfigFile(string filename1, string filename2)
        {
            Dictionary<string, Settings> settingsDictionary = JsonConvert.DeserializeObject<Dictionary<string, Settings>>(json);
            Dictionary<string, Settings> settingsDictionary2 = JsonConvert.DeserializeObject<Dictionary<string, Settings>>(json2);
      
            return null;
        }
    }
}
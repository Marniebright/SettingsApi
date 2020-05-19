using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Models;

namespace Services 
{
    public class SettingsService : ISettings
    {  
        public Dictionary<string, Settings> GetAllSettings()
        { 
            Dictionary<string, Settings> settingsDictionary = new Dictionary<string, Settings>();

            foreach(string file in Directory.GetFiles("Resources", "*.json"))
            {  
                using(StreamReader r = File.OpenText(file))
                {
                    Dictionary<string, Settings> tempDictionary = JsonConvert.DeserializeObject<Dictionary<string, Settings>>
                    (
                        File.ReadAllText(file)
                    );
                   
                    foreach(var item in tempDictionary)
                    {
                        if (settingsDictionary.ContainsKey(item.Key))
                        {
                            continue;
                        }
                        else 
                        {
                            settingsDictionary.Add(item.Key, item.Value);
                        }
                    }
                }
            }
            return settingsDictionary;
        }

        public Dictionary<string, Settings> GetSettingsByConfigFile(string filename)
        {
            string filePath = @"Resources\\" + $"{filename}.json";
                
            Dictionary<string, Settings> settingsDictionary = JsonConvert.DeserializeObject<Dictionary<string, Settings>>
            (
                File.ReadAllText(filePath)
            );

            return settingsDictionary;
        }

        public Dictionary<string, Settings> GetMergedConfigFile(string filename1, string filename2)
        {
            Dictionary<string, Settings> settingsDictionary = GetSettingsByConfigFile(filename1);
            Dictionary<string, Settings> tempDictionary = GetSettingsByConfigFile(filename2);
            
            UpdateDuplicateKeys(tempDictionary, settingsDictionary);
        
            return settingsDictionary;
        }
        
        private void UpdateDuplicateKeys(Dictionary<string, Settings> tempDictionary, Dictionary<string, Settings> settingsDictionary)
        {
            foreach(var item in tempDictionary)
            {
                if(settingsDictionary.ContainsKey(item.Key))
                {
                    settingsDictionary[item.Key] = item.Value;
                }
                else 
                {
                    settingsDictionary.Add(item.Key, item.Value);
                }
            }
        }
    }
}
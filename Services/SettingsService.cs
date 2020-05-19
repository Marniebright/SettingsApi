using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Models;
using Data;
using System.IO;

namespace Services 
{
    public class SettingsService : ISettings
    {  
         Dictionary<string, Settings> settingsDictionary;
        public Dictionary<string, Settings> GetAllSettings()
        { 
            settingsDictionary = new Dictionary<string, Settings>();

            foreach(string file in Directory.GetFiles("Resources", "*.json"))
            {
                using(StreamReader r = File.OpenText(file))
                {
                    Dictionary<string, Settings> tempDictionary = JsonConvert.DeserializeObject<Dictionary<string, Settings>>
                    (
                        File.ReadAllText(file)
                    );
                    settingsDictionary = tempDictionary;

                    // foreach(var item in tempDictionary)
                    // {
                    //     if (settingsDictionary.ContainsKey(item.Key))
                    //     {
                    //         continue;
                    //     }
                    //     else 
                    //     {
                    //         settingsDictionary.Add(item.Key, item.Value);
                    //     }
                    // }

                }
            }
            return settingsDictionary;
        }

        //get by file
        public Dictionary<string, Settings> GetSettingsByConfigFile(string filename)
        {
            DeserializeJsonFile(filename);
            return settingsDictionary;
        }

        //get by 2 files
        public Dictionary<string, Settings> GetMergedConfigFile(string filename1, string filename2)
        {
            string filePath1 = @"Resources\\" + $"{filename1}.json";
            string filePath2 = @"Resources\\" + $"{filename2}.json";
                
            Dictionary<string, Settings> tempDictionary = JsonConvert.DeserializeObject<Dictionary<string, Settings>>
            (
                File.ReadAllText(filePath1)
            );

            Dictionary<string, Settings> tempDictionary2 = JsonConvert.DeserializeObject<Dictionary<string, Settings>>
            (
                File.ReadAllText(filePath2)
            );

            Dictionary<string, Settings> settingsDictionary = new Dictionary<string, Settings>(tempDictionary);

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

            foreach(var item in tempDictionary2)
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
            
            return settingsDictionary;
        }
        
        private void DeserializeJsonFile(string filename)
        {
            string filePath = @"Resources\\" + $"{filename}.json";
                
            settingsDictionary = JsonConvert.DeserializeObject<Dictionary<string, Settings>>
            (
                File.ReadAllText(filePath)
            );
        }
    }
}
using System.Collections.Generic;
using Models;

namespace Data
{
    public interface ISettings
    {
        Dictionary<string, Settings> GetAllSettings();
        Dictionary<string, Settings> GetSettingsByConfigFile(string filename);
        Dictionary<string, Settings> GetMergedConfigFile(string filename1, string filename2);
    }
}
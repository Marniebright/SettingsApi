using System.Collections.Generic;
using Models;

namespace Data
{
    public interface ISettings
    {
        IEnumerable<Settings> GetAllSettings();
        Settings GetSettingsByType(string type);
    }
}
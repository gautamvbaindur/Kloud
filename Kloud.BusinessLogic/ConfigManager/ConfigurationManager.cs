using System;
using System.Collections.Generic;
using System.Linq;
using CM = System.Configuration;

namespace KloudApp.ConfigManager
{
    public class ConfigurationManager : IConfigurationManager
    {
        //created a func here as we can add more configs in the future and this method might have to be repeated for all the configs that we have to fetch
        //creating a func here results in code reuse if we add more keys in the future
        private readonly Func<string, string> _config = configKey =>
        {
            if (CM.ConfigurationManager.AppSettings.AllKeys.Any(key => key == configKey))
            {
                return CM.ConfigurationManager.AppSettings[Constants.CARS_OWNERS_URL];
            }
            throw new KeyNotFoundException($"Key {configKey} not found in config file.");
        };

        public string GetCarsAndOwnersUrl()
        {
           return _config(Constants.CARS_OWNERS_URL);
        }
    }
}

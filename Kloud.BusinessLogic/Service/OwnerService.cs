using KloudApp.ConfigManager;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Kloud.Models;

namespace Kloud.BusinessLogic.Service
{
    public class OwnerService : IOwnerService
    {
        private readonly IConfigurationManager _configManager;

        public OwnerService(IConfigurationManager configManager)
        {
            _configManager = configManager;
        }

        public async Task<IEnumerable<Owner>> GetOwners()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync(_configManager.GetCarsAndOwnersUrl()))
                    {   
                        using (var content = response.Content)
                        {
                            var json = await content.ReadAsStringAsync();
                            var result = JsonConvert.DeserializeObject<List<Owner>>(json);
                            return result;
                        }
                    }

                }
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }
    }
}

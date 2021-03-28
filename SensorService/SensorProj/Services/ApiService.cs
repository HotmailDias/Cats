using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sensor.Config;
using Sensor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Sensor.Services
{
    public class ApiService : IApiService
    {
        private readonly IConfigSettings _iconfigSettings;
        private readonly ILogger<ApiService> _logger;

        public ApiService(IConfigSettings iconfigSettings, ILogger<ApiService> logger)
        {
            _iconfigSettings = iconfigSettings;
            _logger = logger;
        }

        public async Task<int> AddUsingC(int startNumber, int endNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PetOwner>> GetPetOwnersWithPets()
        {
            try
            {
                var petOwnerPetsData = new List<PetOwner>();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_iconfigSettings.ApiUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(_iconfigSettings.ApiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString =  await response.Content.ReadAsStringAsync();
                        petOwnerPetsData = JsonConvert.DeserializeObject <List<PetOwner>>(jsonString);

                    }

                    return petOwnerPetsData;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public interface IApiService
    {
        Task<int> AddUsingC(int startNumber, int endNumber);

        Task<List<PetOwner>> GetPetOwnersWithPets();

    }
    
}

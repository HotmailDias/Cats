using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Sensor.Services;
using Sensor.Model;
using Sensor.Processor;

namespace Sensor
{
    public class Cat_Func
    {
        private readonly IApiService _service;

        public Cat_Func(IApiService service)
        {
            _service = service;
        }

        [FunctionName("GetCat")]
        public async Task<PetOwnerPetsData> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                log.LogInformation("C# HTTP trigger function will process a request.", req);
                var data = new PetOwnerPetsData();
                var petOwnersWithPet = await _service.GetPetOwnersWithPets();
                data.PetOwnerPets = petOwnersWithPet.FilterBy(PetType.Cat);

                return data;
            }
            catch (Exception ex)
            {
                return new PetOwnerPetsData
                {
                    ErrorMessage = new Error()
                    {
                        UIMessage = "Something went wrong, Please try again",
                        Message = ex.ToString(),
                        ErrorCode = 500
                    }
                };
            }
        }
    }
}

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.IO;
using Http_trigger.Services.GuardiansService;

namespace Http_trigger
{
    public class Http_trigger
    {

        private readonly IGuardiansService _guardiansService;
        public Http_trigger(IGuardiansService guardiansService)
        {
            _guardiansService = guardiansService;
        }

        [FunctionName("Http_trigger")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string reqBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic body = JsonConvert.DeserializeObject(reqBody);

            string dateFrom = body.dateFrom;
            await _guardiansService.AddGuardiansData(dateFrom);

            return new OkObjectResult("---POPULATION DONE!---");
        }
    }
}
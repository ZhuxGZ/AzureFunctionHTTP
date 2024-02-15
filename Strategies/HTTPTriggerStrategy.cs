using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using AzureFunction.Interfaces;

namespace AzureFunction.Strategies
{
    public class HTTPTriggerStrategy : IStrategy
    {
        private HttpRequest _req;
        private ILogger _log;

        public HTTPTriggerStrategy (HttpRequest req, ILogger log)
        {
            _req = req;
            _log = log;
        }

        public async Task Run()
        {
            _log.LogInformation("C# HTTP trigger function processed a request.");


            string reqBody = await new StreamReader(_req.Body).ReadToEndAsync();
            dynamic body = JsonConvert.DeserializeObject(reqBody);
            string dateFrom = body?.dateFrom;

            AzureFunction azureFunction = new(_log, dateFrom);
            await azureFunction.Run();
            

            _log.LogInformation("---POPULATION DONE!---");
        }
    }
}


using System;
using AzureFunction.Context;
using AzureFunction.Entities;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using AzureFunction.Interfaces;


namespace AzureFunction.Strategies
{
     public class TimeTriggerStrategy : IStrategy
     {
        private Article _article;
        private ILogger _log;

        public TimeTriggerStrategy(ILogger log)
        {
            _log = log;
        }
        
        public async Task Run()
        {
            _log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

      
            _article = new();
           
            await _article.AddArticles(_log);

            _log.LogInformation("--- POPULATION DONE!---");
        }
     }
}



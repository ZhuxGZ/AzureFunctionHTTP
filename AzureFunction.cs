using System.Threading.Tasks;
using AzureFunction.Context;
using AzureFunction.Entities;
using Microsoft.Extensions.Logging;

namespace AzureFunction
{
	public class AzureFunction
	{
		
        private ILogger _log;
        private string _dateFrom;

        public AzureFunction(ILogger log, string dateFrom)
        {
            _log = log;
            _dateFrom = dateFrom;
        }

        public async Task Run()
		{
            
            Article article = new();

            await article.AddArticles(_log, _dateFrom);
        }
    }
}


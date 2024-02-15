using System.Threading.Tasks;
using AzureFunction.Context;
using AzureFunction.Entities;
using Microsoft.Extensions.Logging;

namespace AzureFunction
{
	public class AzureFunction
	{
		private string _dateFrom;
		private ILogger _log;

		public AzureFunction(string dateFrom, ILogger log)
		{
            _dateFrom = dateFrom;
            _log = log;

        }

		public async Task Run()
		{
            
            Article article = new();

            await article.AddArticles(_dateFrom, _log);
        }
    }
}


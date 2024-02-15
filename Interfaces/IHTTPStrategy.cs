using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace AzureFunction.Interfaces
{
	public interface IStrategy
	{
		public Task Run();
	}
}


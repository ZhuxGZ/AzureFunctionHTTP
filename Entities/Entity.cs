using System;
using System.Net.Http;
using System.Threading.Tasks;
using ampETL;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace AzureFunction.Entities
{
	public class Entity
	{
		public Entity()
		{
		}

		public static async Task<dynamic> GetData(string apiUrl, ILogger log)
		{
            using HttpClient client = new();
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string JSONcontent = await response.Content.ReadAsStringAsync();
                    dynamic content = JsonConvert.DeserializeObject(JSONcontent);
                    return content;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new BaseException(ex, "AzureFunction", "data", log, null);
            }
        }
	}
}


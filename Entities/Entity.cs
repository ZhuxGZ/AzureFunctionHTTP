using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace AzureFunction.Entities
{
	public class Entity
	{
		public Entity()
		{
		}

		public static async Task<dynamic> GetData(string apiUrl)
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
                return null;
            }
        }
	}
}


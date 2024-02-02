using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Http_trigger
{
	public class GetApiData
	{
		public static async Task<string> GetGuardiansData(string dateFrom, int pageNum=1)
		{
            string apiKey = "f591d9de-58a8-4b5b-9253-a2aeaa692d37";
            string apiUrl = $"https://content.guardianapis.com/search?from-date={dateFrom}&page-size=200&page={pageNum}&api-key={apiKey}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
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
}


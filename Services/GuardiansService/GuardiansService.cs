using System;
using System.Collections.Generic;
using Http_trigger.data;
using Http_trigger.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Http_trigger.Services.GuardiansService
{
	public class GuardiansService : IGuardiansService
	{
        private readonly DataContext _context;
        public GuardiansService(DataContext context)
        {
            _context = context;
        }

        public async Task<GuardiansData> AddGuardiansData(string dateFrom)
        {
            dynamic responsePages = JsonConvert.DeserializeObject(await GetApiData.GetGuardiansData(dateFrom));
            int existingPages = responsePages.response.pages;

  
            for (int actualPage = 1; actualPage <= existingPages; actualPage++)
            {
                dynamic response = JsonConvert.DeserializeObject(await GetApiData.GetGuardiansData(dateFrom, actualPage));
                dynamic results = response.response.results;

                foreach (dynamic result in results)
                {
                    if (_context.GuardiansData.Find(result.id.ToString()) == null)
                    {
                        GuardiansData guardiansData = new()
                        {
                            Id = result.id,
                            Type = result.type,
                            SectionName = result.sectionName,
                            PillarName = result.pillarName == null ? String.Empty : result.pillarName,
                            Title = result.webTitle,
                            ArticleUrl = result.webUrl,
                            PublicationDate = result.webPublicationDate
                        };


                        _context.GuardiansData.Add(guardiansData);
                    }

                }

                _context.SaveChanges();
            }

            return null;
        }
	}
}


using System;
using System.Threading.Tasks;
using ampETL;
using ampETLCommon.dtos;
using ampETLCommon.repositories;
using System.Data;
using Microsoft.Extensions.Logging;

namespace AzureFunction.Entities
{
    public class Article : Entity
    {
        private readonly string _tableName = "StageArticles";
        private readonly string _cnLocalDb = Environment.GetEnvironmentVariable("conectionString");

        public async Task<ArticleDTO> AddArticles(ILogger log, string dateFrom = "")
        {
            try
            {
                DataTable dt_stage = ampETL.TableUtils.GetStagingTable(_tableName, _cnLocalDb);
                int existingPages = 1;

                for (int actualPage = 1; actualPage <= existingPages; actualPage++)
                {

                    string apiKey = Environment.GetEnvironmentVariable("GuardiansAPI_AuthKey");
                    string apiUrl;

                    if (dateFrom == null)
                    {
                        apiUrl = $"https://content.guardianapis.com/search?page-size=200&api-key={apiKey}";
                    }
                    else
                    {
                        apiUrl = $"https://content.guardianapis.com/search?from-date={dateFrom}&page-size=200&page={actualPage}&api-key={apiKey}";
                    }

                    dynamic response = await GetData(apiUrl, log);
                    dynamic results = response?.response?.results;

                    if (dateFrom != null)
                    {
                        existingPages = response?.response?.pages;
                    }



                    foreach (dynamic result in results)
                    {
                        ArticleDTO dto = new()
                        {
                            ArticleId = result.id,
                            Type = result.type,
                            SectionName = result.sectionName,
                            PillarName = result.pillarName ?? String.Empty,
                            Title = result.webTitle,
                            ArticleUrl = result.webUrl,
                            PublicationDate = result.webPublicationDate
                        };

                        ArticleRepository repository = new();
                        repository.stageRows(ref dt_stage, dto);

                    }

                    dt_stage.AcceptChanges();
                }

                ampETL.TableUtils.StageData($"dbo.{_tableName}", dt_stage, _cnLocalDb);
                return null;
            } catch(Exception ex)
            {
                throw new BaseException(ex, "AzureFunction", "articles", log, null);
            }
        }
    }
}
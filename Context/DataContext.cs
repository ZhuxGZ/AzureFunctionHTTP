using Microsoft.EntityFrameworkCore;
using ampETLCommon.dtos;

namespace AzureFunction.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=azureApi;User=sa;Password=P@ssword1234;Trusted_Connection=False;Encrypt=false");
        }

        public DbSet<ArticleDTO> StageArticles{ get; set; }
    }
}

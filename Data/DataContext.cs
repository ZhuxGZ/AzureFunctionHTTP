using System;
using Microsoft.EntityFrameworkCore;
using Http_trigger.Models;

namespace Http_trigger.data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=azureApi;User=sa;Password=P@ssword1234;Trusted_Connection=False;Encrypt=false");
        }

        public DbSet<GuardiansData> GuardiansData{ get; set; }
    }
}

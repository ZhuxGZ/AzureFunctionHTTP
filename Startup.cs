using System;
using Http_trigger.data;
using Http_trigger.Services.GuardiansService;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Http_trigger.Startup))]

namespace Http_trigger
{
	
        public class Startup : FunctionsStartup
        {
            public override void Configure(IFunctionsHostBuilder builder)
            {
                builder.Services.AddScoped<IGuardiansService, GuardiansService>();
                builder.Services.AddDbContext<DataContext>();
            }
        }
    
}


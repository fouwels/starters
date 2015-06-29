using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using Microsoft.Framework.Logging.Console;

namespace proj
{
    public class Startup
    {
		public IConfiguration Configuration { get; set; }
		public Startup()
		{
			var configuration = new Configuration()
			  .AddJsonFile("config.json");
			//configuration.AddUserSecrets(); secrets-manager broken on nuget

			Configuration = configuration;
		}
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddMvc();
			services.AddLogging();

			Debug.WriteLine("Configured Services - file check val:" + Configuration["data:IntendedConfigCheckValue"]); // indentify config mis match
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory LoggerFactory, ILogger<Startup> logger)
        {
			LoggerFactory.AddConsole(LogLevel.Information);

			app.Use(async (context, next) =>
		    {
			   var s = ("[Pipeline0] Request to:" + context.Request.Path);
			   logger.LogInformation(s);
			   Debug.WriteLine(s);
			   await next();
		    });

			app.UseErrorPage();
			app.UseMvc();
			
        }
    }
}

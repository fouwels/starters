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
			//configuration.AddUserSecrets(); broken package on dnu

			Configuration = configuration;
		}
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddMvc();
			services.AddLogging();

			Debug.WriteLine("Configured Services - config check value:" + Configuration["data:IntendedConfigCheckValue"]); // Indentify accidental config file mis-match
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory LoggerFactory)
        {
			LoggerFactory.AddConsole(LogLevel.Information);


            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
			app.UseMvc();
			app.UseErrorPage();
        }
    }
}

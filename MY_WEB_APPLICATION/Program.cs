using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace MY_WEB_APPLICATION
{
	public class Program : object
	{
		public Program() : base()
		{
		}

		public static void Main(string[] args)
		{
			//BuildWebHost(args).Run();

			var host = BuildWebHost(args);

			using (var scope = host.Services.CreateScope())
			{
				var services =
					scope.ServiceProvider;

				try
				{
					var databaseContext =
						services.GetRequiredService<Models.DatabaseContext>();

					Models.DatabaseInitializer.Initialize(databaseContext);
				}
				catch (System.Exception ex)
				{
					var logger =
						services.GetRequiredService<Microsoft.Extensions.Logging.ILogger<Program>>();

					logger.LogError(ex, "An error occurred while seeding the database.");
				}
			}

			host.Run();
		}

		public static Microsoft.AspNetCore.Hosting.IWebHost BuildWebHost(string[] args) =>
			Microsoft.AspNetCore.WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>()
				.Build();
	}
}

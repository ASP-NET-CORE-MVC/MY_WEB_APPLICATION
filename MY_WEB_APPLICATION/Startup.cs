using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MY_WEB_APPLICATION
{
	public class Startup : object
	{
		public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(Microsoft.Extensions.DependencyInjection.IServiceCollection services)
		{
			services.AddMvc();

			// به کنترلرها تزریق کنیم، به این دستور نیاز داریم DatabaseContext در صورتی که بخواهیم
			services.AddDbContext<Models.DatabaseContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString(name: "DatabaseContext")));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure
			(Microsoft.AspNetCore.Builder.IApplicationBuilder app,
			Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseBrowserLink();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});

			// به برنامه اضافه کنیم، به این دستور نیاز داریم Area در صورتی که بخواهیم
			app.UseMvc(routes =>
			{
				routes.MapRoute(
				  name: "areas",
				  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
				);
			});
		}
	}
}

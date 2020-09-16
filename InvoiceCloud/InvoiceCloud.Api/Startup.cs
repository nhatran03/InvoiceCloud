using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using InvoiceCloud.Ef.Ef;
using InvoiceCloud.Domain.Repositories;
using InvoiceCloud.Ef.Ef.Repositories;
using InvoiceCloud.Service.Recipes;
using AutoMapper;

namespace InvoiceCloud.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
			services.AddScoped(_ => new InvoiceCloudDbContext(Configuration.GetConnectionString("Default")));

			services.AddAutoMapper(typeof(Startup));
			services.AddScoped(typeof(IRepository<>), typeof(EfRepositoryBase<>));
			services.AddScoped(typeof(IRepository<,>), typeof(EfRepositoryBase<>));

			services.AddTransient<IRecipeService, RecipeService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}

using E_ShopManagerWEB.Data;
using Microsoft.EntityFrameworkCore;

namespace E_ShopManagerWEB
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddRazorPages();

			//Agg Contexto
			builder.Services.AddDbContext<E_ShopManagerContext> (options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("E-ShopManagerDB"))
			);

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapRazorPages();

			app.Run();
		}
	}
}

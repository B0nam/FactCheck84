using FactCheck84.Data;
using FactCheck84.Models;
using FactCheck84.Services;
using Microsoft.EntityFrameworkCore;

namespace FactCheck84
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string mySqlConnection =
                builder.Configuration.GetConnectionString("FactCheck84Context");

            builder.Services.AddDbContext<FactCheck84Context>(options =>
                options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<FactCheck84Seeder>();
            builder.Services.AddScoped<CensorshipService>();

            var app = builder.Build();
            
            app.Services.CreateScope().ServiceProvider.GetRequiredService<FactCheck84Seeder>().Seed();
            app.Services.CreateScope().ServiceProvider.GetRequiredService<CensorshipService>().GeneralCensorship();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
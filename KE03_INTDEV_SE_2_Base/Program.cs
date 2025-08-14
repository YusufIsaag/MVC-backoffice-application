using System;
using KE03_INTDEV_SE_2_Base.Data;
using KE03_INTDEV_SE_2_Base.Models;

using Microsoft.EntityFrameworkCore;

namespace KE03_INTDEV_SE_2_Base
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddTransient<EmailSender>();


            // Add services to the container.
            // We gebruiken voor nu even een SQLite voor de database,
            // omdat deze eenvoudig lokaal te gebruiken is en geen extra configuratie nodig heeft.
            builder.Services.AddDbContext<StarWarsDbContext>(
                options => options.UseSqlite("Data Source=StarWars.db"));
            builder.Services.AddControllersWithViews();

            // We registreren de repositories in de DI container
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Zorg ervoor dat de database is aangemaakt en gevuld met testdata
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<StarWarsDbContext>();
                context.Database.EnsureCreated();
                StarWarsDbInitializer.Initialize(context);
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

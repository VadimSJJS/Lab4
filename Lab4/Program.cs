//using Lab4.Data;
using Lab4;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        string connectionString = builder.Configuration.GetConnectionString("MSSQL");
        builder.Services.AddDbContext<PharmacyContext>(option => option.UseSqlServer(connectionString));
        builder.Services.AddControllersWithViews(options => {
            options.CacheProfiles.Add("ModelCache",
                new CacheProfile()
                {
                    Location = ResponseCacheLocation.Any,
                    Duration = 2 * 3 + 240
                });
        });

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        
        app.MapControllerRoute(
            name: "medicine",
            pattern: "{controller=Medicine}/{action=ShowTable}");
 
        
        app.MapControllerRoute(
            name: "outgoing",
            pattern: "{controller=Outgoing}/{action=ShowTable}");

        app.MapControllerRoute(
            name: "producer",
            pattern: "{controller=Producer}/{action=ShowTable}");
        
        app.Run();

    }
}


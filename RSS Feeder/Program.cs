using RSS_Feeder.Settings;

namespace RSS_Feeder;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddControllersWithViews();

        builder.Configuration.AddJsonFile("settings.json");

        var app = builder.Build();
        
        SettingsOptions.RssUrl = app.Configuration["rssUrl"];
        SettingsOptions.ProxyAddress = app.Configuration["proxyAddress"];
        SettingsOptions.ProxyLogin = app.Configuration["proxyLogin"];
        SettingsOptions.ProxyPassword = app.Configuration["proxyPassword"];
        SettingsOptions.UseProxy = bool.Parse(app.Configuration["useProxy"]);
        SettingsOptions.RefreshRate = int.Parse(app.Configuration["refreshRate"]);
        
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=RssFeeder}/{action=Index}/{id?}");

        app.Run();
    }
}
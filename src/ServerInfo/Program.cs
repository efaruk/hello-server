using Microsoft.AspNetCore.HttpOverrides;
using ServerInfo.Services;

namespace ServerInfo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddSingleton<IServerInformationService, ServerInformationService>();

            // Behind Proxy/Load Balancer
            builder.Services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.KnownProxies.Clear();
                options.KnownNetworks.Clear();
                options.ForwardedHeaders = ForwardedHeaders.All;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // Behind Proxy/Load Balancer
            app.UseForwardedHeaders();

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

using Lamar.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Mmu.CleanBlazor.Common.Settings.Config.Services;
using Mmu.CleanBlazor.Common.Settings.Provisioning.Models;

namespace Mmu.CleanBlazor.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var config = ConfigurationFactory.Create();
            builder.Services.Configure<AppSettings>(config.GetSection(AppSettings.SectionKey));

            // Add services to the container.
            builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));
            builder.Services.AddControllersWithViews()
                .AddMicrosoftIdentityUI();

            builder.Host.UseLamar(serviceRegistry =>
            {
                serviceRegistry.Scan(
                    scanner =>
                    {
                        scanner.AssembliesFromApplicationBaseDirectory();
                        scanner.LookForRegistries();
                    });
            });

            builder.Services.AddAuthorization(options =>
            {
                // By default, all incoming requests will be authorized according to the default policy
                options.FallbackPolicy = options.DefaultPolicy;
            });

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor()
                .AddMicrosoftIdentityConsentHandler();

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

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}
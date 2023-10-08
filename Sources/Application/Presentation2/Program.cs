using Lamar.Microsoft.DependencyInjection;
using Mmu.CleanBlazor.Common.Settings.Config.Services;
using Mmu.CleanBlazor.Common.Settings.Provisioning.Models;

namespace Mmu.CleanBlazor.Presentation2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var config = ConfigurationFactory.Create();
            builder.Services.Configure<AppSettings>(config.GetSection(AppSettings.SectionKey));

            builder.Host.UseLamar(serviceRegistry =>
            {
                serviceRegistry.Scan(
                    scanner =>
                    {
                        scanner.AssembliesFromApplicationBaseDirectory();
                        scanner.LookForRegistries();
                    });
            });

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

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
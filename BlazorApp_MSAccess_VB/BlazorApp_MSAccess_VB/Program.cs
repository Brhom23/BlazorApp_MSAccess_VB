using BlazorApp_MSAccess_VB.Client.Pages;
using BlazorApp_MSAccess_VB.Components;
using BlazorApp_MSAccess_VB.Components.Account;
using BlazorApp_MSAccess_VB.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace BlazorApp_MSAccess_VB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();

            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddScoped<IdentityUserAccessor>();
            builder.Services.AddScoped<IdentityRedirectManager>();
            builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

            builder.Services.AddAuthentication(options =>
                {
                    options.DefaultScheme = IdentityConstants.ApplicationScheme;
                    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
                })
                .AddIdentityCookies();

            //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            //builder.Services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(connectionString));

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection_jet") ?? throw new InvalidOperationException("Connection string 'DefaultConnection_jet' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseJet(connectionString, b => b.MigrationsAssembly("BlazorApp_MSAccess_VB")));


            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

            builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                db.Database.Migrate();
                //≈‰ ·„  ﬂ‰ ﬁ«⁄œ… «·»Ì«‰«  „ÊÃÊœ…  ‰‘√Â« »„« ÂÊ „Ê’Ê› ›Ì 
                //ApplictionDBContext
                //Ê≈‰ ﬂ«‰  ﬁ«⁄œ… «·»Ì«‰«  „ÊÃÊœ… ·« Ì›⁄· ‘Ì∆ Õ Ï ·Ê  €Ì— „Õ ÊÏ
                //ApplictionDBContext
                //db.Database.EnsureCreated();
                DbInitializer.Initialize(db);

            }

            //using (var scope = app.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;

            //    var context = services.GetRequiredService<ApplicationDbContext>();
            //    context.Database.EnsureCreated();
            //    // DbInitializer.Initialize(context);
            //}



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Counter).Assembly);

            // Add additional endpoints required by the Identity /Account Razor components.
            app.MapAdditionalIdentityEndpoints();

            app.Run();
        }
    }
}

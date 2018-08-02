using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using filmdesigners.at.Data;
using filmdesigners.at.Models;
using filmdesigners.at.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using filmdesigners.at.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using System.Runtime.InteropServices;

namespace filmdesigners.at
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                var hostname = Environment.GetEnvironmentVariable("SQLSERVER_HOST") ?? "localhost";
                var password = Environment.GetEnvironmentVariable("SQLSERVER_SA_PASSWORD") ?? "123..abc";
                var connString = $"Data Source={hostname};Initial Catalog=filmdesigners.at;User ID=sa;Password={password};";

                //add framework services.
                services.AddDbContext<ApplicationDbContext>(options =>
                    //Old LocalDB Config
                    //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
                // NEW DOCKER SQL SERVER
                options.UseSqlServer($"Data Source=localhost;Initial Catalog=filmdesigners.at;User ID=sa;Password=123..abc"));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // Require SSL
                // TODO: Enable RequireHttps again (disabled for development on Mac)
                services.Configure<MvcOptions>(options =>
                {
                    options.Filters.Add(new RequireHttpsAttribute());
                });

                //add framework services.
                //services.AddDbContext<ApplicationDbContext>(options =>
                    //Old LocalDB Config
                    //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
                    // NEW DOCKER SQL SERVER
                    //options.UseSqlServer($"Data Source=localhost;Initial Catalog=filmdesigners.at;User ID=sa;Password=123..abc"));
            }
            // Require SSL
            // TODO: Enable RequireHttps again (disabled for development on Mac)
            services.Configure<MvcOptions>(options =>
            {
                //options.Filters.Add(new RequireHttpsAttribute());
            });

            //add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                //Old LocalDB Config
                //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
                // NEW DOCKER SQL SERVER
                options.UseSqlServer($"Data Source=localhost;Initial Catalog=filmdesigners.at;User ID=sa;Password=123..abc"));

            services.AddIdentity<ApplicationUser, IdentityRole>(config =>
            {
                config.SignIn.RequireConfirmedEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();

                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.Configure<AuthMessageSenderOptions>(Configuration);

            //AuthorizationHandlers
            services.AddScoped<IAuthorizationHandler, MemberIsOwnerAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, MemberAdministratorAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, MemberManagerAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, ChapterAdministratorAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, EnrollmentAdministratorAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, EventsAdministratorAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, JobsAdministratorAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, NewslettersAdministratorAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, RolesAdministratorAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, UsersAdministratorAuthorizationHandler>();



            var serviceProvider = services.BuildServiceProvider();

            var dbContext = serviceProvider.GetService<ApplicationDbContext>();

            SeedUsers.Initialize(serviceProvider);
            //SeedJobs.Initialize(serviceProvider);
            //SeedMembers.Initialize(serviceProvider);

            return serviceProvider;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //Set password with the Secret Manager tool
            //dotnet user-secrets set SeedUserPW <PW>

            var AdminUserPW = Configuration["SeedUserPW"];
            
            if (string.IsNullOrEmpty(AdminUserPW))
            {
                /*
                throw new SystemException("Use Secret Manager Tool to set SeedUserPW. \n" +
                    "dotnet user-secrets set SeedUserPW <PW>");
                    */

                AdminUserPW = "123..abc";
            }

            //var empty = SeedMembers.EnsureRole(app.ApplicationServices, "bf2a756-3dd4-4883-b2b4-33fdcec9b9d2", Constants.EnrollmentAdministratorsRole);
            /*
            try
            {*/
            //SeedMembers.Initialize(app.ApplicationServices, "").Wait();
            /*
        }
        catch
        {
            throw new SystemException("You need to update the Database "
                + "\nPM Update-Database " + "\n or \n" +
                ">dotnet ef database update"
                + "\nIf that doesn't work, comment out SeedMembers and register a new User.");
        }
        */

            // Redirect HTTP to HTTPS
            var options = new RewriteOptions()
                .AddRedirectToHttps();

            app.UseRewriter(options);
        }

        public static OSPlatform GetOSPlatform()
        {
            OSPlatform osPlatform = OSPlatform.Create("Other Platform");
            // Check if it's windows 
            bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            osPlatform = isWindows ? OSPlatform.Windows : osPlatform;
            // Check if it's osx 
            bool isOSX = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
            osPlatform = isOSX ? OSPlatform.OSX : osPlatform;
            // Check if it's Linux 
            bool isLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
            osPlatform = isLinux ? OSPlatform.Linux : osPlatform;
            return osPlatform;
        }
    }
}

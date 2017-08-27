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
            //add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
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

            //AuthorizationHandlers
            services.AddScoped<IAuthorizationHandler, MemberIsOwnerAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, MemberAdministratorAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, MemberManagerAuthorizationHandler>();

            var serviceProvider = services.BuildServiceProvider();

            var dbContext = serviceProvider.GetService<ApplicationDbContext>();

            SeedMembers.Initialize(serviceProvider, "JQ$uk1n!vs");

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

            if(string.IsNullOrEmpty(AdminUserPW))
            {
                throw new SystemException("Use Secret Manager Tool to set SeedUserPW. \n" +
                    "dotnet user-secrets set SeedUserPW <PW>");
            }
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
        }
    }
}

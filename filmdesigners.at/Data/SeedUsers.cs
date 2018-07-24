#define SeedOnly
#if SeedOnly

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using filmdesigners.at.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using filmdesigners.at.Authorization;


namespace filmdesigners.at.Data
{
    public class SeedUsers
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.ApplicationUser.Count() < 3)
                {
                    var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

                    // Seed Management Board ApplicationUsers
                    var BirgitHutter = new ApplicationUser
                    {
                        Email = "hutterbirgit@gmail.com",
                        EmailConfirmed = true,
                        LockoutEnabled = true,
                        UserName = "hutterbirgit@gmail.com"
                    };
                    var HansJager = new ApplicationUser
                    {
                        Email = "jager@a1.net",
                        EmailConfirmed = true,
                        LockoutEnabled = true,
                        UserName = "jager@a1.net"
                    };
                    var EnidLoser = new ApplicationUser
                    {
                        Email = "enid@chello.at",
                        EmailConfirmed = true,
                        LockoutEnabled = true,
                        UserName = "enid@chello.at"
                    };
                    var BrigittaFink = new ApplicationUser
                    {
                        Email = "brigittafink@gmx.at",
                        EmailConfirmed = true,
                        LockoutEnabled = true,
                        UserName = "brigittafink@gmx.at"
                    };
                    var ChristineLudwig = new ApplicationUser
                    {
                        Email = "c.ludwig.cl@gmail.com",
                        EmailConfirmed = true,
                        LockoutEnabled = true,
                        UserName = "c.ludwig.cl@gmail.com"
                    };
                    var HansJorgMikesch = new ApplicationUser
                    {
                        Email = "office@szenenbild.at",
                        EmailConfirmed = true,
                        LockoutEnabled = true,
                        UserName = "office@szenenbild.at"
                    };
                    var FlorianReichmann = new ApplicationUser
                    {
                        Email = "mail@f-reichmann.at",
                        EmailConfirmed = true,
                        LockoutEnabled = true,
                        UserName = "mail@f-reichmann.at"
                    };
                    var HannesSalat = new ApplicationUser
                    {
                        Email = "salatbox@mac.com",
                        EmailConfirmed = true,
                        LockoutEnabled = true,
                        UserName = "salatbox@mac.com"
                    };
                    var DanielSteinbach = new ApplicationUser
                    {
                        Email = "danielsteinbach@gmx.net",
                        EmailConfirmed = true,
                        LockoutEnabled = true,
                        UserName = "danielsteinbach@gmx.net"
                    };
                    var ThomasVogel = new ApplicationUser
                    {
                        Email = "th.voegel@gmail.com",
                        EmailConfirmed = true,
                        LockoutEnabled = true,
                        UserName = "th.voegel@gmail.com"
                    };

                    await userManager.CreateAsync(BirgitHutter, "123..Abc");
                    await userManager.CreateAsync(HansJager, "123..Abc");
                    await userManager.CreateAsync(EnidLoser, "123..Abc");
                    await userManager.CreateAsync(BrigittaFink, "123..Abc");
                    await userManager.CreateAsync(ChristineLudwig, "123..Abc");
                    await userManager.CreateAsync(HansJorgMikesch, "123..Abc");
                    await userManager.CreateAsync(FlorianReichmann, "123..Abc");
                    await userManager.CreateAsync(HannesSalat, "123..Abc");
                    await userManager.CreateAsync(DanielSteinbach, "123..Abc");
                    await userManager.CreateAsync(ThomasVogel, "123..Abc");

                    // Seed Service Users
                    var Admin = new ApplicationUser
                    {
                        Email = "admin@filmdesigners.at",
                        EmailConfirmed = true,
                        LockoutEnabled = true,
                        UserName = "admin@filmdesigners.at"
                    };

                    await userManager.CreateAsync(Admin, "123..Abc");

                    // Assign Users to Roles
                    await EnsureRole(serviceProvider, Admin.Id, Constants.MembersAdministratorsRole);
                    await EnsureRole(serviceProvider, Admin.Id, Constants.ChapterAdministratorsRole);
                    await EnsureRole(serviceProvider, Admin.Id, Constants.EnrollmentAdministratorsRole);
                    await EnsureRole(serviceProvider, Admin.Id, Constants.RolesAdministratorsRole);
                    await EnsureRole(serviceProvider, Admin.Id, Constants.UsersAdministratorsRole);
                    await EnsureRole(serviceProvider, Admin.Id, Constants.JobsAdministratorsRole);
                    await EnsureRole(serviceProvider, Admin.Id, Constants.EventsAdministratorsRole);
                    await EnsureRole(serviceProvider, Admin.Id, Constants.NewslettersAdministratorsRole);
                    await SeedJobs.Initialize(serviceProvider);
                }
                await SeedJobs.Initialize(serviceProvider);
            }
        }

        public static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider, string UserID, string Role)
        {
            IdentityResult IR = null;

            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync(Role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(Role));
            }

            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByIdAsync(UserID);

            IR = await userManager.AddToRoleAsync(user, Role);

            return IR;
        }
    }
}

#endif
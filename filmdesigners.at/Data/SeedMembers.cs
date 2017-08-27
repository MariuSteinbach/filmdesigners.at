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
    public class SeedMembers
    {
        #region snippet_Initialize
        public static async Task Initialize(IServiceProvider serviceProvider, string adminPW)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                var adminID = await EnsureUser(serviceProvider, adminPW, "admin@filmdesigners.at");
                await EnsureRole(serviceProvider, adminID, Constants.MembersAdministratorsRole);

                var uid = await EnsureUser(serviceProvider, adminPW, "manager@filmdesigners.at");
                await EnsureRole(serviceProvider, adminPW, Constants.MembersManagersRole);

                SeedDB(context, adminID);
            }
        }
        #endregion
#region snippet_CreateRoles

        public static async Task<string> EnsureUser(IServiceProvider serviceProvider, string adminPW, string UserName)
        {
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByNameAsync(UserName);
            if(user == null)
            {
                user = new ApplicationUser
                {
                    UserName = UserName
                };
                await userManager.CreateAsync(user, adminPW);
            }

            return user.Id;
        }

        public static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider, string uid, string role)
        {
            IdentityResult IR = null;

            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if(! await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByIdAsync(uid);

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }
        #endregion
        #region snippet1
        public static void SeedDB(ApplicationDbContext context, string adminID)
        {
            if(context.Member.Any())
            {
                return;
            }

            context.Member.AddRange(
            #region snippet_Member
                new Member
                {
                    Name = "Administrator",
                    Status = MemberStatus.Approved,
                    OwnerID = adminID

                }
                #endregion
                #endregion
            );

            context.SaveChanges();
        }
    }
}
#endif

using MemeManager.Authorization;
using MemeManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

// dotnet aspnet-codegenerator razorpage -m Contact -dc ApplicationDbContext -udl -outDir Pages\Contacts --referenceScriptLibraries

namespace MemeManager.Data
{
    public static class SeedData
    {
        //public GalleryImage ImageLink { get; set; }

        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // For sample purposes we are seeding 2 users both with the same password.
                // The password is set with the following command:
                // dotnet user-secrets set SeedUserPW <pw>
                // The admin user can do anything

                var adminID = await EnsureUser(serviceProvider, testUserPw, "admin@memes.com");
                await EnsureRole(serviceProvider, adminID, Constants.MemeAdministratorsRole);

                // allowed user can create and edit contacts that they create
                var uid = await EnsureUser(serviceProvider, testUserPw, "manager@memes.com");
                await EnsureRole(serviceProvider, uid, Constants.MemeManagersRole);

                SeedDB(context, adminID);
            }
        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
                                             string testUserPw, string UserName)
        {
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new ApplicationUser { UserName = UserName };
                await userManager.CreateAsync(user, testUserPw);
            }

            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                                string uid, string role)
        {
            IdentityResult IR = null;
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByIdAsync(uid);

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }

        public static void SeedDB(ApplicationDbContext context, string adminID)
        {
            if (context.Meme.Any())
            {
                return;   // DB has been seeded
            }

            context.Meme.AddRange(
                new Meme
                {
                    Title = "Thanos Did Nothing Wrong",
                    Genre = "Infinity War",
                    Status = MemeStatus.Approved,
                    OwnerID = adminID,

                    //Image = GalleryImage.URL. Still trying to figure out how to tie together these tables...can't figure it out. 
                },
                new Meme
                {
                    Title = "Marky Mark",
                    Genre = "E",
                    Status = MemeStatus.Approved,
                    OwnerID = adminID
                },
             new Meme
             {
                 Title = "Frog Man",
                 Genre = "Pepe",
                 Status = MemeStatus.Approved,
                 OwnerID = adminID
             },
             new Meme
             {
                 Title = "Same",
                 Genre = "Savage Patrick",
                 Status = MemeStatus.Approved,
                 OwnerID = adminID
             },
            new Meme
            {
                Title = "Cute Dog",
                Genre = "Doggo",
                Status = MemeStatus.Approved,
                OwnerID = adminID
            }
             );
            context.SaveChanges();
        }
    }
}
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialMediaCircleApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaCircleApp.Data.Helpers.Constants;

namespace SocialMediaCircleApp.Data.Helpers
{
    public static class DbInitializer
    {
        public static async Task SeedUsersAndRolesAsync(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            //Roles
            if (!roleManager.Roles.Any())
            {
                foreach (var roleName in AppRoles.All)
                {
                    if (!await roleManager.RoleExistsAsync(roleName))
                    {
                        await roleManager.CreateAsync(new IdentityRole<int>(roleName));
                    }
                }
            }

            //Users with Roles
            if (!userManager.Users.Any())
            {
                var userPassword = "Coding@1234?";
                var newUser = new User()
                {
                    UserName = "rahul.khatri",
                    Email = "rahul@khatri.com",
                    FullName = "Rahul Khatri",
                    ProfilePictureUrl = "https://i.postimg.cc/VLhv3468/me-jpg.jpg",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(newUser, userPassword);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(newUser, AppRoles.User);


                var newAdmin = new User()
                {
                    UserName = "admin.admin",
                    Email = "admin@khatri.com",
                    FullName = "Rahul Admin",
                    ProfilePictureUrl = "https://i.postimg.cc/VLhv3468/me-jpg.jpg",
                    EmailConfirmed = true
                };

                var resultNewAdmin = await userManager.CreateAsync(newAdmin, userPassword);
                if (resultNewAdmin.Succeeded)
                    await userManager.AddToRoleAsync(newAdmin, AppRoles.Admin);
            }
        }

        public static async Task SeedAsync(AppDbContext appDbContext)
        {
            //if (!appDbContext.Users.Any() && !appDbContext.Posts.Any())
            //{
            //    var newUser = new User()
            //    {
            //        FullName = "Rahul Khatri",
            //        ProfilePictureUrl = "https://i.postimg.cc/VLhv3468/me-jpg.jpg"
            //    };
            //    await appDbContext.Users.AddAsync(newUser);
            //    await appDbContext.SaveChangesAsync();

            //    var newPostWithoutImage = new Post()
            //    {
            //        Content = "This is going to be our first post which is being loaded from the database and it has been created using our test user.",
            //        ImageUrl = "",
            //        NrOfReports = 0,
            //        DateCreated = DateTime.UtcNow,
            //        DateUpdated = DateTime.UtcNow,

            //        UserId = newUser.Id
            //    };

            //    var newPostWithImage = new Post()
            //    {
            //        Content = "This is going to be our first post which is being loaded from the database and it has been created using our test user. This post has an image",
            //        ImageUrl = "https://unsplash.com/photos/foggy-mountain-summit-1Z2niiBPg5A",
            //        NrOfReports = 0,
            //        DateCreated = DateTime.UtcNow,
            //        DateUpdated = DateTime.UtcNow,

            //        UserId = newUser.Id
            //    };

            //    await appDbContext.Posts.AddRangeAsync(newPostWithoutImage, newPostWithImage);
            //    await appDbContext.SaveChangesAsync();
            //}
        }
    }
}

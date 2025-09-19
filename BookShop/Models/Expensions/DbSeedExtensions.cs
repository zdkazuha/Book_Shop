using Book_Shop.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Book_Shop.Data.Entities;
using System.Reflection;

namespace Book_Shop.Extensions
{
    public static class Roles
    {
        public const string ADMIN = "admin";
        public const string USER = "user";
    }

    public static class DbSeedExtensions
    {
        public static async Task SeedRolesAsync(this IServiceProvider app)
        {
            var roleManager = app.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync(Roles.ADMIN))
                await roleManager.CreateAsync(new IdentityRole(Roles.ADMIN));

            if (!await roleManager.RoleExistsAsync(Roles.USER))
                await roleManager.CreateAsync(new IdentityRole(Roles.USER));

        }

        public static async Task SeedAdminAsync(this IServiceProvider app)
        {
            var userManager = app.GetRequiredService<UserManager<User>>();

            const string USERNAME = "admin@ukr.net";
            //const string USERNAME = "Admin@ukr.net";
            const string PASSWORD = "Qwer-1234";
            //const string PASSWORD = "AdminPassword";

            var existingUser = await userManager.FindByNameAsync(USERNAME);

            if (existingUser == null)
            {
                var user = new User
                {
                    UserName = USERNAME,
                    Email = USERNAME,
                };

                var result = await userManager.CreateAsync(user, PASSWORD);

                if (result.Succeeded)
                    await userManager.AddToRoleAsync(user, Roles.ADMIN);
            }
        }
    }
}
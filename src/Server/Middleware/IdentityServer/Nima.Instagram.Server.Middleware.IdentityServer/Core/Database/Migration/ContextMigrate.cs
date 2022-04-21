using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nima.Instagram.Server.Middleware.IdentityServer.Core.Database.User;

namespace Nima.Instagram.Server.Middleware.IdentityServer.Core.Database.Migration
{
    public class ContextMigrate
    {
        private readonly IServiceProvider serviceProvider;
        private readonly InstagramIdentityDBContext context;
        public ContextMigrate(IServiceProvider _serviceProvider)
        {
            serviceProvider = _serviceProvider;
            context = serviceProvider.GetRequiredService<InstagramIdentityDBContext>();
        }

        public async Task Migrate()
        {
            await context.Database.MigrateAsync();
            await context.Database.EnsureCreatedAsync();
        }

        public async Task SeedData()
        {
            await Migrate();
            using (var scope = serviceProvider.CreateScope())
            {
                var provider = scope.ServiceProvider;
                var RoleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
                var UserManager = provider.GetRequiredService<UserManager<InstagramIdentityUser>>();
                string[] roleNames = { "Adminstrator", "User", "Guest" };
                IdentityResult roleResult;

                foreach (var roleName in roleNames)
                {
                    var roleExist = await RoleManager.RoleExistsAsync(roleName);
                    if (!roleExist)
                    {
                        roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }

                var poweruser = new InstagramIdentityUser
                {
                    UserName = "realQu1ck",
                    Email = "nima13727@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    PhoneNumber = "09352877011",
                };

                string userPWD = "@+Nima4332";
                var _user = await UserManager.FindByEmailAsync("nima13727@gmail.com");

                if (_user == null)
                {
                    var createPowerUser = await UserManager.CreateAsync(poweruser, userPWD);
                    if (createPowerUser.Succeeded)
                    {
                        await UserManager.AddToRoleAsync(poweruser, "Adminstrator");
                    }
                }
            }
        }
    }
}

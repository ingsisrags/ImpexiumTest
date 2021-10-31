using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Models.Identity;

namespace Infrastructure.IdentityContext
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var adminUser = new ApplicationUser {UserName = "administrator", Email = "adminitrator@impexium.com"};

                await userManager.CreateAsync(adminUser, "password");

                var adminClaim = new Claim("Role", "Admin");

                await userManager.AddClaimAsync(adminUser, adminClaim);
            }
        }
    }
}
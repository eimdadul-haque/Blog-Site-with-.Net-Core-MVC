using BlogSite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace BlogSite.Helper
{
    public class CustomClaimes : UserClaimsPrincipalFactory<UserModel , IdentityRole>
    {
        public CustomClaimes(UserManager<UserModel> userManager, RoleManager<IdentityRole> roleManager,IOptions<IdentityOptions> options):base(userManager, roleManager, options)    
        {

        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(UserModel user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("FirstName", user.firstName));
            identity.AddClaim(new Claim("FirstName", user.firstName));
            return identity;
        }
    }
}

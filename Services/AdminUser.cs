
using BlogSite.Models;
using Microsoft.AspNetCore.Identity;
namespace BlogSite.Services
{
    class AdminUser
    {

        public async Task createAdmin(UserManager<UserModel> _userManager, RoleManager<IdentityRole> _roleManager)
        {

            var isRoleExist = await _roleManager.RoleExistsAsync("Admin");
            var isUserExist = await _userManager.FindByEmailAsync("admin@gmail.com");

            if (isUserExist == null || !isRoleExist)
            {
                if (!isRoleExist)
                {
                    var role = new IdentityRole(){
                        Name = "Admin"
                    };
                    await _roleManager.CreateAsync(role);
                }

                if (isUserExist == null)
                {
                    var user = new UserModel()
                    {
                        UserName = "admin@gmail.com",
                        Email = "admin@gmail.com",
                        firstName = "Admin",
                        lastName ="Admin"
                    };

                   var result = await _userManager.CreateAsync(user, "1234");
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }
                }
            }
        }
    }
}
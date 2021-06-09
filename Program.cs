using Blog_Site_Core.Controllers;
using Blog_Site_Core.Data;
using Blog_Site_Core.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace Blog_Site_Core
{
    public class Program
    {
        

        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            createAdmin(host);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


        public static void createAdmin(IHost host)
        {
            try
            {
                var scope = host.Services.CreateScope();
                var ctx = scope.ServiceProvider.GetRequiredService<appDbContext>();
                var userMng = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var roleMng = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                ctx.Database.EnsureCreated();
                var adminRole = new IdentityRole("Admin");

                if (!ctx.Roles.Any())
                {
                    roleMng.CreateAsync(adminRole).GetAwaiter().GetResult();
                }

                if (!ctx.Users.Any(u => u.UserName == "admin"))
                {
                     var adminUser = new IdentityUser
                    {

                        UserName = "admin",
                        Email = "admin@test.com"

                    };

                    var result = userMng.CreateAsync(adminUser, "password").GetAwaiter().GetResult();
                    userMng.AddToRoleAsync(adminUser, adminRole.Name).GetAwaiter().GetResult();

                    //var user = new AuthController();
                    //user.appUser(adminUser.Id);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

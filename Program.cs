using Blog_Site_Core.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_Site_Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            try {
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
                
                if (!ctx.Users.Any(u =>u.UserName == "admin "))
                {
                    var adminUser = new IdentityUser { 
                    
                        UserName = "admin",
                        Email = "admin@test.com"

                    };

                    userMng.CreateAsync(adminUser,"password").GetAwaiter().GetResult();
                    userMng.AddToRoleAsync(adminUser, adminRole.Name).GetAwaiter().GetResult();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

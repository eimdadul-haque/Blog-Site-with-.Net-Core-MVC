using Microsoft.EntityFrameworkCore;
using BlogSite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BlogSite.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserModel>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<BlogModel> blogModelD { get; set; }
        public DbSet<CommentModel> commentD { get; set; }
    }
}
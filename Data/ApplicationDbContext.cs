using Microsoft.EntityFrameworkCore;
using BlogSite.Models;
namespace BlogSite.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<BlogModel> blogModelD { get; set; }
    }
}
using Blog_Site_Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Site_Core.Data
{
    public class appDbContext : IdentityDbContext
    {
        public appDbContext(DbContextOptions<appDbContext> options) : base(options)
        {

        }
        public DbSet<postModel> postModelD { get; set; }
        public DbSet<categoryModel> categoryModelD { get; set; }
    }
}



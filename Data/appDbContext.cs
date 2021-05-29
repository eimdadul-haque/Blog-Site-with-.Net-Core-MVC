using Blog_Site_Core.Models;
using Blog_Site_Core.Models.Comments;
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
        public DbSet<MainComment>  mainCommentD { get; set; }
        public DbSet<SubComment> subCommentD { get; set; }
        public DbSet<AppUserModel> appUserD { get; set; }
    }
}


//
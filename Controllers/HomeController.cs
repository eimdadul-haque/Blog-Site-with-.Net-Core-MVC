using BlogSite.Data;
using BlogSite.Models;
using BlogSite.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BlogSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<UserModel> _userManager;
        private readonly RoleManager<IdentityRole>  _roleManager;

        public HomeController(ApplicationDbContext db, UserManager<UserModel> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = new AdminUser();
            await user.createAdmin(_userManager, _roleManager);
            return View(await _db.blogModelD.ToListAsync());
        }

    }
}
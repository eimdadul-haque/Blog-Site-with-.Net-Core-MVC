using Blog_Site_Core.Data;
using Blog_Site_Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Site_Core.Controllers
{
  
    public class HomeController : Controller
    {
        private readonly appDbContext _db;
        public HomeController(appDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.postModelD.ToList());
        }

        public IActionResult post(int id)
        {
            var post = _db.postModelD.Find(id);
            return View(post);
        }



    }
}

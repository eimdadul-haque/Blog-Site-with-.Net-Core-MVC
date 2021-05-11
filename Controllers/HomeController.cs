using Blog_Site_Core.Data;
using Blog_Site_Core.Models;
using Blog_Site_Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Index(int pageNumber)
        {
            if(pageNumber < 1)
            {
                return RedirectToAction("Index", new { pageNumber = 1 });
            }

            int pageSize = 6;
            var viewModel = new PageNumModel
            {
                pageNum = pageNumber,
                post = _db.postModelD.Include(c => c.categoryModel)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToList()
            };

           
            return View(viewModel);
        }

        public IActionResult post(int id)
        {
            var post = _db.postModelD.Find(id);
            return View(post);
        }



    }
}

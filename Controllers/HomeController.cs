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

        public IActionResult Index(double pageNumber)
        {
            if(pageNumber < 1)
            {
                return RedirectToAction("Index", new { pageNumber = 1 });
            }

            double pageSize = 6;
            double totalPost = _db.postModelD.Count();
            double tempMaxPage = totalPost / pageSize;
            var maxPage = Math.Round(tempMaxPage, 0, MidpointRounding.ToEven);

            if (maxPage % 2 != 0)
            {
                maxPage = maxPage + 1;
            }

            if (pageNumber > maxPage)
            {
                pageNumber = maxPage;
            }

            var viewModel = new PageNumModel
            {
                pageNum = pageNumber,
                post = _db.postModelD.Include(c => c.categoryModel)
                .Skip((int)(pageSize * (pageNumber - 1)))
                .Take((int)pageSize)
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

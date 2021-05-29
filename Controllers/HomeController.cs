using Blog_Site_Core.Data;
using Blog_Site_Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Blog_Site_Core.Controllers
{
  
    public class HomeController : Controller
    {
        private readonly appDbContext _db;
        public HomeController(appDbContext db)
        {
            _db = db;
        }

        //Get all post
        public IActionResult Index(double pageNumber)
        {
            if(pageNumber < 1)
            {
                return RedirectToAction("Index", new { pageNumber = 1 });
            }

            double pageSize = 6;
            double totalPost = _db.postModelD.Count();
            double tempMaxPage = (double)(totalPost / pageSize);
            double maxPage = Math.Floor(tempMaxPage);

            if ((tempMaxPage % 1) > 0 || maxPage == 0)
            {
               maxPage = maxPage + 1;
            }

            if (pageNumber > maxPage)
            {
                pageNumber = maxPage;
            }

 
                var viewModel = new PageNumModel
                {
                    maxPage = maxPage,
                    pageNum = pageNumber,
                    post = _db.postModelD.Include(c => c.categoryModel) 
                 .Skip((int)(pageSize * (pageNumber - 1)))
                 .Take((int)pageSize)
                 .ToList()
                };

                return View(viewModel);

        }

        //Get Single post
        public IActionResult post(int id) 
        {
            var post = _db.postModelD
                .Include(c => c.AppUserModel)
                .Include(c => c.CommentId)
                .ThenInclude(c => c.subCommentId)
                .FirstOrDefault(c => c.Id == id);


            return View(post);
        }

        //Comment 
        public IActionResult Comment()
        {
            return View();
        }

    }
}

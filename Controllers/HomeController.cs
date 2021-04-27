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
        private readonly IRepositoty _repo;
        public HomeController(IRepositoty repo)
        {
            _repo = repo;
        }

       public IActionResult Index()
        {
            return View();
        }

        public IActionResult post()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit()
        {   
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>  Edit(postModel postModel)
        {
            _repo.AddPost(postModel);
            if (await _repo.SaveChangesAsync())
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(postModel);
            }
        }
    }
}

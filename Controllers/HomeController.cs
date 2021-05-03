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
            var postList = _repo.GetAllPost();
            return View(postList);
        }

        public IActionResult post(int id)
        {
            return View(_repo.GetPost(id));
        }



    }
}

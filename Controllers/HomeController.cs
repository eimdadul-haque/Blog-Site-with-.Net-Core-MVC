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
        public IActionResult Edit(postModel postModel)
        {
            return View();
        }
    }
}

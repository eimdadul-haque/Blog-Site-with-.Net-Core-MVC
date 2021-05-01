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
            var post = _repo.GetPost(id);
            return View(post);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View();
            }
            else
            {
                var post = _repo.GetPost((int)id);
                return View(post);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(postModel postModel)
        {
            if (postModel.Id > 0)
            {
                _repo.UpdatePost(postModel);
            }
            else
            {
                _repo.AddPost(postModel);

            }

            if (await _repo.SaveChangesAsync())
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(postModel);
            }
        }

        public async Task<IActionResult> Remove(int id)
        {
            _repo.RemovePost(id);
            await _repo.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

    }
}

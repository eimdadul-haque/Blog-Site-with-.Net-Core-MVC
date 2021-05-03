using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog_Site_Core.Data;
using Blog_Site_Core.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Blog_Site_Core.Controllers
{

    [Authorize(Roles ="Admin")]
    public class PanelController : Controller
    {
        private readonly IRepositoty _repo;
        private readonly IWebHostEnvironment _iweb;

        public PanelController(IRepositoty repo, IWebHostEnvironment iweb)
        {
            _repo = repo;
            _iweb = iweb;
        }

        public IActionResult Index()
        {
            var postList = _repo.GetAllPost();
            return View(postList);
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
         

            if (postModel.Image != null)
            {
                string wwwRootPath = _iweb.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(postModel.Image.FileName);
                string extension = Path.GetExtension(postModel.Image.FileName);
                postModel.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                string path = Path.Combine(wwwRootPath + "/image/",fileName);

                using (var fileStrem = new FileStream(path, FileMode.Create))
                {
                    await postModel.Image.CopyToAsync(fileStrem);
                }
            }
            else
            {
                postModel.ImageName = "default.jpg";

            }

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

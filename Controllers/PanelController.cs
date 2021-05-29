using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Blog_Site_Core.Data;
using Blog_Site_Core.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Blog_Site_Core.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Blog_Site_Core.Controllers
{

    [Authorize(Roles ="Admin")]
    public class PanelController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly appDbContext _db;
        private readonly IWebHostEnvironment _iweb;

        public PanelController(appDbContext db, IWebHostEnvironment iweb, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _iweb = iweb;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
           
            return View(_db.postModelD.ToList());
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {

            ViewData["CategoryId"] = new SelectList(_db.categoryModelD.ToList(), "Id", "category");
            if (id == null)
            {
               return View();
            }
            else
            {
               var post = _db.postModelD.Include(c => c.categoryModel).FirstOrDefault(c => c.Id == id);
                return View(post);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(postModel postModel)
        {
              var UserId = _userManager.GetUserId(HttpContext.User);
           //  var User = await _userManager.FindByIdAsync(UserId);

            if (ModelState.IsValid)
            {
                
            }

            if (postModel.Id > 0)
            {

                string preImage = postModel.ImageName;
                postModel.ImageName = await imageMange(postModel);
                _db.postModelD.Update(postModel);
                await _db.SaveChangesAsync();

                
                var imagePath = Path.Combine(_iweb.WebRootPath, "image", preImage);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {

                postModel.AppUserModelId = UserId;
                var imageName = await imageMange(postModel);
                postModel.ImageName = imageName;
                _db.postModelD.Add(postModel);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


        }

        public async Task<IActionResult> Remove(int id)
        {
            var imageModel = _db.postModelD.Find(id);
            var imagePath = Path.Combine(_iweb.WebRootPath, "image", imageModel.ImageName);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            _db.postModelD.Remove(imageModel);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<string> imageMange(postModel postModel)
        {
            if (postModel.Image != null)
            {
                string wwwRootPath = _iweb.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(postModel.Image.FileName);
                string extension = Path.GetExtension(postModel.Image.FileName);
                postModel.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                string path = Path.Combine(wwwRootPath + "/image/", fileName);

                using (var fileStrem = new FileStream(path, FileMode.Create))
                {
                    await postModel.Image.CopyToAsync(fileStrem);
                }
            }
            else
            {
                postModel.ImageName = "/default/default.jpg";

            }

            return postModel.ImageName;
        }

        public IActionResult dashboard()
        {
            var count = _db.postModelD.Count();
            ViewBag.Count = count;

            var dashbord = new dashboard
            {
                postCount = count

            };
            
            return View(dashbord);
        }

    }
}

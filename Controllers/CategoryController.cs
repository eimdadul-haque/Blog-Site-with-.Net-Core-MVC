using Blog_Site_Core.Data;
using Blog_Site_Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_Site_Core.Controllers
{
    public class CategoryController : Controller
    {

        private readonly appDbContext _db;

        public CategoryController(appDbContext db)
        {
            _db = db;
        }

        // GET: CategoryController
        public ActionResult Index()
        {
            return View(_db.categoryModelD.ToList());
        }

        // GET: CategoryController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(categoryModel category)
        {
            if (ModelState.IsValid)
            {
                _db.categoryModelD.Add(category);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            return View(category);
        }

    }
}

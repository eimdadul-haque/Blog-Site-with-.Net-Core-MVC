using BlogSite.Data;
using BlogSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogSite.Services;

public class BlogController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _env;
    public BlogController(ApplicationDbContext context, IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBlog()
    {
        return View(await _context.blogModelD.ToListAsync());
    }

    [HttpGet]
    public async Task<IActionResult> GetBlog(int id)
    {
        return View(await _context.blogModelD.Include(x=>x.comment).FirstOrDefaultAsync(x=>x.Id == id));
    }

    [HttpGet]
    public async Task<IActionResult> Post_Edit_Blog(int? id)
    {
        if (id > 0)
        {
            return View(await _context.blogModelD.FindAsync(id));
        }
        else
        {
            return View();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post_Edit_Blog(BlogModel blog)
    {
        if (ModelState.IsValid)
        {
            if (blog.blogBody.Length < 200)
            {
                return View(blog);
            }

            if (blog.Id > 0)
            {
                blog.userName = User.Identity.Name;
                ImageUploader obj = new ImageUploader();
                blog.imageName = await obj.imageUpload(blog, _env);
                _context.blogModelD.Update(blog);
                await _context.SaveChangesAsync();
                return RedirectToAction("GetBlog", new { id = blog.Id });
            }
            else
            {
                blog.userName = User.Identity.Name;
                ImageUploader obj = new ImageUploader();
                blog.imageName = await obj.imageUpload(blog, _env);
                await _context.blogModelD.AddAsync(blog);
                await _context.SaveChangesAsync();
                _context.Entry(blog).GetDatabaseValues();
                return RedirectToAction("GetBlog", new { id = blog.Id });
            }
        }
        return RedirectToAction(nameof(GetAllBlog));
    }

    [HttpGet]
    public async Task<IActionResult> BlogDelete(int id)
    {
        var item = await _context.blogModelD.FindAsync(id);
        if (item != null)
        {
            if (User.Identity.Name == item.userName)
            {
                _context.blogModelD.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
        return RedirectToAction(nameof(GetAllBlog));
    }

    [HttpPost]
    public async Task<IActionResult> Search(string query)
    {
        if (query == null)
        {
            var items = _context.blogModelD.Where(x => x.blogTitlt.Contains(query) || x.blogBody.Contains(query));
            if (items.Any())
            {
                return View(items);
            }
            else
            {
                return View("Views/Shared/Notfount.cshtml");
            }
        }

        return View("Views/Shared/Notfount.cshtml");
    }

    [HttpGet]
    public async Task<IActionResult> MyBlog()
    {
        return View(await _context.blogModelD.Where(x => x.userName == User.Identity.Name).ToListAsync());
    }


}
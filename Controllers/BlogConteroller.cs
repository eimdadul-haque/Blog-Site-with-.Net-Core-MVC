using BlogSite.Data;
using BlogSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class BlogController : Controller
{
    private readonly ApplicationDbContext _context;
    public BlogController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBlog()
    {
        return View(await _context.blogModelD.ToListAsync());
    }

    [HttpGet]
    public async Task<IActionResult> GetBlog(int id)
    {
        return View(await _context.blogModelD.FindAsync(id));
    }

    [HttpGet]
    public async Task<IActionResult> AddBlog()
    {
        return View();
    }

    [HttpPost]
    [ActionName("AddBlog")]
    public async Task<IActionResult> PostBlog(BlogModel blog)
    {
        if (ModelState.IsValid)
        {
            await _context.blogModelD.AddAsync(blog);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(GetAllBlog));
    }

    [HttpGet]
    public async Task<IActionResult> BlogDelete(int id)
    {
        var item = await _context.blogModelD.FindAsync(id);
        if (item != null)
        {
            _context.blogModelD.Remove(item);
           await _context.SaveChangesAsync();
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

}
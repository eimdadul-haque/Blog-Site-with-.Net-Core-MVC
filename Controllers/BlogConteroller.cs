using Microsoft.AspNetCore.Mvc;
public class BlogController : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAllBlog()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetBlog(int id)
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> AddBlog()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Search(string query)
    {
        if (query == null)
        {
            return View("Views/Shared/Notfount.cshtml");
        }

        return View();
    }

}
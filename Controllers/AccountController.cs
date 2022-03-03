using Microsoft.AspNetCore.Mvc;
public class AccountController : Controller
{
    [HttpGet]
    public async Task<IActionResult> Login()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Registration()
    {
        return View();
    }
}
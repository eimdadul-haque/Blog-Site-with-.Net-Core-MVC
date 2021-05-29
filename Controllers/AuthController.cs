using System.Security.Principal;
using Blog_Site_Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog_Site_Core.Data;
using Blog_Site_Core.Models;

namespace Blog_Site_Core.Controllers
{
    public class AuthController : Controller
    {
        private readonly appDbContext _db;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, appDbContext db)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _db = db;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, false, false);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(loginModel.UserName);
                    var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

                    if (isAdmin)
                    {
                        return RedirectToAction("Index", "Panel");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

            }

            return View(loginModel);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View(new SignUpModel());
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpModel signUpModel)
        {

            if (ModelState.IsValid)
            {
                var user = new IdentityUser{
                    UserName = signUpModel.Email,
                    Email = signUpModel.Email,
                     
                };

                var result = await _userManager.CreateAsync(user, "Password");

                if(result.Succeeded){
                    
                    var userModel = new AppUserModel
                    {
                        UserId = user.Id,
                        FirstName = signUpModel.FirstName,
                        LastName = signUpModel.LasttName
                    };

                    _db.appUserD.Add(userModel);
                    await _db.SaveChangesAsync();

                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(signUpModel);
        }



    }
}

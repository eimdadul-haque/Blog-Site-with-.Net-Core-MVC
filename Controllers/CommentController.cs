using BlogSite.Data;
using BlogSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BlogSite.Controllers
{
    public class CommentController : Controller
    {
        private ApplicationDbContext _db;
        private UserManager<UserModel> _user;
        public CommentController(ApplicationDbContext db, UserManager<UserModel> user)
        {
            _db = db;
            _user = user;
        }

        [HttpPost]
        public async Task<IActionResult> addComment(CommentModel cmt)
        {
            if (await _user.FindByNameAsync(cmt.userName) != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    if (ModelState.IsValid)
                    {
                        if (cmt != null)
                        {
                            await _db.commentD.AddAsync(cmt);
                            await _db.SaveChangesAsync();
                            return PartialView("_Comment", await _db.commentD.Where(x => x.blogModelId == cmt.blogModelId).ToListAsync());

                        }
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
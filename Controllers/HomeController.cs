using Blog_Site_Core.Data;
using Blog_Site_Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_Site_Core.Controllers
{
  
    public class HomeController : Controller
    {
        private readonly appDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(appDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;

        }
            

        //Get all post
        public IActionResult Index(double pageNumber)
        {
            if(pageNumber < 1)
            {
                return RedirectToAction("Index", new { pageNumber = 1 });
            }

            double pageSize = 6;
            double totalPost = _db.postModelD.Count();
            double tempMaxPage = (double)(totalPost / pageSize);
            double maxPage = Math.Floor(tempMaxPage);

            if ((tempMaxPage % 1) > 0 || maxPage == 0)
            {
               maxPage = maxPage + 1;
            }

            if (pageNumber > maxPage)
            {
                pageNumber = maxPage;
            }

 
                var viewModel = new PageNumModel
                {
                    maxPage = maxPage,
                    pageNum = pageNumber,
                    post = _db.postModelD.Include(c => c.categoryModel) 
                 .Skip((int)(pageSize * (pageNumber - 1)))
                 .Take((int)pageSize)
                 .ToList()
                };

                return View(viewModel);

        }

        //Get Single post
        public async Task<IActionResult> post(int id) 
        {

            var post = _db.postModelD.Include(c => c.AppUserModel).FirstOrDefault(c => c.Id == id);
            var MainComment = await _db.mainCommentD.Where(c => c.postId == post.Id).Include(c => c.AppUser).Include(c=>c.subComment).ToListAsync();

            post.Comment = MainComment;

            return View(post);
        }

        //Comment 
        [HttpGet]
        public async Task<IActionResult> Comment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Comment(CommentViewModel commentViewModel)
        {
            var userId = _userManager.GetUserId(HttpContext.User);



            commentViewModel.UserId = userId;

            if (commentViewModel.mainCommentId > 0)
            {

            }
            else
            {
                _db.mainCommentD.Add(new Models.Comments.MainComment
                {
                    Id = commentViewModel.mainCommentId,
                    commentMsg = commentViewModel.commentMsg,
                    AppUserId = userId,
                    postId = commentViewModel.postId

                }) ;

                await _db.SaveChangesAsync();
            }

            return RedirectToAction("post",new { id = commentViewModel.postId});
        }

    }
}

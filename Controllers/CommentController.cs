using BlogSite.Data;
using BlogSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Controllers
{
    public class CommentController : ControllerBase
    {
        private ApplicationDbContext _db;
        public CommentController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost("addComment")]
        public async Task<IActionResult> addComment(CommentModel cmt)
        {
            if (ModelState.IsValid)
            {
                if (cmt != null)
                {
                    await _db.commentD.AddAsync(cmt);
                    await _db.SaveChangesAsync();
                }
            }
            return Ok();
        }

        [HttpGet("getComment")]
        public async Task<IActionResult> getComment(int id)
        {
            return Ok(await _db.commentD.Where(x => x.blogModelId == id).ToListAsync());
        }
    }
}
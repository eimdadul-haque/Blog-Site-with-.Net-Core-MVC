using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Site_Core.ViewModels
{
    public class CommentViewModel
    {
        [Required]
        public int postId { get; set; }

        [Required]
        public int mainCommentId { get; set; }

        [Required]
        public string commentMsg { get; set; }
    }
}

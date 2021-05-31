using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_Site_Core.Models.Comments
{
    public class MainComment 
    {
        public int Id { get; set; }

        public int postId { get; set; }
        [ForeignKey("postId")]
        public postModel post { get; set; }

        public string commentMsg { get; set; }

        public string AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public AppUserModel AppUser { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public int subCommentId { get; set; }
        [ForeignKey("subCommentId")]
        public List<SubComment> subComment { get; set; }
    }
}

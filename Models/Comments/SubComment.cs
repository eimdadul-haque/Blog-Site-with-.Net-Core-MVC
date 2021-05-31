using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Site_Core.Models.Comments
{
    public class SubComment 
    {
        public int Id { get; set; }

        public string commentMsg { get; set; }

        public string AppUserId { get; set; }
        [ForeignKey("AppUserId")]
        public AppUserModel AppUser { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public int mainCommentId { get; set; }
        [ForeignKey("mainCommentId")]
        public MainComment mainComment { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Site_Core.Models.Comments
{
    public class SubComment : Comment
    {
        [Required]
        public string UsreId { get; set; }

        public MainComment mainCommentId { get; set; }
    }
}

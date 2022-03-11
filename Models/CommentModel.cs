using System.ComponentModel.DataAnnotations;

namespace BlogSite.Models
{
    public class CommentModel
    {
        public int Id { get; set; }

        [Required]
        public string? cmtBody { get; set; }

        public string userName { get; set; }

        public int blogModelId { get; set; }
        
        public BlogModel? blogModel { get; set; }
    }
}
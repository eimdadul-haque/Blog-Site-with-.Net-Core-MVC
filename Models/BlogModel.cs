using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogSite.Models
{
    public class BlogModel
    {
        public int Id { get; set; }

        [Required]
        public string blogTitlt { get; set; }

        public string? userName { get; set; }

        [Required]
        public string blogBody { get; set; }

        public DateTime created { get; set; } = DateTime.Now;

        public string imageName { get; set; } = "";

        public List<CommentModel>? comment { get; set; }

        [NotMapped]
        public IFormFile? imageFile { get; set; }
    }
}

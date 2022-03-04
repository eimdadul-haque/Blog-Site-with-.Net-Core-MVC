using System.ComponentModel.DataAnnotations;

namespace BlogSite.Models
{
    public class BlogModel
    {
        public int Id { get; set; }
        [Required]
        public string blogTitlt { get; set; }
        [Required]
        public string blogBody { get; set; }
        public DateTime created { get; set; } = DateTime.Now;
        public string imageName { get; set; }
    }
}

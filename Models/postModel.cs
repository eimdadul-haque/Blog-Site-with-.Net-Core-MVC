using System;

namespace Blog_Site_Core.Models
{
    public class postModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Creacted { get; set; } = DateTime.Now;
    }
}

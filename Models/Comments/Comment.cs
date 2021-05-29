using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Site_Core.Models.Comments
{
    public class Comment
    {
        public int Id { get; set; }
        public string commentMsg { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}

using Blog_Site_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Site_Core.ViewModels
{
    public class PageNumModel
    {
        public int pageNum { get; set; }
        public List<postModel> post { get; set; }
    }
}

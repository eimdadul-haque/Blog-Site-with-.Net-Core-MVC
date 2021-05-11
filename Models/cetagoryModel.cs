using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Site_Core.Models
{
    public class categoryModel
    {
        public int Id { get; set; }
        [Required]
        public string category { get; set; }
    }
}

using Blog_Site_Core.Models.Comments;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_Site_Core.Models
{
    public class postModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        public string ImageName { get; set; }

        public DateTime Creacted { get; set; } = DateTime.Now;

        public string Tags { get; set; }

        [Required]
        public string AppUserModelId { get; set; }
        [ForeignKey("AppUserModelId")]
        public AppUserModel AppUserModel { get; set; }

        [Required]
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public categoryModel categoryModel { get; set; }

        public List<MainComment> Comment { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile Image { get; set; }
    }
}

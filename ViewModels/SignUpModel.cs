using System.ComponentModel.DataAnnotations;

namespace BlogSite.ViewModels
{
    public class SignUpModel
    {
        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        public string userName { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        [Compare("password")]
        public string confirmPassword { get; set; }


    }
}

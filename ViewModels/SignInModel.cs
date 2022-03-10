using System.ComponentModel.DataAnnotations;

namespace BlogSite.ViewModels
{
    public class SignInModel
    {
        [Required]
        public string userName { get; set; }

        [Required]
        public string password { get; set; }
    }
}

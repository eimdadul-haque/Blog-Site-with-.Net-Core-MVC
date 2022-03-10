using Microsoft.AspNetCore.Identity;

namespace BlogSite.Models
{
    public class UserModel : IdentityUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}

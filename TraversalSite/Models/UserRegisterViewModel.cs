using System.ComponentModel.DataAnnotations;

namespace TraversalSite.Models
{
    public class UserRegisterViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace DtoLayer.Dtos.AppUserDto
{
    public class UserRegisterViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
    }
}

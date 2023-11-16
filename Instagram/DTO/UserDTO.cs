using System.ComponentModel.DataAnnotations;

namespace Instagram.DTO
{
    public class UserDTO
    {
        [Required(ErrorMessage = "UserName es obligatorio")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password es obligatorio")]
        public string Password { get; set; }
        [Required(ErrorMessage = "NickName es obligatorio")]
        public string NickName { get; set; }
    }
}

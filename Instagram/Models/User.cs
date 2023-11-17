using Microsoft.Extensions.Hosting;

namespace Instagram.Models
{
    public class User
    {
        public User() { }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
        public string Role { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}

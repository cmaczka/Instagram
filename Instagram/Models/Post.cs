using System.Xml.Linq;

namespace Instagram.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
    }
}

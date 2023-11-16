using System.Xml.Linq;

namespace Instagram.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
    }
}

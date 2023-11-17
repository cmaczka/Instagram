using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [ForeignKey("IdPost")]
        public int IdUser { get; set; }

        [ForeignKey("PostId")]
        public int PostId { get; set; }
        public string? Comments { get; set; }
    }
}

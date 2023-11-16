using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [ForeignKey("IdPost")]
        public int IdUser { get; set; }

        [ForeignKey("IdPost")]
        public int IdPost { get; set; }
        public string? Comments { get; set; }
    }
}

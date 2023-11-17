namespace Instagram.Models
{
    public class Like
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int PostId { get; set; }
        public bool? IsLike { get; set; }
    }
}

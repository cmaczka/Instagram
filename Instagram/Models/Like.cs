namespace Instagram.Models
{
    public class Like
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdPost { get; set; }
        public bool? IsLike { get; set; }

        public virtual Post IdPostNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
    }
}

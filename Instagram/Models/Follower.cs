namespace Instagram.Models
{
    public class UserFollowed
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdFollowed { get; set; }
        public bool IdActive { get; set; }
    }
}

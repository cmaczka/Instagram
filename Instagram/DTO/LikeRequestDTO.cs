namespace Instagram.DTO
{
    public class LikeRequestDTO
    {
        public int IdUser { get; set; }
        public int IdPost { get; set; }
        public bool? IsLike { get; set; }
    }
}

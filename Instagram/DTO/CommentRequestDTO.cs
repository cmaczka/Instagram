namespace Instagram.DTO
{
    public class CommentRequestDTO
    {
        public int IdUser { get; set; }
        public string Comments { get; set; }
        public int PostId { get; set; }
    }
}

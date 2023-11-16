using System.Net;

namespace Instagram.DTO
{
    public class ResponseDTO<T>
    {
        public bool IsSuccessfull { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public T Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}

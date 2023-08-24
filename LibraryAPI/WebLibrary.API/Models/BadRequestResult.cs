namespace WebLibrary.API.Models
{
    public class BadRequestResult
    {
        public int StatusCode { get; set; }
        public string Title { get; set; } = null!;
        public object Exceptions { get; set; } = null!;
    }
}

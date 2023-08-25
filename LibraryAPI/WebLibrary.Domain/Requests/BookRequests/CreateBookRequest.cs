namespace WebLibrary.Domain.Requests.BookRequests;

public class CreateBookRequest
{
    public string Isbn { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Author { get; set; } = null!;

    public DateTime? BorrowedTime { get; set; }

    public DateTime? ReturnDueTime { get; set; }
}
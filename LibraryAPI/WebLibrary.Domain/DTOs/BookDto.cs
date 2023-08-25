namespace WebLibrary.Domain.DTOs;

public class BookDto
{
    public Guid Id { get; set; }

    public string Isbn { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Author { get; set; } = null!;

    public DateTime? BorrowedTime { get; set; }

    public DateTime? ReturnDueTime { get; set; }
}
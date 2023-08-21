using System.ComponentModel.DataAnnotations.Schema;

namespace WebLibrary.Domain.Entities;

[Table(nameof(Book))]
public class Book : Entity
{
    public string Isbn { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Author { get; set; } = null!;

    public DateTime? BorrowedTime { get; set; }

    public DateTime? ReturnDueTime { get; set; }
}
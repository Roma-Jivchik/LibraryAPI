using System.ComponentModel.DataAnnotations.Schema;

namespace WebLibrary.Domain.Entities;

[Table(nameof(User))]
public class User : Entity
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;
}
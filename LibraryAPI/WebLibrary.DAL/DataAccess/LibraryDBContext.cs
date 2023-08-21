using Microsoft.EntityFrameworkCore;
using WebLibrary.Domain.Entities;

namespace WebLibrary.DAL.DataAccess;

internal class LibraryDBContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    public DbSet<Book> Books { get; set; } = null!;

    public LibraryDBContext(DbContextOptions<LibraryDBContext> options)
        : base(options)
    {
    }
}

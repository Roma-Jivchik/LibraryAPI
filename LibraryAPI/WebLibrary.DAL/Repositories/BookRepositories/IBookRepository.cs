using WebLibrary.Domain.Entities;

namespace WebLibrary.DAL.Repositories.BookRepositories
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task<Book?> GetBookByIsbn(string isbn);
    }
}

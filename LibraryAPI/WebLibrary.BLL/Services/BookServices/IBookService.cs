using WebLibrary.Domain.DTOs;
using WebLibrary.Domain.Requests.Book;
using WebLibrary.Domain.Requests.BookRequests;

namespace WebLibrary.BLL.Services.BookServices
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllAsync();

        Task<BookDto?> GetBookAsync(Guid id);

        Task<BookDto?> GetBookByIsbn(string isbn);
        Task<BookDto?> CreateAsync(CreateBookRequest createBookRequest);
        Task<bool> UpdateAsync(UpdateBookRequest updateBookRequest);
        Task<bool> DeleteAsync(Guid id);
    }
}

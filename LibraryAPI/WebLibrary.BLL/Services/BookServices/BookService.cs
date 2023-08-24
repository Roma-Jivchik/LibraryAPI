using Mapster;
using WebLibrary.Domain.DTOs;
using WebLibrary.BLL.Exceptions;
using WebLibrary.Domain.Entities;
using WebLibrary.Domain.Requests.Book;
using WebLibrary.Domain.Requests.BookRequests;
using WebLibrary.DAL.Repositories.BookRepositories;
using WebLibrary.BLL.Resources;

namespace WebLibrary.BLL.Services.BookServices
{
    internal class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        

        public async Task<BookDto?> CreateAsync(CreateBookRequest createBookRequest)
        {
            var existingBook = await _bookRepository.GetBookByIsbnAsync(createBookRequest.Isbn);

            if(existingBook is not null)
            {
                throw new ValidationExceptionResult(CreateBookRequestExceptionMessages.BookWithThisIsbnAlreadyExists);
            }

            var bookEntity = createBookRequest.Adapt<Book>();

            var createdBookEntity = await _bookRepository.AddAsync(bookEntity);

            return createdBookEntity.Adapt<BookDto>();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            return _bookRepository.DeleteAsync(new Book { Id = id });
        }

        public async Task<List<BookDto>> GetAllAsync()
        {
            var bookEntities = await _bookRepository.GetAsync();

            var mappedBooks = bookEntities.Adapt<List<BookDto>>();

            return mappedBooks;
        }

        public async Task<BookDto?> GetBookAsync(Guid id)
        {
            var bookEntity = await _bookRepository.GetByIdAsync(id);

            var mappedBook = bookEntity?.Adapt<BookDto>();

            return mappedBook;
        }

        public async Task<BookDto?> GetBookByIsbn(string isbn)
        {
            var bookEntity = await _bookRepository.GetBookByIsbnAsync(isbn);

            var mappedBook = bookEntity?.Adapt<BookDto>();

            return mappedBook;
        }

        public async Task<bool> UpdateAsync(UpdateBookRequest updateBookRequest)
        {
            var bookEntity = await _bookRepository.GetByIdAsync(updateBookRequest.Id);

            if(bookEntity is null)
            {
                return false;
            }

            updateBookRequest.Adapt(bookEntity);

            await _bookRepository.UpdateAsync(bookEntity);

            return true;
        }
    }
}

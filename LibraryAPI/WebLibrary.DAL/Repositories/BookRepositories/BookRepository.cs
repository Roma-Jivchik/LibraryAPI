using Microsoft.EntityFrameworkCore;
using WebLibrary.DAL.DataAccess;
using WebLibrary.Domain.Entities;

namespace WebLibrary.DAL.Repositories.BookRepositories
{
    internal class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(LibraryDBContext libraryDBContext) : base(libraryDBContext) 
        {

        }

        public Task<Book?> GetBookByIsbn(string isbn)
        {
            return DbSet.AsNoTracking().FirstOrDefaultAsync(_ => _.Isbn == isbn);
        }
    }
}

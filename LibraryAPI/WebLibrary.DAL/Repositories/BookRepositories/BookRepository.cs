using WebLibrary.DAL.DataAccess;
using WebLibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebLibrary.DAL.Repositories.BookRepositories
{
    internal class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(LibraryDBContext libraryDBContext) : base(libraryDBContext) 
        {

        }

        public Task<Book?> GetBookByIsbnAsync(string isbn)
        {
            return DbSet.AsNoTracking().FirstOrDefaultAsync(_ => _.Isbn == isbn);
        }
    }
}

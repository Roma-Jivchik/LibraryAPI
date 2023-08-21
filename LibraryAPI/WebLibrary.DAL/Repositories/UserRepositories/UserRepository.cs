using Microsoft.EntityFrameworkCore;
using WebLibrary.DAL.DataAccess;
using WebLibrary.Domain.Entities;

namespace WebLibrary.DAL.Repositories.UserRepositories
{
    internal class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(LibraryDBContext libraryDBContext) : base(libraryDBContext)
        {
            
        }

        public Task<User?> GetUserByLoginAsync(string login)
        {
            return DbSet.AsNoTracking().FirstOrDefaultAsync(_ => _.Login == login);
        }
    }
}

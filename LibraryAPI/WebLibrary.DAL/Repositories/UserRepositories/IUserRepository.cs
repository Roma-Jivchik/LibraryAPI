using WebLibrary.Domain.Entities;

namespace WebLibrary.DAL.Repositories.UserRepositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetUserByLoginAsync(string login);
    }
}

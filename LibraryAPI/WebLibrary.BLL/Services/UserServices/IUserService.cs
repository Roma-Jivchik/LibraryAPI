using WebLibrary.Domain.DTOs;
using WebLibrary.Domain.Requests.UserRequests;

namespace WebLibrary.BLL.Services.UserServices
{
    public interface IUserService
    {
        Task<UserDto?> GetAsync(Guid id);

        Task<List<UserDto>> GetAllAsync();

        Task<bool> UpdateAsync(UpdateUserRequest request);

        Task<bool> DeleteAsync(Guid id);
    }
}

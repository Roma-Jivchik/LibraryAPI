using WebLibrary.Domain.DTOs;
using WebLibrary.Domain.Requests.IdentityRequests;

namespace WebLibrary.BLL.Services.IdentityServices
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> LoginAsync(LoginRequest request);

        Task<AuthenticationResult> RegisterAsync(RegisterRequest request);
    }
}

using Mapster;
using WebLibrary.Domain.DTOs;
using WebLibrary.Domain.Entities;
using WebLibrary.Domain.Requests.UserRequests;
using WebLibrary.DAL.Repositories.UserRepositories;

namespace WebLibrary.BLL.Services.UserServices
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto?> GetAsync(Guid id)
        {
            var userEntity = await _userRepository.GetByIdAsync(id);

            var mappedUser = userEntity?.Adapt<UserDto>();

            return mappedUser;
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var userEntities = await _userRepository.GetAsync();

            var mappedUsers = userEntities.Adapt<List<UserDto>>();

            return mappedUsers;
        }

        public async Task<bool> UpdateAsync(UpdateUserRequest request)
        {
            var userEntity = await _userRepository.GetByIdAsync(request.Id);

            if (userEntity is null)
            {
                return false;
            }

            request.Adapt(userEntity);

            await _userRepository.UpdateAsync(userEntity);
            return true;
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            return _userRepository.DeleteAsync(new User { Id = id });
        }
    }
}

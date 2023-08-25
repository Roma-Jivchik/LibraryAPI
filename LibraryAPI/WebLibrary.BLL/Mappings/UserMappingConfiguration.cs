using Mapster;
using WebLibrary.Domain.DTOs;
using WebLibrary.Domain.Entities;
using WebLibrary.Domain.Requests.UserRequests;
using WebLibrary.Domain.Requests.IdentityRequests;

namespace WebLibrary.BLL.Mappings
{
    internal class UserMappingConfiguration
    {
        public static void Register(TypeAdapterConfig config)
        {
            config.NewConfig<User, UserDto>()
                .RequireDestinationMemberSource(true);

            config.NewConfig<RegisterRequest, User>()
                .RequireDestinationMemberSource(true)
                .Ignore(_ => _.Id)
                .Ignore(_ => _.PasswordHash);

            config.NewConfig<UpdateUserRequest, User>()
                .RequireDestinationMemberSource(true)
                .Ignore(_ => _.Login)
                .Ignore(_ => _.PasswordHash);
        }
    }
}

using Mapster;
using System.Text;
using System.Security.Claims;
using WebLibrary.Domain.DTOs;
using WebLibrary.BLL.Resources;
using WebLibrary.BLL.Extensions;
using WebLibrary.Domain.Entities;
using WebLibrary.Domain.Settings;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using WebLibrary.Domain.Requests.IdentityRequests;
using WebLibrary.DAL.Repositories.UserRepositories;

namespace WebLibrary.BLL.Services.IdentityServices
{
    internal class IdentityService : IIdentityService
    {
        private readonly IUserRepository _userRepository;
        private readonly AuthorizationSettings _authorizationSettings;

        public IdentityService(IUserRepository userRepository, AuthorizationSettings authorizationSettings)
        {
            _userRepository = userRepository;
            _authorizationSettings = authorizationSettings;
        }

        public async Task<AuthenticationResult> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetUserByLoginAsync(request.Login);

            if (user is null)
            {
                return new AuthenticationResult(LoginExceptionMessages.UserNotExist);
            }

            var userHasValidPassword = PasswordHasher.IsHashVerified(request.Password, user.PasswordHash);

            if (!userHasValidPassword)
            {
                return new AuthenticationResult(LoginExceptionMessages.InvalidPassword);
            }

            return GenerateAuthenticationResultForUser(user);
        }

        public async Task<AuthenticationResult> RegisterAsync(RegisterRequest request)
        {
            var existingUser = await _userRepository.GetUserByLoginAsync(request.Login);

            if (existingUser is not null)
            {
                return new AuthenticationResult(RegistrationExceptionMessages.UserAlreadyExists);
            }

            var passwordHash = PasswordHasher.Hash(request.Password);

            var newUser = request.Adapt<User>();
            newUser.PasswordHash = passwordHash;

            var createdUser = await _userRepository.AddAsync(newUser);

            return GenerateAuthenticationResultForUser(createdUser);
        }

        private AuthenticationResult GenerateAuthenticationResultForUser(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_authorizationSettings.Secret);

            var claims = new List<Claim>
            {
            new(JwtRegisteredClaimNames.Sub, user.Login),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Email, user.Login),
            new("Id", user.Id.ToString()),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.Add(_authorizationSettings.TokenLifetime),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                ),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);

            return new AuthenticationResult(jwtToken);
        }
    }
}

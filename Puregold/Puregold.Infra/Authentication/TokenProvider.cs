using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Puregold.Application.Abstractions.Authentication;
using Puregold.Application.Users;
using Puregold.Application.Users.Login;
using Puregold.Domain.Users;

namespace Puregold.Infra.Authentication;

public sealed class TokenProvider(JwtSetting jwtSetting, ILogger<TokenProvider> logger) : ITokenProvider
{
    static readonly string UserIdClaimType = "id";
    static readonly string UserInitialsClaimType = "initials";
    
    public UserTokenDto Create(User user)
    {
        try
        {
            // Get token expiration
            var expires = DateTime.UtcNow.AddMinutes(jwtSetting.ExpirationInMinutes);
        
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.Secret));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity([
                    new Claim(UserIdClaimType, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(UserInitialsClaimType, user.Initials),
                    new Claim(ClaimTypes.Upn, user.Username),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                ]),
                Expires = expires,
                SigningCredentials = credentials,
                Issuer = jwtSetting.Issuer,
                Audience = jwtSetting.Audience,
            };

            var handler = new JsonWebTokenHandler();
            var token = handler.CreateToken(tokenDescriptor);

            return new UserTokenDto(token);
        }
        catch (Exception ex)
        {
            logger.LogError($"Error occurred while creating authentication token for user. {ex.Message}");
            throw;
        }
    }
}
using AccountOwnerServer.Contracts;
using Microsoft.IdentityModel.Tokens;
using Entities.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace AccountOwnerServer.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly IRepositoryWrapper _repository;

    public TokenService(IConfiguration configuration, IRepositoryWrapper repository)
    {
        _configuration = configuration;
        _repository = repository;
    }

    public async Task<string?> Authenticate(string username, string password)
    {
        var user = await _repository.User.GetByUsername(username);

        if (user is null)
        {
            return null;
        }

        if (!user.Password.Equals(password))
        {
            return null;
        }

        string token = this.GenerateToken(user.Code);
        return token;
    }

    public string GenerateToken(int codUsuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Jwt:Key")!);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.NameIdentifier, codUsuario.ToString())
            ]),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}

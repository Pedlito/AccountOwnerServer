namespace AccountOwnerServer.Contracts;

public interface ITokenService
{
    Task<string?> Authenticate(string username, string password);
    string GenerateToken(int codUsuario);
}
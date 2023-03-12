namespace BlazorShop.Server.Auth.PasswordProvider;

public interface IPasswordProvider
{
    string GetPasswordHash(string password);
    bool VerifyPassword(string password, string hash);
}
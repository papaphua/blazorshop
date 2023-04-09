namespace BlazorShop.Server.Common.Providers.PasswordProvider;

public interface IPasswordProvider
{
    string GetPasswordHash(string password);
    bool VerifyPassword(string password, string hash);
}
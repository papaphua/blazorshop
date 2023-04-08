using System.Security.Cryptography;
using BlazorShop.Server.Common.Options;
using Microsoft.Extensions.Options;

namespace BlazorShop.Server.Auth.PasswordProvider;

public sealed class PasswordProvider : IPasswordProvider
{
    private readonly PasswordOptions _options;

    public PasswordProvider(IOptions<PasswordOptions> options)
    {
        _options = options.Value;
    }

    public string GetPasswordHash(string password)
    {
        using var algorithm = new Rfc2898DeriveBytes(
            password,
            _options.SaltSize,
            _options.Iterations,
            HashAlgorithmName.SHA512);

        var key = Convert.ToBase64String(algorithm.GetBytes(_options.KeySize));
        var salt = Convert.ToBase64String(algorithm.Salt);

        return $"{salt}.{key}";
    }

    public bool VerifyPassword(string password, string hash)
    {
        var parts = hash.Split(".", 2);
        
        var salt = Convert.FromBase64String(parts[0]);
        var key = Convert.FromBase64String(parts[1]);
        
        using var algorithm = new Rfc2898DeriveBytes(
            password,
            salt,
            _options.Iterations,
            HashAlgorithmName.SHA512);

        var keyToCheck = algorithm.GetBytes(_options.KeySize);

        return keyToCheck.SequenceEqual(key);
    }
}
namespace BlazorShop.Server.Common.Options;

public sealed class PasswordOptions
{
    public int Iterations { get; set; }

    public int SaltSize { get; set; }

    public int KeySize { get; set; }
}
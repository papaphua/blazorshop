namespace BlazorShop.Server.Options;

public sealed class HashingOptions
{
    public int Iterations { get; set; }
    
    public int SaltSize { get; set; }
    
    public int KeySize { get; set; }
}
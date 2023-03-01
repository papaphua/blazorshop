namespace BlazorShop.Server.Data;

public static class Emails
{
    public static string EmailConfirmation(string link)
    {
        return $"Follow this link to confirm your email: {link}";
    }
    
    public static string PasswordReset(string link)
    {
        return $"Follow this link to reset your password: {link}";
    }
    
    public static string ConfirmationCode(string code)
    {
        return $"Confirmation code: {code}";
    }
}
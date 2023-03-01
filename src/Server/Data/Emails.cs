namespace BlazorShop.Server.Data;

public static class Emails
{
    public static string ConfirmationCode(string code)
    {
        return $"Confirmation code: {code}";
    }
}
namespace BlazorShop.Server.Exceptions;

public static class ExceptionMessages
{
    public const string Unauthorized = "You are not authorized.";
    public const string NotRegistered = "User is not registered.";
    public const string PasswordsNotMatch = "Passwords do not match.";
    public const string InternalError = "Something went wrong.";

    public static string UsernameAndEmailAlreadyExist(string username, string email)
    {
        return $"User with username {username} and email {email} is already registered.";
    }

    public static string UsernameAlreadyExist(string username)
    {
        return $"User with username {username} is already registered.";
    }

    public static string EmailAlreadyExist(string email)
    {
        return $"User with email {email} is already registered.";
    }
}
namespace BlazorShop.Server.Exceptions;

public class AlreadyExistException : BusinessException
{
    public AlreadyExistException(string message)
        : base(message)
    {
    }
}
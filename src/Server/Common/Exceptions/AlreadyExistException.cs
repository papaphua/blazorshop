namespace BlazorShop.Server.Common.Exceptions;

public class AlreadyExistException : BusinessException
{
    public AlreadyExistException(string message)
        : base(message)
    {
    }
}
using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Shared.Dtos;

public class ExceptionDto
{
    public ExceptionDto(string message)
    {
        Message = message;
    }
    
    [Required] public string Message { get; }
}
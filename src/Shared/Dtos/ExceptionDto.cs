using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Shared.Dtos;

public sealed class ExceptionDto
{
    public ExceptionDto(string message)
    {
        Message = message;
    }

    [Required] public string Message { get; }
}
using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Shared.Dtos;

public class ResponseDto
{
    public ResponseDto(string message)
    {
        Message = message;
    }

    [Required] public string Message { get; }
}
using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Shared.Dtos;

public sealed class ExceptionDto
{
    [Required] public string Message { get; set; } = null!;
}
﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Shared.Dtos;

public sealed class TwoAuthLoginDto
{
    [Required(ErrorMessage = "Username or email is required.")]
    [MinLength(6, ErrorMessage = "The {0} must be at least {1} characters long.")]
    [DataType(DataType.Text)]
    public string Login { get; set; } = null!;

    [Required(ErrorMessage = "Password is required.")]
    [StringLength(28, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
    [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Invalid password.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "Code is required.")]
    [DisplayName("Confirmation code from email")]
    public string ConfirmationCode { get; set; } = null!;
}
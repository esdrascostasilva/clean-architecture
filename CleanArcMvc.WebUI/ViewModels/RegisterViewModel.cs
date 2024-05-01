﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CleanArcMvc.WebUI.ViewModels;

public class RegisterViewModel
{
    
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid format email")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "Password don't match")]
    public string ConfirmPassword { get; set; }
}

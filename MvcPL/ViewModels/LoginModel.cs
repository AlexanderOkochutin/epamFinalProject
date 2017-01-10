﻿using System.ComponentModel.DataAnnotations;

namespace MvcPL.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "The field can not be empty")]
        [Display(Name = "Enter your e-mail")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "incorrect email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field can not be empty")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember password?")]
        public bool RememberMe { get; set; }
    }
} 
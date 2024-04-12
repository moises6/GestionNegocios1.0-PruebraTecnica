﻿using System.ComponentModel.DataAnnotations;

namespace GestionNegocios_PruebraTecnica.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Display(Name = "Recuérdame")]
        public bool RememberMe { get; set; }
    }
}

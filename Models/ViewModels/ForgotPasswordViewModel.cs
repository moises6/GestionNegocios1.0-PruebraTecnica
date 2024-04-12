using System.ComponentModel.DataAnnotations;

namespace GestionNegocios_PruebraTecnica.Models.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
      
    }
}

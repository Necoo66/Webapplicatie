using System.ComponentModel.DataAnnotations;

namespace HoneymoonShop.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

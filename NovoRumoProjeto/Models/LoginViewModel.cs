using Resources;
using System.ComponentModel.DataAnnotations;

namespace NovoRumoProjeto.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
            ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
            ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
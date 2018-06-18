using Resources;
using System.ComponentModel.DataAnnotations;

namespace NovoRumoProjeto.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
            ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "email inválido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
            ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
            ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Nome")]
        public string Name { get; set; }
    }
}
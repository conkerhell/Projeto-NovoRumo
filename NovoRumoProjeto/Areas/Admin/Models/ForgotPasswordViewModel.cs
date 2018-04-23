using System.ComponentModel.DataAnnotations;

namespace NovoRumoProjeto.Areas.Admin.Models
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "campo obrigatório")]
        [EmailAddress(ErrorMessage = "email inválido")]
        [Display(Name = "e-mail*")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
using Resources;
using System.ComponentModel.DataAnnotations;

namespace NovoRumoProjeto.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
            ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Nome")]
        public string Name { get; set; }
    }
}
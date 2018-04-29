
using Resources;
using System.ComponentModel.DataAnnotations;

namespace NovoRumoProjeto.Areas.Admin.Models
{
    public class DiaViewModel
    {

        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
            ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
    }
}
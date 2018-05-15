using Resources;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace NovoRumoProjeto.Areas.Admin.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
            ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Telefone")]
        [MinLength(10, ErrorMessage = "telefone inválido")]
        public string Telephone { get; set; }

        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
            ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Celular")]
        [MinLength(10, ErrorMessage = "telefone inválido")]
        public string Mobile { get; set; }

        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
            ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Celular secundário")]
        [MinLength(10, ErrorMessage = "telefone inválido")]
        public string SecondaryMobile { get; set; }

        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
            ErrorMessageResourceName = "PropertyValueRequired")]        
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [AllowHtml]
        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
            ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Endereço")] 
        public string Address { get; set; }

        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
            ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "CEP")]
        public string CEP { get; set; }
    }
}
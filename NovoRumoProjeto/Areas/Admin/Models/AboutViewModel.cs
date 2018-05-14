using NovoRumoProjeto.Utilities.Validation;
using Resources;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace NovoRumoProjeto.Areas.Admin.Models
{
    public class AboutViewModel
    {

        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
            ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Titulo")]
        public string Title { get; set; }

        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
            ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
            ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Nome")]
        public string displayFileName { get; set; }

        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
            ErrorMessageResourceName = "FileRequired")]
        [FileTypes("jpg", "jpeg", "png", ErrorMessageResourceType = typeof(LocalizedMessages),
            ErrorMessageResourceName = "FileFormatInvalid")]
        public HttpPostedFileBase file { get; set; }



    }
}
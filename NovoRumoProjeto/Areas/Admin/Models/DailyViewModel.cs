
using Resources;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace NovoRumoProjeto.Areas.Admin.Models
{
    public class DailyViewModel
    {

        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
            ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Nome")]
        public string displayFileName { get; set; }
        public HttpPostedFileBase file { get; set; }
        public int ID { get; set; }
    }
}
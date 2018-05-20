using Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace NovoRumoProjeto.Areas.Admin.Models
{
    public class EventViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
           ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Título")]
        [AllowHtml]
        public string Title { get; set; }

        [AllowHtml]
        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
           ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
           ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Data do evento")]
        public DateTime? Data { get; set; }

        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
           ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Endereço")]
        public string Address { get; set; }
    }
}
using Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace NovoRumoProjeto.Areas.Admin.Models
{
    public class EventViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
           ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Título")]
        public string Title { get; set; }

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
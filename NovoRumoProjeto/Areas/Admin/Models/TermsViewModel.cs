using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovoRumoProjeto.Areas.Admin.Models
{
    public class TermsViewModel
    {
        public int TermId { get; set; }
        [AllowHtml]
        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
           ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Titulo")]
        public string Title { get; set; }

        [AllowHtml]
        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
            ErrorMessageResourceName = "PropertyValueRequired")]
        [Display(Name = "Descrição")]
        public string Description { get; set; }
    }
}
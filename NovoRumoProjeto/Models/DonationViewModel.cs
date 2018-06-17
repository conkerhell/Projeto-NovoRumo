using NovoRumoProjeto.Utilities.Domains;
using Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NovoRumoProjeto.Models
{
    public class DonationViewModel
    {
        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
            ErrorMessageResourceName = "PropertyValueRequired")]
        public bool Terms { get; set; }

        public string Value { get; set; }

        [StringLength(5)]
        public string SpecificValue { get; set; }

        public bool isMonthlyDonator { get; set; }
    }
}
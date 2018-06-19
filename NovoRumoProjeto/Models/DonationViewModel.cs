using NovoRumoProjeto.Utilities.Validation;
using Resources;
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
        [RequiredIf("Value", true)]
        public string SpecificValue { get; set; }

        public bool isMonthlyDonator { get; set; }
    }
}
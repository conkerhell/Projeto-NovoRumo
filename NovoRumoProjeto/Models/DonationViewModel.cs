using NovoRumoProjeto.Utilities.Domains;
using NovoRumoProjeto.Utilities.Validation;
using Resources;
using System;
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

        public Enums.Type Type { get; set; }

        public decimal GetTotal()
        {
            return (Value.Equals("0")) ? Convert.ToDecimal(SpecificValue) : Convert.ToDecimal(Value);
        }
    }
}
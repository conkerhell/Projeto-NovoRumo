using Resources;
using System.ComponentModel.DataAnnotations;

namespace NovoRumoProjeto.Models
{
    public class DonationViewModel
    {
        [Required(ErrorMessageResourceType = typeof(LocalizedMessages),
            ErrorMessageResourceName = "PropertyValueRequired")]
        public bool Terms { get; set; }
        public decimal Value { get; set; }
        public bool isMonthlyDonator { get; set; }
    }
}
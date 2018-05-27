
namespace NovoRumoProjeto.Utilities.Payment.Model
{
    public class PaymentStatusIndicator
    {
        public PaymentStatusIndicator()
        {
            RedirectUrl = "Falha";
        }

        public bool Status { get; set; }
        public string RedirectUrl { get; set; }
    }
}

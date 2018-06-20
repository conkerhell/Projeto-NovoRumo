
namespace NovoRumoProjeto.PaymentCreator
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

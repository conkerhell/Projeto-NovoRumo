
namespace NovoRumoProjeto.PaymentCreator
{
    public class PaymentStatus
    {
        public PaymentStatus()
        {
            RedirectUrl = "Falha";
        }

        public bool Status { get; set; }
        public string RedirectUrl { get; set; }
    }
}

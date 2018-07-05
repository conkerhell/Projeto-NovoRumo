
using System.Web.Routing;

namespace NovoRumoProjeto.PaymentCreator
{
    public class PagSeguroModel : IPaymentModel
    {

    }

    public class PayPalModel : IPaymentModel
    {
        public RequestContext RequestContext { get; set; }
        public string Charge { get; set; }
    }

    public class BankTransferenceModel : IPaymentModel
    {

    }
}

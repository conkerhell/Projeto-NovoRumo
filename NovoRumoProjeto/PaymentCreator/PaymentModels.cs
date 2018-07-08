
using NovoRumoProjeto.Entity;
using System.Web.Routing;

namespace NovoRumoProjeto.PaymentCreator
{
    public class PagSeguroSingleModel : IPaymentModel
    {
        public RequestContext RequestContext { get; set; }

        public UserEntity User { get; set; }
    }

    public class PagSeguroMonthlyModel : IPaymentModel
    {
        public RequestContext RequestContext { get; set; }

        public string Charge
        {
            get
            {
                return "AUTO";
            }
        }

        public string Period
        {
            get
            {
                return "MONTHLY";
            }
        }

        public string Name
        {
            get
            {
                return "Doação Mensal para Novo Rumo Atibaia";
            }
        }

        public decimal amountPerPayment { get; set; }

        public UserEntity User{ get; set; }
    }

    public class PayPalModel : IPaymentModel
    {

    }

    public class BankTransferenceModel : IPaymentModel
    {

    }
}

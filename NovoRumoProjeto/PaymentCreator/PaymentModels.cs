
using NovoRumoProjeto.Entity;
using System;
using System.Web.Http.Routing;
using System.Web.Routing;

namespace NovoRumoProjeto.PaymentCreator
{
    public class PagSeguroSingleModel : IPaymentModel
    {
        public RequestContext RequestContext { get; set; }

        public UserEntity User { get; set; }

        public decimal Value { get; set; }
        public string Id { get; set; }
    }

    public class PagSeguroMonthlyModel : IPaymentModel
    {
        public RequestContext RequestContext { get; set; }

        public string Charge
        {
            get
            {
                return "auto";
            }
        }

        public string Period
        {
            get
            {
                return "Monthly";
            }
        }

        public string Name
        {
            get
            {
                return "Doacao Mensal";
            }
        }

        public DateTime FinalDate
        {
            get
            {
                return DateTime.Now.AddYears(1);
            }
        }

        public string Details
        {
            get
            {
                return "Pagamento da doacao mensal da Associacao Novo Rumo";
            }
        }

        public Uri ReviewUrl
        {
            get
            {
                return new Uri(RequestContext.HttpContext.Request.Url.AbsoluteUri.ToString());
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

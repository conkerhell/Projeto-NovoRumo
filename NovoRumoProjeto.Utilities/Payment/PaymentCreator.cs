using System;
using System.Configuration;
using System.Web.Routing;

namespace NovoRumoProjeto.Utilities.Payment
{
    public class PaymentCreator : IPaymentCreator
    {
        private const string REDIRECT_URI = "http://queenfitfood.com.br/pagamento/finalizado";
        private const string NAME_FORMAT = "{0} {1}";
        public RequestContext requestContext;

        public bool isSandbox
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings["isSandbox"]); }
        }

        public PaymentCreator()
        {

        }

        public PaymentCreator(RequestContext requestContext)
        {
            this.requestContext = requestContext;
        }

        public bool CheckTransaction(string code, string id)
        {
            throw new System.NotImplementedException();
        }
    }
}

using System;
using System.Configuration;
using System.Web.Routing;
using NovoRumoProjeto.Entity;
using NovoRumoProjeto.Utilities.Payment.Model;
using Uol.PagSeguro.Domain;
using Uol.PagSeguro.Resources;

namespace NovoRumoProjeto.Utilities.Payment
{
    public class PaymentCreator : IPaymentCreator
    {
        private const string REDIRECT_URI = "http://queenfitfood.com.br/pagamento/finalizado";
        private const string NAME_FORMAT = "{0} {1}";
        private RequestContext requestContext;

        public bool isSandbox
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings["isSandbox"]); }
        }

        public PaymentCreator(RequestContext requestContext)
        {
            this.requestContext = requestContext;
        }

        public bool CheckTransaction(string code, string id)
        {
            throw new System.NotImplementedException();
        }

        public PaymentStatusIndicator Create(OrderEntity entity)
        {
            //var orderId = InitiateOrder(entity);
            var paymentStatusIndicator = new PaymentStatusIndicator();

            //if (orderId.HasValue)
            //{
            //    EnvironmentConfiguration.ChangeEnvironment(isSandbox);
            //    PaymentRequest payment = new PaymentRequest();
            //    foreach (var product in entity.orderDetails)
            //    {
            //        payment.Items.Add(new Item(product.ProductId.ToString(), product.Name, product.Quantity, product.Price));
            //    }

            //    payment.Reference = orderId.Value.ToString();
            //    payment.Shipping = new Uol.PagSeguro.Domain.Shipping();
            //    payment.Shipping.ShippingType = 3;
            //    payment.Shipping.Cost = entity.ShippingInfo.ShippingCalculation.Calculation;

            //    var discount = (payment.Items.Sum(a => a.Amount * a.Quantity) * entity.CouponDiscount) / 100;
            //    payment.ExtraAmount = discount * -1;

            //    var name = string.Format(NAME_FORMAT, entity.User.Name, entity.User.Lastname.FormatLastName());
            //    var areaId = entity.User.Phonenumber.Split('(', ')')[1];
            //    var phone = entity.User.Phonenumber.Split(' ')[1].Replace("-", string.Empty);

            //    payment.Sender = new Sender(name, entity.User.Email, new Phone(areaId, phone));

            //    payment.RedirectUri = new Uri(REDIRECT_URI);
            //    AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);
            //    try
            //    {
            //        Uri paymentRedirectUri = payment.Register(credentials);
            //        paymentStatusIndicator.RedirectUrl = paymentRedirectUri.ToString();
            //        paymentStatusIndicator.Status = true;
            //    }
            //    catch (PagSeguroServiceException ex)
            //    {
            //        LogException(ex);
            //    }
            //}

            return paymentStatusIndicator;
        }
    }
}

using System;
using System.Configuration;
using System.Web.Routing;
using NovoRumoProjeto.DAL.Order;
using NovoRumoProjeto.Entity;
using NovoRumoProjeto.Utilities.Domains;

namespace NovoRumoProjeto.PaymentCreator
{
    public class Payment : IPayment
    {
        private OrderEntity order;
        private RequestContext requestContext;
        private int type;

        private Payment(int type)
        {
            this.type = type;
        }

        public static IPayment CreatePaymentFor(Enums.Type type)
        {
            return new Payment((int)type);
        }

        private bool isSandbox
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings["isSandbox"]); }
        }

        private string RedirectUrl
        {
            get { return ConfigurationManager.AppSettings["RedirectUrl"]; }
        }

        public bool CheckTransaction(string code, string id)
        {
            throw new NotImplementedException();
        }

        public IPayment SetOrder(OrderEntity order)
        {
            this.order = order;
            return this;
        }

        public IPayment SetUser(UserEntity user)
        {
            order.User = user;
            return this;
        }

        public IPayment SetRequestContext(RequestContext requestContext)
        {
            this.requestContext = requestContext;
            return this;
        }

        public PaymentStatusIndicator Send()
        {
            IOrderDAL orderDAL = new OrderDAL();
            var orderId = orderDAL.InsertOrder(order);
            var paymentStatusIndicator = new PaymentStatusIndicator();

            if (orderId.HasValue)
            {
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
            }

            return paymentStatusIndicator;
        }

        PaymentStatusIndicator IPayment.Send()
        {
            throw new NotImplementedException();
        }
    }
}

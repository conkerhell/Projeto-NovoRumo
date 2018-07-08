using NovoRumoProjeto.DAL.Order;
using NovoRumoProjeto.Entity;
using NovoRumoProjeto.Utilities;
using NovoRumoProjeto.Utilities.LogManager;
using System;
using System.Configuration;
using Uol.PagSeguro.Domain;
using Uol.PagSeguro.Exception;
using Uol.PagSeguro.Resources;

namespace NovoRumoProjeto.PaymentCreator
{
    public class PagSeguroSinglePayment : PaymentService<PagSeguroSingleModel>
    {
        private bool isSandbox
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings[Consts.IS_SANDBOX]); }
        }

        protected override PaymentStatus MakePayment(PagSeguroSingleModel model)
        {
            var paymentStatus = new PaymentStatus();
            var orderId = InitOrder(new OrderEntity() { });
            if (!orderId.HasValue)
            {
                return paymentStatus;
            }

            EnvironmentConfiguration.ChangeEnvironment(isSandbox);
            PaymentRequest payment = new PaymentRequest();
            payment.Reference = orderId.Value.ToString();

            var name = model.User.Name;
            var email = model.User.Email;
            payment.Sender = new Sender(name, email, null);

            payment.RedirectUri = new Uri(Consts.REDIRECT_URI);
            AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);
            try
            {
                Uri paymentRedirectUri = payment.Register(credentials);
                paymentStatus.RedirectUrl = paymentRedirectUri.ToString();
                paymentStatus.Status = true;
            }
            catch (PagSeguroServiceException ex)
            {
                Log.Instance.Error(ex);
            }

            return paymentStatus;
        }

        private int? InitOrder(OrderEntity entity)
        {
            IOrderDAL orderBusiness = new OrderDAL();
            var orderId = orderBusiness.InsertOrder(entity);
            return orderId;
        }
    }
}
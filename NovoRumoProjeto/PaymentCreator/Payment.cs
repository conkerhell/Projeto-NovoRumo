using NovoRumoProjeto.DAL.Order;
using NovoRumoProjeto.Entity;
using NovoRumoProjeto.Utilities;
using System;
using System.Configuration;
using Uol.PagSeguro.Domain;
using Uol.PagSeguro.Resources;

namespace NovoRumoProjeto.PaymentCreator
{
    public class PagSeguroPayment : PaymentService<PagSeguroModel>
    {
        private bool isSandbox
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings[Consts.IS_SANDBOX]); }
        }

        protected override PaymentStatus MakePayment(PagSeguroModel model)
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

            //var name = $"{model.User.Name} {model.User.Lastname.FormatLastName()}"; 
            //var email = model.User.Email;
            var name = "John Doe";
            var email = "teste@teste.com.br";
            payment.Sender = new Sender(name, email, null);

            payment.RedirectUri = new Uri(Consts.REDIRECT_URI);
            AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);
            //try
            //{
                Uri paymentRedirectUri = payment.Register(credentials);
                paymentStatus.RedirectUrl = paymentRedirectUri.ToString();
                paymentStatus.Status = true;
            //}
            //catch (PagSeguroServiceException ex)
            //{
            //    LogException(ex);
            //}

            return paymentStatus;
        }

        private int? InitOrder(OrderEntity entity)
        {
            IOrderDAL orderBusiness = new OrderDAL();
            var orderId = orderBusiness.InsertOrder(entity);
            return orderId;
        }
    }

    //{
    //"preApproval": {
    //    "name": "Assinatura da Revista Fictícia",
    //    "charge": "AUTO",
    //    "period": "MONTHLY",
    //    "amountPerPayment": 100.00,
    //    "expiration": {
    //        "value": 1,
    //        "unit": "YEARS"
    //    }
    //},
    //"receiver": {
    //    "email": "seu@email.com.br"
    //}
}
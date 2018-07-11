using NovoRumoProjeto.DAL.Order;
using NovoRumoProjeto.Entity;
using NovoRumoProjeto.Utilities;
using NovoRumoProjeto.Utilities.Domains;
using NovoRumoProjeto.Utilities.LogManager;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
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
            var orderId = InitOrder(model);
            if (!orderId.HasValue)
            {
                return paymentStatus;
            }

            EnvironmentConfiguration.ChangeEnvironment(isSandbox);
            PaymentRequest payment = new PaymentRequest();
            payment.Reference = orderId.Value.ToString();

            payment.Items.Add(new Item(model.Id, "Doação única", 1, model.Value));

            var fullname = $"{model.User.Name} {model.User.Lastname}";
            var email = model.User.Email;
            payment.Sender = new Sender(fullname, email, null);

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
                LogException(ex);
            }

            return paymentStatus;
        }

        private int? InitOrder(PagSeguroSingleModel model)
        {
            IOrderDAL orderBusiness = new OrderDAL();

            var orderId = orderBusiness.InsertOrder(new OrderEntity()
            {
                User = model.User,
                RecordDate = DateTime.Now,
                Type = new TypeEntity() { TypeId = (int)Enums.Type.SingleDonation },
                Total = model.Value
            });

            if (orderId.HasValue)
            {
                var status = orderBusiness.InsertStatus(new OrderStatusEntity()
                {
                    OrderId = orderId.Value,
                    RecordDate = DateTime.Now,
                    Status = (int)Enums.PaymentStatus.AguardandoPagamento
                });

                if (status)
                {
                    return orderId;
                }
            }

            return null;
        }

        private void LogException(PagSeguroServiceException ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ex.ToString());

            if (ex.Errors != null)
            {
                foreach (var error in ex.Errors)
                {
                    sb.AppendLine(error.Message);
                }
            }

            Log.Instance.Error("Pagseguro: Erro durante a compra", sb.ToString());
        }
    }
}
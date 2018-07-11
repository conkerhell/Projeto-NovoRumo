using NovoRumoProjeto.DAL.Order;
using NovoRumoProjeto.Entity;
using NovoRumoProjeto.Utilities;
using NovoRumoProjeto.Utilities.Domains;
using NovoRumoProjeto.Utilities.LogManager;
using System;
using System.Configuration;
using System.Text;
using Uol.PagSeguro.Constants;
using Uol.PagSeguro.Domain;
using Uol.PagSeguro.Exception;
using Uol.PagSeguro.Resources;

namespace NovoRumoProjeto.PaymentCreator
{
    public class PagSeguroMonthlyPayment : PaymentService<PagSeguroMonthlyModel>
    {
        private bool isSandbox
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings[Consts.IS_SANDBOX]); }
        }

        protected override PaymentStatus MakePayment(PagSeguroMonthlyModel model)
        {
            var paymentStatus = new PaymentStatus();
            var orderId = InitOrder(model);
            if (!orderId.HasValue)
            {
                return paymentStatus;
            }

            EnvironmentConfiguration.ChangeEnvironment(isSandbox);
            PreApprovalRequest preApproval = new PreApprovalRequest();
            preApproval.Reference = orderId.Value.ToString();
            preApproval.Currency = Currency.Brl;
            preApproval.PreApproval = new PreApproval()
            {
                Charge = model.Charge,
                Name = model.Name,
                Details = model.Details,
                DayOfMonth = 15,
                Period = model.Period,
                FinalDate = model.FinalDate,
                AmountPerPayment = model.amountPerPayment,
                MaxTotalAmount = model.amountPerPayment * 12
            };
            preApproval.ReviewUri = model.ReviewUrl;

            var fullname = $"{model.User.Name} {model.User.Lastname}";
            var email = model.User.Email;
            preApproval.Sender = new Sender(fullname, email, null);

            preApproval.RedirectUri = new Uri(Consts.REDIRECT_URI);
            AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);

            try
            {
                Uri paymentRedirectUri = preApproval.Register(credentials);
                paymentStatus.RedirectUrl = paymentRedirectUri.ToString();
                paymentStatus.Status = true;
            }
            catch (PagSeguroServiceException ex)
            {
                LogException(ex);
            }

            return paymentStatus;
        }

        private int? InitOrder(PagSeguroMonthlyModel model)
        {
            IOrderDAL orderBusiness = new OrderDAL();

            var orderId = orderBusiness.InsertOrder(new OrderEntity()
            {
                User = model.User,
                RecordDate = DateTime.Now,
                Type = new TypeEntity() { TypeId = (int)Enums.Type.MonthlyDonation },
                Total = model.amountPerPayment
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

//11113=preApproval auto charged can not be informed in a checkout.
//11024=Items invalid quantity.\n11012= senderName invalid value: 
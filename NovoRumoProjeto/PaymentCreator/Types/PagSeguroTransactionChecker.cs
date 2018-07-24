using NovoRumoProjeto.Utilities;
using NovoRumoProjeto.Utilities.Domains;
using System;
using System.Configuration;
using System.Web.Routing;
using Uol.PagSeguro.Domain;
using Uol.PagSeguro.Exception;
using Uol.PagSeguro.Resources;
using Uol.PagSeguro.Service;

namespace NovoRumoProjeto.PaymentCreator.Types
{
    public class PagSeguroTransactionChecker
    {
        private RequestContext requestContext;
        private bool isSandbox
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings[Consts.IS_SANDBOX]); }
        }

        public PagSeguroTransactionChecker(RequestContext requestContext)
        {
            this.requestContext = requestContext;
        }

        public bool CheckTransaction(string code, string id)
        {
            EnvironmentConfiguration.ChangeEnvironment(isSandbox);
            AccountCredentials credentials = PagSeguroConfiguration.Credentials(isSandbox);
            try
            {
                Transaction transaction = NotificationService.CheckTransaction(credentials, code);

                if (transaction.Reference == null)
                {
                    return false;
                }

                //var order = GetOrderById(Convert.ToInt32(transaction.Reference));
                //var orderStatus = GetCurrentStatus(order.OrderId);

                if (transaction.TransactionStatus == (int)Enums.PaymentStatus.Disponivel)
                {
                    return true;
                }

                //order.NotificationCode = transaction.Code;
                //order.CurrentStatus = string.IsNullOrWhiteSpace(transaction.TransactionStatus.ToString()) ?
                //    (int)Enums.PaymentStatus.AguardandoPagamento :
                //    transaction.TransactionStatus;

                //bool isOrderUpdated = UpdateOrderStatus(new OrderStatusEntity()
                //{
                //    OrderId = order.OrderId,
                //    RecordDate = DateTime.Now,
                //    Status = order.CurrentStatus
                //});
                //isOrderUpdated = isOrderUpdated && UpdateOrder(order);

                //if (isOrderUpdated &&
                //    order.CurrentStatus == ((int)Enums.PaymentStatus.Disponivel) ||
                //    order.CurrentStatus == ((int)Enums.PaymentStatus.Pago))
                //{ 
                //    //order.User = GetUserById(order.UserId);
                //    //SendPurchaseEmail(order);
                //    //SendAdminPurchaseEmail(order);
                //}

                return true;
            }
            catch (PagSeguroServiceException ex)
            {
                //LogException(ex);
                return false;
            }
        }
    }
}
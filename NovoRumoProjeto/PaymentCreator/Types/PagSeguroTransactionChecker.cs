using NovoRumoProjeto.DAL.Order;
using NovoRumoProjeto.Entity;
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
        private readonly IOrderDAL orderDAL;

        public PagSeguroTransactionChecker()
        {
            orderDAL = new OrderDAL();
        }

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

                var order = orderDAL.GetById(Convert.ToInt32(transaction.Reference));

                if (transaction.TransactionStatus == (int)Enums.PaymentStatus.Disponivel)
                {
                    return true;
                }

                order.NotificationCode = transaction.Code;

                bool isOrderUpdated = orderDAL.InsertStatus(new OrderStatusEntity
                {
                    OrderId = order.OrderId,
                    RecordDate = DateTime.Now,
                    Status = transaction.TransactionStatus
            });
                isOrderUpdated = isOrderUpdated && orderDAL.Update(order);

                //if (isOrderUpdated &&
                //    order.CurrentStatus == ((int)Enums.PaymentStatus.Disponivel) ||
                //    order.CurrentStatus == ((int)Enums.PaymentStatus.Pago))
                //{
                //    //order.user = getuserbyid(order.userid);
                //    //sendpurchaseemail(order);
                //    //sendadminpurchaseemail(order);
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
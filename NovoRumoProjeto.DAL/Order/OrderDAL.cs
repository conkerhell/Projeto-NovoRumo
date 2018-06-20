using System;
using System.Collections.Generic;
using System.Data;
using NovoRumoProjeto.Entity;

namespace NovoRumoProjeto.DAL.Order
{
    public class OrderDAL : DAL, IOrderDAL
    {
        //Order
        private const string COLUMN_ORDER_ID = "OrderId";
        private const string COLUMN_USER_ID = "UserId";
        private const string COLUMN_TYPE_ID = "TypeId"; 
        private const string COLUMN_NOTIFICATION_CODE = "NotificationCode";
        private const string COLUMN_PAYPAL_GUID = "PaypalGuid";
        private const string COLUMN_TOTAL = "Total";
        private const string COLUMN_RECORD_DATE = "RecordDate"; 

        //Procedures
        private const string PROC_GET_ORDERS = "spGetOrders";
        private const string PROC_GET_ORDER_BY_GUID = "spGetOrderByGuid";
        private const string PROC_GET_ORDER_BY_ID = "spGetOrderById";
        private const string PROC_GET_ORDER_DETAILS_BY_ID = "spGetOrderDetailsById";
        private const string PROC_GET_ORDER_STATUS_BY_ID = "spGetStatusByOrderId";
        private const string PROC_INSERT_ORDER = "spInsertOrder";
        private const string PROC_INSERT_ORDER_STATUS = "spInsertOrderStatus";

        public List<OrderEntity> Get()
        {
            throw new NotImplementedException();
        }

        public OrderEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(OrderEntity entity)
        {
            throw new NotImplementedException();
        }

        public int? InsertOrder(OrderEntity entity)
        {
            var orderId = dataAccess.ExecuteScalar(PROC_INSERT_ORDER,
            dataAccess.ParameterFactory.Create(COLUMN_USER_ID, DbType.Int32, entity.User.UserID, ParameterDirection.Input),
            dataAccess.ParameterFactory.Create(COLUMN_TYPE_ID, DbType.Int32, entity.Type.TypeId, ParameterDirection.Input),
            dataAccess.ParameterFactory.Create(COLUMN_NOTIFICATION_CODE, DbType.String, entity.NotificationCode, ParameterDirection.Input),
            dataAccess.ParameterFactory.Create(COLUMN_PAYPAL_GUID, DbType.String, entity.PaypalGuid, ParameterDirection.Input),
            dataAccess.ParameterFactory.Create(COLUMN_TOTAL, DbType.Decimal, entity.Total, ParameterDirection.Input),
            dataAccess.ParameterFactory.Create(COLUMN_RECORD_DATE, DbType.Date, entity.RecordDate, ParameterDirection.Input));

            return Convert.ToInt32(orderId);
        }

        public bool Update(OrderEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

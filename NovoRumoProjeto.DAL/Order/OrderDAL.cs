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
        private const string COLUMN_NAME = "Name";
        private const string COLUMN_LASTNAME = "Lastname";
        private const string COLUMN_EMAIL = "Email";

        //OrderStatus
        private const string COLUMN_STATUS_ID = "StatusId";

        //Procedures
        private const string PROC_GET_ORDERS = "spGetOrders";
        private const string PROC_GET_ORDER_BY_GUID = "spGetOrderByGuid";
        private const string PROC_GET_ORDER_BY_ID = "spGetOrderById";
        private const string PROC_GET_ORDER_DETAILS_BY_ID = "spGetOrderDetailsById";
        private const string PROC_GET_ORDER_STATUS_BY_ID = "spGetStatusByOrderId";
        private const string PROC_INSERT_ORDER = "spInsertOrder";
        private const string PROC_INSERT_ORDER_STATUS = "spInsertOrderStatus";
        private const string PROC_UPDATE_ORDER = "spUpdateOrder";
        private const string PROC_GET_DONATIONS = "spGetDonations";

        public List<OrderEntity> Get()
        {
            throw new NotImplementedException();
        }

        public OrderEntity GetById(int id)
        {
            using (var result = dataAccess.ExecuteReader(PROC_GET_ORDER_BY_ID,
                dataAccess.ParameterFactory.Create(COLUMN_ORDER_ID, DbType.Int32, id, ParameterDirection.Input)))
            {
                var order = new OrderEntity();

                if (result.HasRows)
                {
                    if (result.Read())
                    {
                        order.OrderId = Convert.ToInt32(result[COLUMN_ORDER_ID]);
                        order.RecordDate = Convert.ToDateTime(result[COLUMN_RECORD_DATE]);
                        order.Total = Convert.ToDecimal(result[COLUMN_TOTAL]);
                        order.PaypalGuid = result[COLUMN_PAYPAL_GUID].ToString();
                        order.NotificationCode = result[COLUMN_NOTIFICATION_CODE].ToString();
                    }
                }

                return order;
            }
        }

        public List<OrderEntity> GetDonations()
        {
            using (var result = dataAccess.ExecuteReader(PROC_GET_DONATIONS))
            {
                var orders = new List<OrderEntity>();

                if (result.HasRows)
                {
                    OrderEntity order;
                    while (result.Read())
                    {
                        order = new OrderEntity();
                        order.OrderId = Convert.ToInt32(result[COLUMN_ORDER_ID]);
                        order.RecordDate = Convert.ToDateTime(result[COLUMN_RECORD_DATE]);
                        order.Total = Convert.ToDecimal(result[COLUMN_TOTAL]);
                        order.PaypalGuid = result[COLUMN_PAYPAL_GUID].ToString();
                        order.NotificationCode = result[COLUMN_NOTIFICATION_CODE].ToString();

                        order.User = new UserEntity();
                        order.User.Name = result[COLUMN_NAME].ToString();
                        order.User.Lastname = result[COLUMN_LASTNAME].ToString();
                        order.User.Email = result[COLUMN_EMAIL].ToString();

                        orders.Add(order);
                    }
                }

                return orders;
            }
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
            dataAccess.ParameterFactory.Create(COLUMN_RECORD_DATE, DbType.DateTime, entity.RecordDate, ParameterDirection.Input));

            return Convert.ToInt32(orderId);
        }

        public bool InsertStatus(OrderStatusEntity entity)
        {
            return dataAccess.ExecuteNonQuery(PROC_INSERT_ORDER_STATUS,
                dataAccess.ParameterFactory.Create(COLUMN_ORDER_ID, DbType.Int32, entity.OrderId, ParameterDirection.Input),
                dataAccess.ParameterFactory.Create(COLUMN_STATUS_ID, DbType.Int32, entity.Status, ParameterDirection.Input),
                dataAccess.ParameterFactory.Create(COLUMN_RECORD_DATE, DbType.DateTime, entity.RecordDate, ParameterDirection.Input)) == 1;
        }

        public bool Update(OrderEntity entity)
        {
            return dataAccess.ExecuteNonQuery(PROC_UPDATE_ORDER,
                dataAccess.ParameterFactory.Create(COLUMN_ORDER_ID, DbType.Int32, entity.OrderId, ParameterDirection.Input),
                dataAccess.ParameterFactory.Create(COLUMN_PAYPAL_GUID, DbType.String, entity.PaypalGuid, ParameterDirection.Input),
                dataAccess.ParameterFactory.Create(COLUMN_NOTIFICATION_CODE, DbType.String, entity.NotificationCode, ParameterDirection.Input)) == 1;
        }
    }
}

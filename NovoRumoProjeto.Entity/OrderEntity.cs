using System;
using System.Collections.Generic;

namespace NovoRumoProjeto.Entity
{
    public class OrderEntity
    {
        public OrderEntity()
        {
            User = new UserEntity();
            Type = new TypeEntity();
            orderDetail = new List<OrderDetailEntity>();
            orderStatus = new List<OrderStatusEntity>();
        }

        public int OrderId { get; set; }
        public UserEntity User { get; set; }
        public TypeEntity Type { get; set; }
        public string NotificationCode { get; set; }
        public string PaypalGuid { get; set; }
        public decimal Total { get; set; }
        public DateTime RecordDate { get; set; }
        public List<OrderDetailEntity> orderDetail { get; set; }
        public List<OrderStatusEntity> orderStatus { get; set; }
    }

    public class OrderDetailEntity
    {
        public int OrderId { get; set; }
    }

    public class OrderStatusEntity
    {
        public int OrderId { get; set; }
        public int Status { get; set; }
        public DateTime RecordDate { get; set; }
    }

    public class TypeEntity
    {
        public int TypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

using NovoRumoProjeto.Entity;
using System.Collections.Generic;

namespace NovoRumoProjeto.DAL.Order
{
    public interface IOrderDAL : IDAL<OrderEntity>
    {
        int? InsertOrder(OrderEntity entity);
        bool InsertStatus(OrderStatusEntity entity);
        List<OrderEntity> GetDonations();
        List<OrderStatusEntity> GetOrderStatusById(int id);
    }
}

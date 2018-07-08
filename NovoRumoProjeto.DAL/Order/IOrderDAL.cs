using NovoRumoProjeto.Entity;

namespace NovoRumoProjeto.DAL.Order
{
    public interface IOrderDAL : IDAL<OrderEntity>
    {
        int? InsertOrder(OrderEntity entity);
        bool InsertStatus(OrderStatusEntity entity);
    }
}

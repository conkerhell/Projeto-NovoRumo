using NovoRumoProjeto.Entity;
using System.Web.Routing;

namespace NovoRumoProjeto.PaymentCreator
{
    public interface IPayment
    {
        IPayment SetOrder(OrderEntity order);        
        IPayment SetUser(UserEntity user);
        IPayment SetRequestContext(RequestContext requestContext);
        PaymentStatusIndicator Send();
        bool CheckTransaction(string code, string id);
    }
}

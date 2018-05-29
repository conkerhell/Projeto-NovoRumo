using NovoRumoProjeto.Entity;
using NovoRumoProjeto.Utilities.Payment.Model;

namespace NovoRumoProjeto.Utilities.Payment
{
    public interface IPaymentCreator
    {
        PaymentStatusIndicator Create(OrderEntity entity);
        bool CheckTransaction(string code, string id);

    }
}

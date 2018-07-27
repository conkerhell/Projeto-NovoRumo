using System;

namespace NovoRumoProjeto.PaymentCreator
{
    public abstract class PaymentService<TModel> : IPaymentService where TModel : IPaymentModel
    {
        public virtual bool AppliesTo(Type provider)
        {
            return typeof(TModel).Equals(provider);
        }

        public PaymentStatus MakePayment<T>(T model) where T : IPaymentModel
        {
            return MakePayment((TModel)(object)model);
        }

        protected abstract PaymentStatus MakePayment(TModel model);
    }
}
using System;

namespace NovoRumoProjeto.PaymentCreator
{
    public interface IPaymentModel { }

    public interface IPaymentService
    {
        PaymentStatus MakePayment<T>(T model) where T : IPaymentModel;
        bool AppliesTo(Type provider);
    }

    public interface IPaymentStrategy
    {
        PaymentStatus MakePayment<T>(T model) where T : IPaymentModel;
    }
}
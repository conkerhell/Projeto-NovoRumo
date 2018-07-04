using System;

namespace NovoRumoProjeto.PaymentCreator
{
    public class PayPalPayment : PaymentService<PayPalModel>
    {
        protected override PaymentStatus MakePayment(PayPalModel model)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoRumoProjeto.Utilities.Domains
{
    public class Enums
    {
        public enum Type
        {
            MonthlyDonation = 1,
            SingleDonation = 2,
            BankTransfer = 3,
            Purchase = 4
        }

        public enum PaymentStatus
        {
            AguardandoPagamento = 1,
            EmAnalise = 2,
            Pago = 3,
            Disponivel = 4,
            EmDisputa = 5,
            Retornado = 6,
            Cancelado = 7,
        }
    }
}

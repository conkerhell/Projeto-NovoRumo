
using System;

namespace NovoRumoProjeto.Entity
{
    public class DonationEntity
    {
        public int OrderID { get; set; }
        public byte Status { get; set; }
        public int UserId { get; set; }
        public string NotificationCode { get; set; }
        public string PaypalGuid { get; set; }
        public decimal Total { get; set; }
        public DateTime RecordDate { get; set; }
    }
}

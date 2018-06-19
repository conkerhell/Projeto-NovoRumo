using System;

namespace NovoRumoProjeto.Entity
{
    public class OrderEntity
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public decimal Value { get; set; }
        public DateTime RecordDate { get; set; }
    }
}

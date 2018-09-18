
using System;

namespace NovoRumoProjeto.Entity
{
    public class DailyEntity
    {
        public int DailyID { get; set; }
        public string Name { get; set; }
        public string fileName { get; set; }
        public byte Status { get; set; }
        public DateTime Data { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

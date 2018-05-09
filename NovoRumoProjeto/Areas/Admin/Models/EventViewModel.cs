
using System;

namespace NovoRumoProjeto.Areas.Admin.Models
{
    public class EventViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Data { get; set; }
        public string Endereço { get; set; }
    }
}
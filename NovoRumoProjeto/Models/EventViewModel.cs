using NovoRumoProjeto.DAL.Event;
using System;
namespace NovoRumoProjeto.Models
{
    public class EventViewModel
    {
        public int ID { get; set; }
        
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? Data { get; set; }

        public string Address { get; set; }

        public void GetNextEvent()
        {
            IEventDAL eventDAL = new EventDAL();
            var entity = eventDAL.GetNextEvent();
            Title = entity.Title;
            Description = entity.Description;
            Data = entity.Data;
            Address = entity.Address;
        }
    }
}
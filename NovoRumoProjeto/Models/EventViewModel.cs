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

        public bool CheckAndGetNextEvent()
        {
            IEventDAL eventDAL = new EventDAL();
            var entity = eventDAL.GetNextEvent();
            if (entity != null)
            {
                Title = entity.Title;
                Description = entity.Description;
                Data = entity.Data;
                Address = entity.Address;
                return true;
            }
            return false;
        }
    }
}
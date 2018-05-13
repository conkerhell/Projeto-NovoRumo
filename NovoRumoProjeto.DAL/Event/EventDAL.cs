using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovoRumoProjeto.Entity;

namespace NovoRumoProjeto.DAL.Event
{
    public class EventDAL : DAL, IEventDAL
    {
        private const string GET_EVENTS_PROC = "spGetEvents";
        private const string GET_EVENT_BY_ID_PROC = "spGetEventById";
        private const string INSERT_EVENT_PROC = "spInsertEvent";
        private const string UPDATE_EVENT_BY_ID_PROC = "spUpdateEventById";
        private const string DELETE_EVENT_PROC = "spDeleteEvent";

        public bool DeleteEvent(int eventID)
        {
            throw new NotImplementedException();
        }

        public List<EventEntity> Get()
        {
            throw new NotImplementedException();
        }

        public EventEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(EventEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(EventEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

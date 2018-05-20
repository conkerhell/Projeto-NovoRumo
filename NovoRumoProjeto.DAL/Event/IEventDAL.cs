
using NovoRumoProjeto.Entity;

namespace NovoRumoProjeto.DAL.Event
{
    public interface IEventDAL : IDAL<EventEntity>
    {
        bool DeleteEvent(int eventID);
        EventEntity GetNextEvent();
    }
}

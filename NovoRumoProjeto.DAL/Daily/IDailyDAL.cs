using NovoRumoProjeto.Entity;

namespace NovoRumoProjeto.DAL.Daily
{
    public interface IDailyDAL : IDAL<DailyEntity>
    {
        bool Delete(int id);
    }
}

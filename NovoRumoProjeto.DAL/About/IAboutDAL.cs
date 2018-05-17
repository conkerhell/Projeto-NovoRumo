using NovoRumoProjeto.Entity;

namespace NovoRumoProjeto.DAL.About
{
    public interface IAboutDAL : IDAL<AboutEntity>
    {
        bool Delete(int id);
    }
}

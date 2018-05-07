using NovoRumoProjeto.Entity;

namespace NovoRumoProjeto.DAL.About
{
    public interface IAboutDAL : IDAL<AboutEntity>
    {
        AboutEntity GetContact();
    }
}

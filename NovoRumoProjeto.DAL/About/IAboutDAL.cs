using NovoRumoProjeto.Entity;
using System.Collections.Generic;

namespace NovoRumoProjeto.DAL.About
{
    public interface IAboutDAL : IDAL<AboutEntity>
    {
        bool Delete(int id);
        List<AboutEntity> GetNewestAbout();
    }
}

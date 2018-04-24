using System.Collections.Generic;

namespace NovoRumoProjeto.DAL
{
    public interface IDAL<t>
    {
        bool Insert(t entity);
        bool Update(t entity);
        List<t> Get();
        t GetById(int id);
    }
}

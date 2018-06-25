using NovoRumoProjeto.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoRumoProjeto.DAL.Politics
{
    public interface IPoliticsDAL : IDAL<PoliticsEntity>
    {
        PoliticsEntity GetPolitics();
    }
}

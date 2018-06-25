using NovoRumoProjeto.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoRumoProjeto.DAL.Politics
{
    public interface IPolicyDAL : IDAL<PolicyEntity>
    {
        PolicyEntity GetPolitics();
    }
}

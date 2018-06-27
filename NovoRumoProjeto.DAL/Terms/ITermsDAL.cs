using NovoRumoProjeto.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoRumoProjeto.DAL.Terms
{
    public interface ITermsDAL: IDAL<TermsEntity>
    {
        TermsEntity GetTerms();
    }
}

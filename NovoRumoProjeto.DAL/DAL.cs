
using DataAccessLayer.Core;
using NovoRumoProjeto.Utilities;
using System.Configuration;

namespace NovoRumoProjeto.DAL
{
    public abstract class DAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings[Consts.CONNECTION_STRING].ConnectionString;
        public DataAccess dataAccess;

        public DAL()
        {
            dataAccess = new DataAccess(connectionString);
        }
    }
}

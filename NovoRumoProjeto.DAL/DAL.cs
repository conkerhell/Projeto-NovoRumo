
using DataAccessLayer.Core;
using NovoRumoProjeto.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace NovoRumoProjeto.DAL
{
    public abstract class DAL<t> : IDAL<t>
    {
        private string connectionString = ConfigurationManager.ConnectionStrings[Consts.CONNECTION_STRING].ConnectionString;
        public DataAccess dataAccess;

        public DAL()
        {
            dataAccess = new DataAccess(connectionString);
        }

        abstract public List<t> Get();

        abstract public t GetById(int id);

        abstract public bool Insert(t entity);

        abstract public bool Update(t entity);
    }
}

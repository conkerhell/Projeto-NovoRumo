using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovoRumoProjeto.Entity;

namespace NovoRumoProjeto.DAL.Politics
{
    public class PolicyDAL : DAL, IPolicyDAL
    {
        public const string TITLE_COLUMN = "Title";
        public const string DESCRIPTION_COLUMN = "Description";

        public const string GET_POLITICS_PROC = "spGETPolitics";
        public const string UPDATE_POLITICS_PROC = "spUpdatePolitics";

        public List<PolicyEntity> Get()
        {
            throw new NotImplementedException();
        }

        public PolicyEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(PolicyEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(PolicyEntity entity)
        {
            return dataAccess.ExecuteNonQuery(UPDATE_POLITICS_PROC,
                dataAccess.ParameterFactory.Create(TITLE_COLUMN, DbType.String, entity.Title, ParameterDirection.Input),
                dataAccess.ParameterFactory.Create(DESCRIPTION_COLUMN, DbType.String, entity.Description, ParameterDirection.Input)) == 1;
        }

        public PolicyEntity GetPolitics()
        {
            using (var result = dataAccess.ExecuteReader(GET_POLITICS_PROC))
            {
                PolicyEntity politics = new PolicyEntity();

                if (result.HasRows)
                {
                    if (result.Read())
                    {
                        politics.Title = result[TITLE_COLUMN].ToString();
                        politics.Description = result[DESCRIPTION_COLUMN].ToString();
                    }
                }

                return politics;
            }
        }
    }
}

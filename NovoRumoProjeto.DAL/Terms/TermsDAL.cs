using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovoRumoProjeto.Entity;

namespace NovoRumoProjeto.DAL.Terms
{
    public class TermsDAL: DAL, ITermsDAL
    {
        public const string TITLE_COLUMN = "Title";
        public const string DESCRIPTION_COLUMN = "Description";
        public const string TERM_ID_COLUMN = "TermID";

        public const string GET_TERMS_PROC = "spGetTerms";
        public const string UPDATE_TERMS_PROC = "spUpdateTerms";

        public List<TermsEntity> Get()
        {
            throw new NotImplementedException();
        }

        public TermsEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public TermsEntity GetTerms()
        {
            using (var result = dataAccess.ExecuteReader(GET_TERMS_PROC))
            {
                TermsEntity terms = new TermsEntity();

                if (result.HasRows)
                {
                    if (result.Read())
                    {
                        terms.TermID = Convert.ToInt32(result[TERM_ID_COLUMN]);
                        terms.Title = result[TITLE_COLUMN].ToString();
                        terms.Description = result[DESCRIPTION_COLUMN].ToString();
                    }
                }

                return terms;
            }
        }

        public bool Insert(TermsEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(TermsEntity entity)
        {
            return dataAccess.ExecuteNonQuery(UPDATE_TERMS_PROC,
                dataAccess.ParameterFactory.Create(TERM_ID_COLUMN, DbType.Int32, entity.TermID, ParameterDirection.Input),
                 dataAccess.ParameterFactory.Create(TITLE_COLUMN, DbType.String, entity.Title, ParameterDirection.Input),
                 dataAccess.ParameterFactory.Create(DESCRIPTION_COLUMN, DbType.String, entity.Description, ParameterDirection.Input)) == 1;
        }
    }
}

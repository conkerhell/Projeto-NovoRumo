using System;
using System.Collections.Generic;
using NovoRumoProjeto.Entity;
using System.Data;


namespace NovoRumoProjeto.DAL.About
{
    public class AboutDAL : DAL, IAboutDAL
    {
        private const string INSERT_ABOUT_PROC = "spInsertAbout";
        private const string GET_ABOUT_PROC = "spGetDaily";
        private const string GET_ABOUT_BY_ID_PROC = "spGetAboutByID";
        private const string DELETE_ABOUT_PROC = "spDeleteAbout";
        private const string UPDATE_ABOUT_PROC = "spUpdateAbout";

        private const string ABOUT_ID_COLUMN = "DailyID";
        private const string FILENAME_COLUMN = "Filename";
        private const string TITULO_COLUMN = "Titulo";
        private const string DESCRICAO_COLUMN = "Descricao";

        public List<AboutEntity> Get()
        {
            using (var result = dataAccess.ExecuteReader(GET_ABOUT_PROC))
            {
                var abouts = new List<AboutEntity>();

                if (result.HasRows)
                {
                    AboutEntity about;
                    while (result.Read())
                    {
                        about = new AboutEntity();
                        about.AboutID = Convert.ToInt32(result[ABOUT])
                    }
                }
            }
        }

        public AboutEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public AboutEntity GetContact()
        {
            throw new NotImplementedException();
        }

        public bool Insert(AboutEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(AboutEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

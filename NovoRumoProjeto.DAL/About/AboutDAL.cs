using System;
using System.Collections.Generic;
using NovoRumoProjeto.Entity;
using System.Data;


namespace NovoRumoProjeto.DAL.About
{
    public class AboutDAL : DAL, IAboutDAL
    {
        private const string INSERT_ABOUT_PROC = "spInsertAbout";
        private const string GET_ABOUT_PROC = "spGetAbout";
        private const string GET_ABOUT_BY_ID_PROC = "spGetAboutByID";
        private const string DELETE_ABOUT_PROC = "spDeleteAbout";
        private const string UPDATE_ABOUT_PROC = "spUpdateAbout";
        private const string GET_NEXT_ABOUT = "spGetNextAbout";

        private const string ABOUT_ID_COLUMN = "AboutID";
        private const string FILENAME_COLUMN = "Filename";
        private const string TITLE_COLUMN = "Title";
        private const string DESCRIPTION_COLUMN = "Description";

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
                        about.AboutID = Convert.ToInt32(result[ABOUT_ID_COLUMN]);
                        about.Title = Convert.ToString(result[TITLE_COLUMN]);
                        about.Description = Convert.ToString(result[DESCRIPTION_COLUMN]);
                        about.fileName = Convert.ToString(result[FILENAME_COLUMN]);
                    }
                }
                return abouts;
            }
        }

        public AboutEntity GetById(int id)
        {
            using (var result = dataAccess.ExecuteReader(GET_ABOUT_BY_ID_PROC,
                dataAccess.ParameterFactory.Create(ABOUT_ID_COLUMN, DbType.Int32, id, ParameterDirection.Input)))
            {

                var abouts = new AboutEntity();

                if (result.HasRows)
                {
                    if (result.Read())
                    {
                        abouts.AboutID = Convert.ToInt32(result[ABOUT_ID_COLUMN]);
                        abouts.Title = Convert.ToString(result[TITLE_COLUMN]);
                        abouts.Description = Convert.ToString(result[DESCRIPTION_COLUMN]);
                        abouts.fileName = Convert.ToString(result[FILENAME_COLUMN]);
                    }
                }

                return abouts;
            }
        }


        public bool Insert(AboutEntity entity)
        {
            return dataAccess.ExecuteNonQuery(INSERT_ABOUT_PROC,
                dataAccess.ParameterFactory.Create(TITLE_COLUMN, DbType.String, entity.Title, ParameterDirection.Input),
                dataAccess.ParameterFactory.Create(DESCRIPTION_COLUMN, DbType.String, entity.Description, ParameterDirection.Input),
                dataAccess.ParameterFactory.Create(FILENAME_COLUMN, DbType.String, entity.fileName, ParameterDirection.Input)) == 1;
        }

        public bool Update(AboutEntity entity)
        {
            return dataAccess.ExecuteNonQuery(UPDATE_ABOUT_PROC,
          dataAccess.ParameterFactory.Create(ABOUT_ID_COLUMN, DbType.Int32, entity.AboutID, ParameterDirection.Input),
          dataAccess.ParameterFactory.Create(FILENAME_COLUMN, DbType.String, entity.fileName, ParameterDirection.Input),
          dataAccess.ParameterFactory.Create(TITLE_COLUMN, DbType.String, entity.Title, ParameterDirection.Input),
          dataAccess.ParameterFactory.Create(DESCRIPTION_COLUMN, DbType.String, entity.Description, ParameterDirection.Input)) == 1;
        }

        public bool Delete(int id)
        {
            return dataAccess.ExecuteNonQuery(DELETE_ABOUT_PROC,
                dataAccess.ParameterFactory.Create(ABOUT_ID_COLUMN, DbType.Int32, id, ParameterDirection.Input)) == 1;
        }

        public AboutEntity GetNextAbout()
        {
            using (var result = dataAccess.ExecuteReader(GET_NEXT_ABOUT))
            {
                AboutEntity item = new AboutEntity();

                if (result.HasRows)
                {
                    if (result.Read())
                    {
                        item = new AboutEntity();
                        item.AboutID = Convert.ToInt32(result[ABOUT_ID_COLUMN]);
                        item.Title = Convert.ToString(result[TITLE_COLUMN]);
                        item.Description = Convert.ToString(result[DESCRIPTION_COLUMN]);
                        item.fileName = Convert.ToString(result[FILENAME_COLUMN]);
                    }
                }
                return item;
            }

        }
    }
}

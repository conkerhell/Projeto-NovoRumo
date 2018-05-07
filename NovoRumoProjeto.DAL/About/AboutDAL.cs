using System;
using System.Collections.Generic;
using NovoRumoProjeto.Entity;
using System.Data;


namespace NovoRumoProjeto.DAL.About
{
    public class AboutDAL: DAL, IAboutDAL
    {
        private const string INSERT_ABOUT_PROC = "spInsertAbout";
        private const string GET_ABOUT_PROC = "spGetDaily";
        private const string GET_ABOUT_BY_ID_PROC = "spGetAboutByID";
        private const string DELETE_ABOUT_PROC = "spDeleteAbout";
        private const string UPDATE_ABOUT_PROC = "spUpdateAbout";

        public List<AboutEntity> Get()
        {
            throw new NotImplementedException();
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

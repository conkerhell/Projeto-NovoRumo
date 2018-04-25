using System;
using System.Collections.Generic;
using NovoRumoProjeto.Entity;

namespace NovoRumoProjeto.DAL.Contact
{
    public class ContactDAL : DAL<ContactEntity>
    {
        public const string GET_CONTACT_PROC = "spGetContact";
        public const string UPDATE_CONTACT_PROC = "spUpdateContact";

        public override List<ContactEntity> Get()
        {
            throw new NotImplementedException();
        }

        public override ContactEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Insert(ContactEntity entity)
        {
            throw new NotImplementedException();
        }

        public override bool Update(ContactEntity entity)
        {
            throw new NotImplementedException();
            //return dataAccess.ExecuteNonQuery(UPDATE_CONTACT_PROC,
            //   dataAccess.ParameterFactory.Create(COLUMN_ABOUT_ID, DbType.Int32, entity.id, ParameterDirection.Input),
            // dataAccess.ParameterFactory.Create(COLUMN_DESCRIPTION, DbType.String, entity.Description, ParameterDirection.Input),
            // dataAccess.ParameterFactory.Create(COLUMN_EMAIL, DbType.String, entity.Email, ParameterDirection.Input),
            // dataAccess.ParameterFactory.Create(COLUMN_EXTRA_INFO, DbType.String, entity.ExtraInfo, ParameterDirection.Input),
            // dataAccess.ParameterFactory.Create(COLUMN_TITLE, DbType.String, entity.Title, ParameterDirection.Input),
            // dataAccess.ParameterFactory.Create(COLUMN_WHATSAPP_PHONE, DbType.String, entity.WhatsappPhone, ParameterDirection.Input)) == 1;
        }
    }
}

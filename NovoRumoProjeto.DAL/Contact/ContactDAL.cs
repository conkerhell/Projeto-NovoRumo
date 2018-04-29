using System;
using System.Collections.Generic;
using NovoRumoProjeto.Entity;
using System.Data;

namespace NovoRumoProjeto.DAL.Contact
{
    public class ContactDAL : DAL, IContactDAL
    {
        public const string TELEPHONE_COLUMN = "Telephone";
        public const string MOBILE_COLUMN = "Mobile";
        public const string SECONDARY_MOBILE_COLUMN = "SecondaryMobile";
        public const string ADDRESS_COLUMN = "Address";
        public const string CEP_COLUMN = "CEP";
        public const string EMAIL_COLUMN = "Email";

        public const string GET_CONTACT_PROC = "spGetContact";
        public const string UPDATE_CONTACT_PROC = "spUpdateContact";

        public List<ContactEntity> Get()
        {
            throw new NotImplementedException();
        }

        public ContactEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ContactEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(ContactEntity entity)
        {
            return dataAccess.ExecuteNonQuery(UPDATE_CONTACT_PROC,
               dataAccess.ParameterFactory.Create(TELEPHONE_COLUMN, DbType.String, entity.Telephone, ParameterDirection.Input),
             dataAccess.ParameterFactory.Create(MOBILE_COLUMN, DbType.String, entity.Mobile, ParameterDirection.Input),
             dataAccess.ParameterFactory.Create(SECONDARY_MOBILE_COLUMN, DbType.String, entity.SecondaryMobile, ParameterDirection.Input),
             dataAccess.ParameterFactory.Create(EMAIL_COLUMN, DbType.String, entity.Email, ParameterDirection.Input),
             dataAccess.ParameterFactory.Create(CEP_COLUMN, DbType.String, entity.CEP, ParameterDirection.Input),
             dataAccess.ParameterFactory.Create(ADDRESS_COLUMN, DbType.String, entity.Address, ParameterDirection.Input)) == 1;
        }

        public ContactEntity GetContact()
        {
            using (var result = dataAccess.ExecuteReader(GET_CONTACT_PROC))
            {
                ContactEntity contact = new ContactEntity();

                if (result.HasRows)
                {
                    if (result.Read())
                    {
                        contact.Address = result[ADDRESS_COLUMN].ToString();
                        contact.CEP = result[CEP_COLUMN].ToString();
                        contact.Email = result[EMAIL_COLUMN].ToString();
                        contact.Mobile = result[MOBILE_COLUMN].ToString();
                        contact.SecondaryMobile = result[SECONDARY_MOBILE_COLUMN].ToString();
                        contact.Telephone = result[TELEPHONE_COLUMN].ToString();
                    }
                }

                return contact;
            }
        }
    }
}

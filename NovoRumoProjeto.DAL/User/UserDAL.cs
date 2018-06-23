using System;
using System.Collections.Generic;
using System.Data;
using NovoRumoProjeto.Entity;

namespace NovoRumoProjeto.DAL.User
{
    public class UserDAL : DAL, IUserDAL
    {
        private const string INSERT_USER_PROC = "spInsertUser";
        private const string UPDATE_USER_PROC = "spUpdateUser";
        private const string GET_USER_BY_ID_PROC = "spGetUserById";

        private const string NAME_COLUMN = "Name";
        private const string USER_ID_COLUMN = "UserId";

        public List<UserEntity> Get()
        {
            throw new NotImplementedException();
        }

        public UserEntity GetById(int id)
        {
            using (var result = dataAccess.ExecuteReader(GET_USER_BY_ID_PROC,
                dataAccess.ParameterFactory.Create(USER_ID_COLUMN, DbType.Int32, id, ParameterDirection.Input)))
            {
                UserEntity item = new UserEntity();
                if (result.HasRows)
                {
                    if (result.Read())
                    {
                        item.UserID = Convert.ToInt32(result[USER_ID_COLUMN]);
                        item.Name = result[NAME_COLUMN].ToString();
                    }
                }

                return item;
            }
        }

        public bool Insert(UserEntity entity)
        {
            return dataAccess.ExecuteNonQuery(INSERT_USER_PROC,
                dataAccess.ParameterFactory.Create(USER_ID_COLUMN, DbType.Int32, entity.UserID, ParameterDirection.Input),
                dataAccess.ParameterFactory.Create(NAME_COLUMN, DbType.String, entity.Name, ParameterDirection.Input)) == 1;
        }

        public bool Update(UserEntity entity)
        {
            return dataAccess.ExecuteNonQuery(UPDATE_USER_PROC,
                dataAccess.ParameterFactory.Create(USER_ID_COLUMN, DbType.Int32, entity.UserID, ParameterDirection.Input),
                dataAccess.ParameterFactory.Create(NAME_COLUMN, DbType.String, entity.Name, ParameterDirection.Input)) == 1;
        }
    }
}
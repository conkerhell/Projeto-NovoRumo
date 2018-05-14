using System;
using System.Collections.Generic;
using System.Data;
using NovoRumoProjeto.Entity;

namespace NovoRumoProjeto.DAL.Daily
{
    public class DailyDAL : DAL, IDailyDAL
    {
        private const string GET_DAILY_PROC = "spGetDaily";
        private const string GET_DAILY_BY_ID_PROC = "spGetDailyById";
        private const string INSERT_DAILY_PROC = "spInsertDaily";
        private const string UPDATE_DAILY_PROC = "spUpdateDaily";
        private const string DELETE_DAILY_PROC = "spDeleteDaily";

        private const string DAILY_ID_COLUMN = "DailyID";
        private const string FILENAME_COLUMN = "Filename";
        private const string STATUS_COLUMN = "Status";

        public List<DailyEntity> Get()
        {
            using (var result = dataAccess.ExecuteReader(GET_DAILY_PROC))
            {
                var dailies = new List<DailyEntity>();

                if (result.HasRows)
                {
                    DailyEntity daily;
                    while (result.Read())
                    {
                        daily = new DailyEntity();
                        daily.DailyID = Convert.ToInt32(result[DAILY_ID_COLUMN]);
                        daily.fileName = result[FILENAME_COLUMN].ToString();
                        daily.Status = Convert.ToByte(result[STATUS_COLUMN]);
                        dailies.Add(daily);
                    }
                }

                return dailies;
            }
        }

        public DailyEntity GetById(int id)
        {
            using (var result = dataAccess.ExecuteReader(GET_DAILY_BY_ID_PROC,
                dataAccess.ParameterFactory.Create(DAILY_ID_COLUMN, DbType.Int32, id, ParameterDirection.Input)))
            {
                var daily = new DailyEntity();

                if (result.HasRows)
                {
                    if (result.Read())
                    {
                        daily.DailyID = Convert.ToInt32(result[DAILY_ID_COLUMN]);
                        daily.fileName = result[FILENAME_COLUMN].ToString();
                        daily.Status = Convert.ToByte(result[STATUS_COLUMN]);
                    }
                }

                return daily;
            }
        }

        public bool Insert(DailyEntity entity)
        {
            return dataAccess.ExecuteNonQuery(INSERT_DAILY_PROC,           
           dataAccess.ParameterFactory.Create(FILENAME_COLUMN, DbType.String, entity.fileName, ParameterDirection.Input),
           dataAccess.ParameterFactory.Create(STATUS_COLUMN, DbType.Byte, entity.Status, ParameterDirection.Input)) == 1;
        }

        public bool Update(DailyEntity entity)
        {
            return dataAccess.ExecuteNonQuery(UPDATE_DAILY_PROC,
          dataAccess.ParameterFactory.Create(DAILY_ID_COLUMN, DbType.Int32, entity.DailyID, ParameterDirection.Input),
          dataAccess.ParameterFactory.Create(FILENAME_COLUMN, DbType.String, entity.fileName, ParameterDirection.Input),
          dataAccess.ParameterFactory.Create(STATUS_COLUMN, DbType.Byte, entity.Status, ParameterDirection.Input)) == 1;
        }

        public bool Delete(int id)
        {
            return dataAccess.ExecuteNonQuery(DELETE_DAILY_PROC,
          dataAccess.ParameterFactory.Create(DAILY_ID_COLUMN, DbType.Int32, id, ParameterDirection.Input)) == 1;
        }
    }
}

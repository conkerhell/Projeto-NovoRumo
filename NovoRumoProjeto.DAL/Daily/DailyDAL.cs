using System;
using System.Collections.Generic;
using NovoRumoProjeto.Entity;

namespace NovoRumoProjeto.DAL.Daily
{
    public class DailyDAL : DAL, IDailyDAL
    {
        private const string INSERT_DAILY_PROC = "spInsertDaily";
        private const string GET_DAILY_PROC = "spGetDaily";
        private const string GET_DAILY_BY_ID_PROC = "spGetDailyByID";
        private const string DELETE_DAILY_PROC = "spDeleteDaily";
        private const string UPDATE_DAILY_PROC = "spUpdateDaily";

        public List<DailyEntity> Get()
        {
            throw new NotImplementedException();
        }

        public DailyEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(DailyEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(DailyEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

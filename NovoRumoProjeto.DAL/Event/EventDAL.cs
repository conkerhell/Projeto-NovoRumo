using System;
using System.Collections.Generic;
using System.Data;
using NovoRumoProjeto.Entity;

namespace NovoRumoProjeto.DAL.Event
{
    public class EventDAL : DAL, IEventDAL
    {
        private const string GET_EVENTS_PROC = "spGetEvents";
        private const string GET_EVENT_BY_ID_PROC = "spGetEventById";
        private const string GET_NEXT_EVENT = "spGetNextEvent";
        private const string INSERT_EVENT_PROC = "spInsertEvent";
        private const string UPDATE_EVENT_BY_ID_PROC = "spUpdateEvent";
        private const string DELETE_EVENT_PROC = "spDeleteEvent";

        private const string EVENT_ID_COLUMN = "EventID";
        private const string TITLE_COLUMN = "Title";
        private const string DESCRIPTION_COLUMN = "Description";
        private const string DATA_COLUMN = "Data";
        private const string ADDRESS_COLUMN = "Address";

        public bool DeleteEvent(int eventID)
        {
            return dataAccess.ExecuteNonQuery(DELETE_EVENT_PROC,
                dataAccess.ParameterFactory.Create(EVENT_ID_COLUMN, DbType.Int32, eventID, ParameterDirection.Input)) == 1;
        }

        public List<EventEntity> Get()
        {
            using (var result = dataAccess.ExecuteReader(GET_EVENTS_PROC))
            {
                var events = new List<EventEntity>();

                if (result.HasRows)
                {
                    EventEntity item;
                    while (result.Read())
                    {
                        item = new EventEntity();
                        item.EventID = Convert.ToInt32(result[EVENT_ID_COLUMN]);
                        item.Title = result[TITLE_COLUMN].ToString();
                        item.Description = result[DESCRIPTION_COLUMN].ToString();
                        item.Data = Convert.ToDateTime(result[DATA_COLUMN]);
                        item.Address = result[ADDRESS_COLUMN].ToString();
                        events.Add(item);
                    }
                }

                return events;
            }
        }

        public EventEntity GetById(int id)
        {
            using (var result = dataAccess.ExecuteReader(GET_EVENT_BY_ID_PROC,
                dataAccess.ParameterFactory.Create(EVENT_ID_COLUMN, DbType.Int32, id, ParameterDirection.Input)))
            {
                EventEntity item = new EventEntity();
                if (result.HasRows)
                {
                    if (result.Read())
                    {
                        item = new EventEntity();
                        item.EventID = Convert.ToInt32(result[EVENT_ID_COLUMN]);
                        item.Title = result[TITLE_COLUMN].ToString();
                        item.Description = result[DESCRIPTION_COLUMN].ToString();
                        item.Data = Convert.ToDateTime(result[DATA_COLUMN]);
                        item.Address = result[ADDRESS_COLUMN].ToString();
                    }
                }

                return item;
            }
        }

        public EventEntity GetNextEvent()
        {
            using (var result = dataAccess.ExecuteReader(GET_NEXT_EVENT))
            {
                EventEntity item = null;
                if (result.HasRows)
                {
                    item = new EventEntity();
                    if (result.Read())
                    {
                        item = new EventEntity();
                        item.EventID = Convert.ToInt32(result[EVENT_ID_COLUMN]);
                        item.Title = result[TITLE_COLUMN].ToString();
                        item.Description = result[DESCRIPTION_COLUMN].ToString();
                        item.Data = Convert.ToDateTime(result[DATA_COLUMN]);
                        item.Address = result[ADDRESS_COLUMN].ToString();
                    }
                }

                return item;
            }
        }

        public bool Insert(EventEntity entity)
        {
            return dataAccess.ExecuteNonQuery(INSERT_EVENT_PROC,
                dataAccess.ParameterFactory.Create(TITLE_COLUMN, DbType.String, entity.Title, ParameterDirection.Input),
                dataAccess.ParameterFactory.Create(DESCRIPTION_COLUMN, DbType.String, entity.Description, ParameterDirection.Input),
                dataAccess.ParameterFactory.Create(DATA_COLUMN, DbType.DateTime, entity.Data, ParameterDirection.Input),
                dataAccess.ParameterFactory.Create(ADDRESS_COLUMN, DbType.String, entity.Address, ParameterDirection.Input)) == 1;
        }

        public bool Update(EventEntity entity)
        {
            return dataAccess.ExecuteNonQuery(UPDATE_EVENT_BY_ID_PROC,
                dataAccess.ParameterFactory.Create(EVENT_ID_COLUMN, DbType.Int32, entity.EventID, ParameterDirection.Input),
                dataAccess.ParameterFactory.Create(TITLE_COLUMN, DbType.String, entity.Title, ParameterDirection.Input),
                dataAccess.ParameterFactory.Create(DESCRIPTION_COLUMN, DbType.String, entity.Description, ParameterDirection.Input),
                dataAccess.ParameterFactory.Create(DATA_COLUMN, DbType.DateTime, entity.Data, ParameterDirection.Input),
                dataAccess.ParameterFactory.Create(ADDRESS_COLUMN, DbType.String, entity.Address, ParameterDirection.Input)) == 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovoRumoProjeto.Entity;

namespace NovoRumoProjeto.DAL.Donation
{
    public class DonationDAL : DAL, IDonationDAL
    {
        private const string INSERT_ORDER_PROC = "spInsertOrder";
        private const string GET_ORDER_PROC = "spGetOrders";
        private const string GET_ORDER_BY_ID_PROC = "spGetOrderById";
        private const string UPDATE_ORDER_PROC = "spUpdateOrder";

        private const string ORDER_ID_COLUMN = "OrderID";
        private const string TYPE_ID_COLUMN = "TypeId";
        private const string USER_ID_COLUMN = "UserId";
        private const string NOTIFICATION_CODE_COLUMN = "NotificationCode";
        private const string PAYPAL_GUID_COLUMN = "PaypalGuid";
        private const string TOTAL_COLUMN = "Total";
        private const string RECORD_DATE_COLUMN = "RecordDate";

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<DonationEntity> GetDonations()
        {
            using (var result = dataAccess.ExecuteReader(GET_ORDER_PROC))
            {
                var donations = new List<DonationEntity>();
                if (result.HasRows)
                {
                    DonationEntity donation;
                    while (result.Read())
                    {
                        donation = new DonationEntity();
                        donation.OrderID = Convert.ToInt32(result[ORDER_ID_COLUMN]);
                        donation.TypeId = Convert.ToInt32(result[TYPE_ID_COLUMN]);
                        donation.UserId = Convert.ToInt32(result[USER_ID_COLUMN]);
                        donation.NotificationCode = Convert.ToString(result[NOTIFICATION_CODE_COLUMN]);
                        donation.PaypalGuid = Convert.ToString(result[PAYPAL_GUID_COLUMN]);
                        donation.Total = Convert.ToInt32(result[TOTAL_COLUMN]);
                        donation.RecordDate = Convert.ToDateTime(result[RECORD_DATE_COLUMN]);
                        donations.Add(donation);
                    }
                }
                return donations;
            }
        }

        public DonationEntity GetById(int id)
        {
            throw new NotImplementedException();
        }


        public bool Insert(DonationEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(DonationEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<DonationEntity> Get()
        {
            throw new NotImplementedException();
        }
    }
}

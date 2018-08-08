using NovoRumoProjeto.DAL.Order;
using System;
using System.ComponentModel.DataAnnotations;

namespace NovoRumoProjeto.Areas.Admin.Models
{
    public class AidViewModel
    {
        [Display(Name =  "OrdemID")]
        public int OrderId { get; set; }

        public int TypeId { get; set; }

        public UserViewModel User { get; set; }

        [Display(Name = "Codigo de Notificação")]
        public string NotificationCode { get; set; }

        [Display(Name = "PaypalGUID")]
        public string PaypalGuid { get; set; }

        [Display(Name = "Total")]
        public decimal Total { get; set; }

        public DateTime? RecordDate { get; set; }

        public string Status { get; set; }

        public AidViewModel Detail()
        {
            IOrderDAL donationDAL = new OrderDAL();
            var entity = donationDAL.GetById(OrderId);

            NotificationCode = entity.NotificationCode;
            PaypalGuid = entity.PaypalGuid;
            Total = entity.Total;
            RecordDate = entity.RecordDate;

            return this;
        }
    }

    public class UserViewModel
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
    }
}
using NovoRumoProjeto.DAL.Order;
using NovoRumoProjeto.Utilities.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NovoRumoProjeto.Areas.Admin.Models
{
    public class AidViewModel
    {
        [Display(Name =  "Id")]
        public int OrderId { get; set; }

        [Display(Name = "Codigo Pagseguro")]
        public string NotificationCode { get; set; }

        [Display(Name = "Código Paypal")]
        public string PaypalGuid { get; set; }

        [Display(Name = "Total")]
        public decimal Total { get; set; }

        [Display(Name = "Data de início")]
        public DateTime? RecordDate { get; set; }

        public UserViewModel User { get; set; }

        public List<StatusViewModel> Status { get; set; }

        public AidViewModel Detail()
        {
            IOrderDAL orderDAL = new OrderDAL();
            var entity = orderDAL.GetById(OrderId);

            NotificationCode = entity.NotificationCode;
            PaypalGuid = entity.PaypalGuid;
            Total = entity.Total;
            RecordDate = entity.RecordDate;

            User = new UserViewModel();
            User.Email = entity.User.Email;
            User.Name = entity.User.Name;
            User.Lastname = entity.User.Lastname;


            var entityStatus = orderDAL.GetOrderStatusById(OrderId);
            foreach (var item in entityStatus)
            {
                Status.Add(new StatusViewModel
                {
                    RecordDate = item.RecordDate,
                    Status = ((Enums.PaymentStatus)item.Status).ToString()
                });
            }

            return this;
        }
    }

    public class UserViewModel
    {
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Sobrenome")]
        public string Lastname { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class StatusViewModel
    {
        public string Status { get; set; }
        public DateTime RecordDate { get; set; }
    }
}
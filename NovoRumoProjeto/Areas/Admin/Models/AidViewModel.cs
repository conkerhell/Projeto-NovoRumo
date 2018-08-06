using NovoRumoProjeto.DAL.Order;
using System;
using System.ComponentModel.DataAnnotations;

namespace NovoRumoProjeto.Areas.Admin.Models
{
    public class AidViewModel
    {
        [Display(Name =  "OrdemID")]
        public int OrderId { get; set; }

        [Display(Name ="Tipo")]
        public int TypeId { get; set; }

        [Display(Name = "UsuarioID")]
        public int UserId { get; set; }

        [Display(Name = "Codigo de Notificação")]
        public string NotificationCode { get; set; }

        [Display(Name = "PaypalGUID")]
        public string PaypalGuid { get; set; }

        [Display(Name = "Total")]
        public decimal Total { get; set; }

        [Display(Name = "Data de gravação")]
        public DateTime? RecordDate { get; set; }

        public string Status { get; set; }

        public AidViewModel Detail()
        {
            IOrderDAL donationDAL = new OrderDAL();
            var entity = donationDAL.GetById(UserId);

            //UserId = entity.UserId //TODO: Deve retornar o nome e outros dados do cliente
            NotificationCode = entity.NotificationCode;
            PaypalGuid = entity.PaypalGuid;
            Total = entity.Total;
            RecordDate = entity.RecordDate;

            return this;
        }
    }
}
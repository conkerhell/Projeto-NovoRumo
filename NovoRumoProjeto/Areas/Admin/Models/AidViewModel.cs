using NovoRumoProjeto.DAL.Donation;
using NovoRumoProjeto.Utilities;
using NovoRumoProjeto.Utilities.Validation;
using Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Mvc;

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

        public AidViewModel Detail()
        {
            IDonationDAL donationDAL = new DonationDAL();
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
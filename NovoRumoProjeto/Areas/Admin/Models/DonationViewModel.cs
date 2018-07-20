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
    public class DonationViewModel
    {
        public int OrderId { get; set; }
        public int TypeId { get; set; }
        public int UserId { get; set; }
        public string NotificationCode { get; set; }
        public string PaypalGuid { get; set; }
        public decimal Total { get; set; }
        public DateTime? RecordDate { get; set; }


    }
}
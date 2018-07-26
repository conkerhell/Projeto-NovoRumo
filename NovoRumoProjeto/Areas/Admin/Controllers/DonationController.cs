using NovoRumoProjeto.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NovoRumoProjeto.Areas.Admin.Models;
using NovoRumoProjeto.DAL.Donation;

namespace NovoRumoProjeto.Areas.Admin.Controllers
{
    [Authorize(Roles = Consts.ADMIN_ROLE)]
    public class DonationController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var model = new List<DonationViewModel>();
            IDonationDAL donationDAL = new DonationDAL();
            var entity = donationDAL.Get();

            foreach (var item in entity)
            {
                model.Add(new DonationViewModel()
                {
                    OrderId = item.OrderID,
                    TypeId = item.TypeId,
                    UserId = item.UserId,
                    NotificationCode = item.NotificationCode,
                    PaypalGuid = item.PaypalGuid,
                    Total = item.Total,
                    RecordDate = item.RecordDate
                    
                    
                });
            }
            return View(model);
        }
        
        [HttpGet]
        public ActionResult Details(int? id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit()
        {
            return View();
        }
    }
}

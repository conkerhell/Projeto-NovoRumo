using NovoRumoProjeto.Utilities;
using System.Collections.Generic;
using System.Web.Mvc;
using NovoRumoProjeto.Areas.Admin.Models;
using NovoRumoProjeto.DAL.Donation;

namespace NovoRumoProjeto.Areas.Admin.Controllers
{
    [Authorize(Roles = Consts.ADMIN_ROLE)]
    public class AidController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var model = new List<AidViewModel>();
            IDonationDAL donationDAL = new DonationDAL();
            var entity = donationDAL.Get();

            foreach (var item in entity)
            {
                model.Add(new AidViewModel()
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
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }

            var model = new AidViewModel();
            model.OrderId = id.Value;
            return View(model.Detail());
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }

            var model = new AidViewModel();
            model.OrderId = id.Value;
            return View(model.Detail());
        }
    }
}

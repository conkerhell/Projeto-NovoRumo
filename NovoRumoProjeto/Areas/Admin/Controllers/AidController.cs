using NovoRumoProjeto.Utilities;
using System.Collections.Generic;
using System.Web.Mvc;
using NovoRumoProjeto.Areas.Admin.Models;
using NovoRumoProjeto.DAL.Order;

namespace NovoRumoProjeto.Areas.Admin.Controllers
{
    [Authorize(Roles = Consts.ADMIN_ROLE)]
    public class AidController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var model = new List<AidViewModel>();
            IOrderDAL orderDAL = new OrderDAL();
            var entity = orderDAL.GetDonations();

            foreach (var item in entity)
            {
                model.Add(new AidViewModel()
                {
                    OrderId = item.OrderId,
                    NotificationCode = item.NotificationCode,
                    PaypalGuid = item.PaypalGuid,
                    Total = item.Total,
                    RecordDate = item.RecordDate,
                    User = new UserViewModel
                    {
                        Name = item.User.Name,
                        Lastname = item.User.Lastname,
                        Email = item.User.Email,
                    }
                });
            }
            return View(model);
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

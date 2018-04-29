using NovoRumoProjeto.Areas.Admin.Models;
using NovoRumoProjeto.Utilities;
using System.Web.Mvc;
namespace NovoRumoProjeto.Areas.Admin.Controllers
{
    public class DailyController: Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
           
            return View();
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var model = new DailyViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(DailyViewModel model)
        {
            return View(model);
        }
    }
}
using NovoRumoProjeto.Areas.Admin.Models;
using NovoRumoProjeto.Utilities;
using System.Web.Mvc;
namespace NovoRumoProjeto.Areas.Admin.Controllers
{
    public class DiaController: Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
           
            return View();
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var model = new DiaViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(DiaViewModel model)
        {
            return View(model);
        }
    }
}
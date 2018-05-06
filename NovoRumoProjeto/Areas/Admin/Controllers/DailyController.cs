using NovoRumoProjeto.Areas.Admin.Models;
using NovoRumoProjeto.Utilities;
using NovoRumoProjeto.Utilities.Extensions;
using System.Collections.Generic;
using System.Web.Mvc;
namespace NovoRumoProjeto.Areas.Admin.Controllers
{
    public class DailyController: Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var model = new List<DailyViewModel>();

            model.Add(new DailyViewModel()
            {
                ID = 1,
                displayFileName = "teste.jpg".GetImagePath()
            });

            return View(model);
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
            if (!ModelState.IsValid || !model.IsFileValid)
            {
                return View(model);
            }

            var status = model.SaveFile();

            return View(model);
        }
    }
}
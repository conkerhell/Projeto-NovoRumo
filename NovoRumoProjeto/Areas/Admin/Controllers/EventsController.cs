using NovoRumoProjeto.Areas.Admin.Models;
using NovoRumoProjeto.Utilities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace NovoRumoProjeto.Areas.Admin.Controllers
{
    [Authorize(Roles = Consts.ADMIN_ROLE)]
    public class EventsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var model = new List<EventViewModel>();

            model.Add(new EventViewModel()
            {
                Title = "Bazar beneficiente",
                Description = "Lorem ipsum dolores"
            });

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new EventViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(EventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
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

            var model = new EventViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return View(model);
        }
    }
}
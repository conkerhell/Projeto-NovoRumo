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
            return View();
        }

        [HttpPost]
        public ActionResult Add(EventViewModel model)
        {
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var model = new EventViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EventViewModel model)
        {
            return View(model);
        }
    }
}
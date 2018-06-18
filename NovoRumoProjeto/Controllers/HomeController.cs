using NovoRumoProjeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovoRumoProjeto.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult About()
        {
            var model = new AboutViewModel();
            var list = model.GetNewestAbout();
            return PartialView(list);
        }

        [HttpGet]
        public PartialViewResult Donate()
        {
            var model = new LoginViewModel();
            return PartialView(model);
        }

        [HttpGet]
        public PartialViewResult Daily()
        {
            var model = new DailyViewModel();
            var list = model.Get();
            return PartialView(list);
        }

        [HttpGet]
        public PartialViewResult Event()
        {
            var model = new EventViewModel();
            model.GetNextEvent();
            return PartialView(model);
        }

        [HttpGet]
        public PartialViewResult Contact()
        {
            var model = new ContactViewModel();
            model.Get();
            return PartialView(model);
        }
    }
}
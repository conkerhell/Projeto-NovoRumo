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
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult Daily()
        {
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult Evento()
        {
            var model = new EventViewModel();
            model.GetNextEvent();
            return PartialView(model);
        }

        [HttpGet]
        public PartialViewResult Contact()
        {
            return PartialView();
        }
    }
}
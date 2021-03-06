﻿using NovoRumoProjeto.Models;
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
            var list = model.Get();
            return PartialView(list);
        }

        [HttpGet]
        public PartialViewResult Donate()
        {
            return PartialView();
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
            var hasNextEvent = model.CheckAndGetNextEvent();

            if (hasNextEvent)
            {
                return PartialView(model);
            }
            else
            {
                return PartialView("NoNextEvent");
            }
        }

        [HttpGet]
        public PartialViewResult Contact()
        {
            var model = new ContactViewModel();
            model.Get();
            model.Map = "https://www.google.com.br/maps/place/R.+Papa+Paulo+VI,+182+-+Vila+Thais,+Atibaia+-+SP,+12942-120/data=!4m2!3m1!1s0x94cec0e1a812ed13:0x6da17955b6c2899f?sa=X&ved=2ahUKEwiWnJyTsrjdAhXGk5AKHbNSAO0Q8gEwAHoECAQQAQ";
            return PartialView(model);
        }
    }
}
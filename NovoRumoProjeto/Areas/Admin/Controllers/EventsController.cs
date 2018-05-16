using NovoRumoProjeto.Areas.Admin.Models;
using NovoRumoProjeto.DAL.Event;
using NovoRumoProjeto.Entity;
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

            IEventDAL eventDAL = new EventDAL();
            var entity = eventDAL.Get();

            foreach (var item in entity)
            {
                model.Add(new EventViewModel()
                {
                    ID = item.EventID,
                    Title = item.Title,
                    Description = item.Description,
                    Data = item.Data,
                    Address = item.Address
                });
            }

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

            IEventDAL eventDAL = new EventDAL();

            var status = eventDAL.Insert(new EventEntity()
            {
                Title = model.Title,
                Description = model.Description,
                Data = model.Data.Value,
                Address = model.Address
            });

            if (status)
            {
                return RedirectToAction("Index");
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

            IEventDAL eventDAL = new EventDAL();

            var entity = eventDAL.GetById(id.Value);
            var model = new EventViewModel();

            model.ID = entity.EventID;
            model.Title = entity.Title;
            model.Description = entity.Description;
            model.Address = entity.Address;
            model.Data = entity.Data;           
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            IEventDAL eventDAL = new EventDAL();
            var status = eventDAL.Update(new EventEntity()
            {
                EventID = model.ID,
                Title = model.Title,
                Description = model.Description,
                Address = model.Address,
                Data = model.Data.Value
            });

            if (status)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
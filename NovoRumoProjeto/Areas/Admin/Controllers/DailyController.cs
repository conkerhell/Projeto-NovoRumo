using NovoRumoProjeto.Areas.Admin.Models;
using NovoRumoProjeto.DAL.Daily;
using NovoRumoProjeto.Entity;
using NovoRumoProjeto.Utilities;
using NovoRumoProjeto.Utilities.Extensions;
using Resources;
using System.Collections.Generic;
using System.Web.Mvc;
namespace NovoRumoProjeto.Areas.Admin.Controllers
{
    [Authorize(Roles = Consts.ADMIN_ROLE)]
    public class DailyController : Controller
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
        public ActionResult Add()
        {
            return View(new DailyViewModel());
        }

        [HttpPost]
        public ActionResult Add(DailyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            IDailyDAL dailyDAL = new DailyDAL();
            var status = dailyDAL.Insert(new DailyEntity()
            {
                fileName = model.displayFileName
            });

            if (!status)
            {
                ModelState.AddModelError(string.Empty, LocalizedMessages.UnexpectedError);
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }

            IDailyDAL dailyDAL = new DailyDAL();
            var entity = dailyDAL.GetById(id.Value);

            var model = new DailyViewModel();
            model.ID = entity.DailyID;
            model.displayFileName = entity.fileName;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(DailyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            IDailyDAL dailyDAL = new DailyDAL();

            var status = model.SaveFile() &&
                dailyDAL.Update(new DailyEntity()
                {
                    DailyID = model.ID,
                    fileName = model.displayFileName
                });

            if (!status)
            {
                ModelState.AddModelError(string.Empty, LocalizedMessages.UnexpectedError);
                return View(model);
            }
            return RedirectToAction("Index");
        }
    }
}
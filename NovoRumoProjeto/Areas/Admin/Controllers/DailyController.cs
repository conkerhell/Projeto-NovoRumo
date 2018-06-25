using NovoRumoProjeto.Areas.Admin.Models;
using NovoRumoProjeto.DAL.Daily;
using NovoRumoProjeto.Entity;
using NovoRumoProjeto.Utilities;
using NovoRumoProjeto.Utilities.Extensions;
using Resources;
using System.Collections.Generic;
using System.Web.Mvc;
using Vereyon.Web;

namespace NovoRumoProjeto.Areas.Admin.Controllers
{
    [Authorize(Roles = Consts.ADMIN_ROLE)]
    public class DailyController : Controller
    {
        private const string IMAGE_PATH = Consts.DAILY_IMAGE_PATH;

        [HttpGet]
        public ActionResult Index()
        {
            var model = new List<DailyViewModel>();

            IDailyDAL dailyDAL = new DailyDAL();
            var entity = dailyDAL.Get();

            foreach (var item in entity)
            {
                model.Add(new DailyViewModel()
                {
                    ID = item.DailyID,
                    displayFileName = item.fileName.GetImagePath(IMAGE_PATH)
                });
            }

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

            var status = model.SaveFile() &&
                dailyDAL.Insert(new DailyEntity()
                {
                    Status = 1,
                    fileName = model.displayFileName
                });

            if (!status)
            {
                FlashMessage.Danger(LocalizedMessages.FailedTitle, LocalizedMessages.UnexpectedError);
                return View(model);
            }

            FlashMessage.Confirmation(LocalizedMessages.SuccessTitle, LocalizedMessages.operationSucced);
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
            model.displayFileName = entity.fileName.GetImagePath(IMAGE_PATH);

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
                FlashMessage.Danger(LocalizedMessages.FailedTitle, LocalizedMessages.UnexpectedError);
                return View(model);
            }

            FlashMessage.Confirmation(LocalizedMessages.SuccessTitle, LocalizedMessages.operationSucced);
            return RedirectToAction("Index");
        }
    }
}
using NovoRumoProjeto.Areas.Admin.Models;
using NovoRumoProjeto.DAL.Daily;
using NovoRumoProjeto.Entity;
using NovoRumoProjeto.Utilities;
using NovoRumoProjeto.Utilities.Extensions;
using Resources;
using System;
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
                    displayFileName = item.fileName.GetImagePath(IMAGE_PATH),
                    Title = item.Title
                });
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new DailyViewModel();
            model.Data = DateTime.Now;
            return View();
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
                    fileName = model.displayFileName,
                    Data = model.Data,
                    Title = model.Title,
                    Description = model.Description,
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
            model.Title = entity.Title;
            model.Description = entity.Description;
            model.Data = entity.Data;

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
                    fileName = model.displayFileName,
                    Data = model.Data,
                    Title = model.Title,
                    Description = model.Description
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
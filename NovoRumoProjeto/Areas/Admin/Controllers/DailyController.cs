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
        public ActionResult Edit(int id)
        {
            IDailyDAL dailyDAL = new DailyDAL();
            var entity = dailyDAL.GetById(id);

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

            var status = model.SaveFile();
            status = status && dailyDAL.Update(new DailyEntity()
            {
                DailyID = model.ID,
                fileName = model.displayFileName
            });

            if (!status)
            {
                ModelState.AddModelError(string.Empty, LocalizedMessages.UnexpectedError);
            }

            return View(model);
        }
    }
}
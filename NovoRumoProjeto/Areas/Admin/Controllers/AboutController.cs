using NovoRumoProjeto.Areas.Admin.Models;
using NovoRumoProjeto.DAL.About;
using NovoRumoProjeto.Entity;
using NovoRumoProjeto.Utilities;
using NovoRumoProjeto.Utilities.Extensions;
using Vereyon.Web;
using Resources;
using System.Collections.Generic;
using System.Web.Mvc;

namespace NovoRumoProjeto.Areas.Admin.Controllers
{
    [Authorize(Roles = Consts.ADMIN_ROLE)]
    public class AboutController : Controller
    {
        private const string IMAGE_PATH = Consts.ABOUT_IMAGE_PATH;

        [HttpGet]
        public ActionResult Index()
        {
            var model = new List<AboutViewModel>();
            IAboutDAL aboutDAL = new AboutDAL();
            var entity = aboutDAL.Get();

            foreach (var item in entity)
            {

                model.Add(new AboutViewModel()
                {
                    ID = item.AboutID,
                    displayFileName = item.fileName.GetImagePath(IMAGE_PATH)
                });
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
            IAboutDAL aboutDAL = new AboutDAL();
            var entity = aboutDAL.GetById(id.Value);

            var model = new AboutViewModel();
            model.ID = entity.AboutID;
            model.displayFileName = entity.fileName;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AboutViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            IAboutDAL aboutDAL = new AboutDAL();

            var status = model.SaveFile() &&
                aboutDAL.Update(new AboutEntity()
                {
                    AboutID = model.ID,
                    Title = model.Title,
                    Description = model.Description,
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
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AboutViewModel model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }
            IAboutDAL aboutDAL = new AboutDAL();
            var status = aboutDAL.Insert(new AboutEntity()
            {
                fileName = model.displayFileName
            });

            if (!status)
            {
                ModelState.AddModelError(string.Empty, LocalizedMessages.UnexpectedError);
                return View(model);
            }
            FlashMessage.Confirmation("sucesso!");
            return RedirectToAction("Index");
        }
    }
}
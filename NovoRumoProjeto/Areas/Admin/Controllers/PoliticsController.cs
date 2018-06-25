using NovoRumoProjeto.Areas.Admin.Models;
using NovoRumoProjeto.DAL.Politics;
using NovoRumoProjeto.Entity;
using NovoRumoProjeto.Utilities;
using System.Web.Mvc;

namespace NovoRumoProjeto.Areas.Admin.Controllers
{
    public class PoliticsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            IPoliticsDAL politicsDAL = new PoliticsDAL();
            var entity = politicsDAL.GetPolitics();
            return View(new PoliticsViewModel()
            {
                Title = entity.Title,
                Description = entity.Description
            });
        }
        [HttpGet]
        public ActionResult Edit()
        {
            IPoliticsDAL politicsDAL = new PoliticsDAL();
            var entity = politicsDAL.GetPolitics();
            return View(new PoliticsViewModel()
            {
                Title = entity.Title,
                Description = entity.Description
            });
        }

        [HttpPost]
        public ActionResult Edit(PoliticsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            IPoliticsDAL politicsDAL = new PoliticsDAL();
            politicsDAL.Update(new PoliticsEntity()
            {
                Title = model.Title,
                Description = model.Description
            });

            return RedirectToAction("index");
        }
    }
}
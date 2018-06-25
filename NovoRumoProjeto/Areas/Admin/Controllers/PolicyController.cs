using NovoRumoProjeto.Areas.Admin.Models;
using NovoRumoProjeto.DAL.Politics;
using NovoRumoProjeto.Entity;
using NovoRumoProjeto.Utilities;
using System.Web.Mvc;

namespace NovoRumoProjeto.Areas.Admin.Controllers
{
    public class PolicyController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            IPolicyDAL politicsDAL = new PolicyDAL();
            var entity = politicsDAL.GetPolitics();
            return View(new PolicyViewModel()
            {
                Title = entity.Title,
                Description = entity.Description
            });
        }
        [HttpGet]
        public ActionResult Edit()
        {
            IPolicyDAL politicsDAL = new PolicyDAL();
            var entity = politicsDAL.GetPolitics();
            return View(new PolicyViewModel()
            {
                Title = entity.Title,
                Description = entity.Description
            });
        }

        [HttpPost]
        public ActionResult Edit(PolicyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            IPolicyDAL politicsDAL = new PolicyDAL();
            politicsDAL.Update(new PolicyEntity()
            {
                Title = model.Title,
                Description = model.Description
            });

            return RedirectToAction("index");
        }
    }
}
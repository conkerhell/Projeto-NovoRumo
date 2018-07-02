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
            var entity = politicsDAL.GetPolicy();
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
            var entity = politicsDAL.GetPolicy();
            return View(new PolicyViewModel()
            {
                PolicyId = entity.PolicyID,
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
            var status = politicsDAL.Update(new PolicyEntity()
            {
                PolicyID = model.PolicyId,
                Title = model.Title,
                Description = model.Description
            });

            if (status)
            {
                return RedirectToAction("index");
            }
            return View();
        }
    }
}
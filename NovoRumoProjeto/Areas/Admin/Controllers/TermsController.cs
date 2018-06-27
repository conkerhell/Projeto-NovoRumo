using NovoRumoProjeto.Areas.Admin.Models;
using NovoRumoProjeto.DAL.Terms;
using NovoRumoProjeto.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovoRumoProjeto.Areas.Admin.Controllers
{
    public class TermsController: Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ITermsDAL termsDAL = new TermsDAL();
            var entity = termsDAL.GetTerms();
            return View(new TermsViewModel()
            {
                Title = entity.Title,
                Description = entity.Description
            });
        }
        [HttpGet]
        public ActionResult Edit()
        {
            ITermsDAL termsDAL = new TermsDAL();
            var entity = termsDAL.GetTerms();
            return View(new TermsViewModel()
            {
                Title = entity.Title,
                Description = entity.Description
            });
        }

        [HttpPost]
        public ActionResult Edit(TermsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ITermsDAL termsDAL = new TermsDAL();
            termsDAL.Update(new TermsEntity()
            {
                Title = model.Title,
                Description = model.Description
            });

            return RedirectToAction("index");
        }
    }
}
using NovoRumoProjeto.Areas.Admin.Models;
using System.Web.Mvc;

namespace NovoRumoProjeto.Areas.Admin.Controllers
{
    public class AboutController : Controller
    {
        // GET: Admin/About
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit()
        {
            var model = new AboutViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AboutViewModel model)
        {
            return View(model);
        }


        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Add(AboutViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        DAL.AddAbout(new);
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return View(model);
        //    }
        //}
    }
}
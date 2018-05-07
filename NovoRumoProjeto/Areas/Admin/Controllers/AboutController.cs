using NovoRumoProjeto.Areas.Admin.Models;
using NovoRumoProjeto.DAL.About;
using NovoRumoProjeto.Entity;
using NovoRumoProjeto.Utilities;
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
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            IAboutDAL aboutDAL = new AboutDAL();
            var entity = aboutDAL.GetContact();
            return View(new AboutViewModel()
            {
                Title = entity.Titulo,
                Description = entity.Description
            }
                );
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
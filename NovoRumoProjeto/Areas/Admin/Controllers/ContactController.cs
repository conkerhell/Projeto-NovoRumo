using NovoRumoProjeto.Areas.Admin.Models;
using NovoRumoProjeto.DAL.Contact;
using NovoRumoProjeto.Entity;
using NovoRumoProjeto.Utilities;
using System.Web.Mvc;

namespace NovoRumoProjeto.Areas.Admin.Controllers
{
    [Authorize(Roles = Consts.ADMIN_ROLE)]
    public class ContactController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            IContactDAL contactDAL = new ContactDAL();
            var entity = contactDAL.GetContact();
            return View(new ContactViewModel()
            {
                Email = entity.Email,
                Mobile = entity.Mobile,
                Telephone = entity.Telephone,
                SecondaryMobile = entity.SecondaryMobile,
                Address = entity.Address,
                CEP = entity.CEP
            });
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var model = new ContactViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            IContactDAL contactDAL = new ContactDAL();
            contactDAL.Update(new ContactEntity()
            {
                Telephone = model.Telephone,
                Mobile = model.Mobile,
                SecondaryMobile = model.SecondaryMobile,
                Email = model.Email,
                CEP = model.CEP,
                Address = model.Address
            });

            return RedirectToAction("index");
        }
    }
}
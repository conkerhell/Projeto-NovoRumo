using NovoRumoProjeto.Areas.Admin.Models;
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
            return View(new ContactViewModel()
            {
                Email = "contato@novorumoatibaia.com.br",
                Mobile = "(11) 1234-5667",
                Telephone = "(11) 1234-5673",
                Endereço = "Rua Papa Paulo VI, 182 <br> Vila Thais - Atibaia, SP",
                CEP = "12345-789"
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

            return RedirectToAction("index");
        }
    }
}
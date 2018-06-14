using NovoRumoProjeto.Models;
using System.Web.Mvc;

namespace NovoRumoProjeto.Controllers
{
    public class DonationController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            return RedirectToAction("Checkout");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            return RedirectToAction("Checkout");
        }

        [HttpGet]
        public ActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Checkout(DonationViewModel model)
        {
            return View(model);
        }

        [HttpGet]
        public ActionResult Success()
        {
            return View();
        }

        [HttpGet]
        [ActionName("politica-de-privacidade")]
        public ActionResult PoliticaDePrivacidade()
        {
            return View();
        }

        [HttpGet]
        [ActionName("termos-de-uso")]
        public ActionResult TermosDeUso()
        {
            return View();
        }
    }
}
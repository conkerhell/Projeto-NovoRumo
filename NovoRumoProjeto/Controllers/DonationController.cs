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
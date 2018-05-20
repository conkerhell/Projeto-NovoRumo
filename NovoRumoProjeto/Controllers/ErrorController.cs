using System.Web.Mvc;

namespace NovoRumoProjeto.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Error(HandleErrorInfo model)
        {
            return View(model);
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult DefaultError()
        {
            return View();
        }

        public ActionResult PageNotFound()
        {
            return View();
        }
    }
}
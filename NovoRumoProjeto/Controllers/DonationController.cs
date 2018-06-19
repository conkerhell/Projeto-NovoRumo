using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using NovoRumoProjeto.DAL.User;
using NovoRumoProjeto.Models;
using NovoRumoProjeto.Utilities;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NovoRumoProjeto.Controllers
{
    public class DonationController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public DonationController()
        {
        }

        public DonationController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(Consts.VALIDATION_SUMMARY, "Dados inválidos.");
                return View(model);
            }

            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, false, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToAction("Checkout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError(Consts.VALIDATION_SUMMARY, "Dados inválidos.");
                    return View(model);
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(Consts.VALIDATION_SUMMARY, "Dados inválidos.");
                return View(model);
            }

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await UserManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                IUserDAL userDAL = new UserDAL();
                userDAL.Insert(new Entity.UserEntity()
                {
                    UserID = user.Id,
                    Name = model.Name
                });

                return RedirectToAction("Checkout");
            }
            else
            {
                ModelState.AddModelError(Consts.VALIDATION_SUMMARY, "Falha durante o registro.");
                return View(model);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout(DonationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(Consts.VALIDATION_SUMMARY, "Dados inválidos.");
                return View(model);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
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
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using NovoRumoProjeto.Areas.Admin.Models;

namespace NovoRumoProjeto.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AdminController()
        {
        }

        public AdminController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
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

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, false, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Tentativa de login inválida.");
                    return View(model);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Admin");
        }

        [AllowAnonymous]
        public ActionResult EsqueceuSenha()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EsqueceuSenha(ForgotPasswordViewModel model)
        {
            //if (ModelState.IsValid)
            //{
            //    var user = await UserManager.FindByNameAsync(model.Email);
            //    if (user == null) //|| !(await UserManager.IsEmailConfirmedAsync(user.Id)))
            //    {
            //        return View("EsqueceuSenhaConfirmacao");
            //    }

            //    var code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
            //    var callbackUrl = Url.Action("AlterarSenha", "Conta", new { UserId = user.Id, code = code }, protocol: Request.Url.Scheme);

            //    var mail = new MailObject();
            //    mail.Email = user.Email;
            //    mail.Subject = "Recuperação de Senha";
            //    mail.HtmlTemplate = Domain.dicionarioTemplateNames[Enums.TemplateName.resetPassword.ToString()];

            //    Dictionary<string, string> list = new Dictionary<string, string>();
            //    list.Add(Domain.dicionarioTags[Enums.TemplateTag.code.ToString()], callbackUrl);

            //    Mailer.SendTemplateEmail(mail, list);
            //    return View("EsqueceuSenhaConfirmacao");
            //}
            return View(model);
        }
    }
}
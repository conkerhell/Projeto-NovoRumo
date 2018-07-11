using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using NovoRumoProjeto.DAL.User;
using NovoRumoProjeto.Entity;
using NovoRumoProjeto.Models;
using NovoRumoProjeto.Utilities;
using NovoRumoProjeto.PaymentCreator;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using NovoRumoProjeto.Utilities.Domains;
using Microsoft.AspNet.Identity;
using System;
using Resources;
using NovoRumoProjeto.Utilities.Extensions;

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
                userDAL.Insert(new UserEntity()
                {
                    UserID = user.Id,
                    Name = model.Name,
                    Lastname = model.Lastname
                });

                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                return RedirectToAction("Checkout");
            }
            else
            {
                ModelState.AddModelError(Consts.VALIDATION_SUMMARY, "Falha durante o registro.");
                return View(model);
            }
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
            var model = new PageViewModel();
            model.GetPolicies();
            return View(model);
        }

        [HttpGet]
        [ActionName("termos-de-uso")]
        public ActionResult TermosDeUso()
        {
            var model = new PageViewModel();
            model.GetTerms();
            return View(model);
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

            var userId = User.Identity.GetUserId<int>();
            var userEntity = new UserDAL().GetById(userId);
            var user = new UserEntity()
            {
                UserID = userEntity.UserID,
                Name = userEntity.Name,
                Lastname = userEntity.Lastname.FormatLastName()
            };

            var paymentStrategy = new PaymentStrategy(
                new IPaymentService[] 
                {
                    new PagSeguroMonthlyPayment(),
                    new PagSeguroSinglePayment()
                });

            var paymentStatus = new PaymentStatus();

            switch ((Enums.Type)model.DonationOption)
            {
                case Enums.Type.MonthlyDonation:
                    var monthlyModel = new PagSeguroMonthlyModel();
                    monthlyModel.amountPerPayment = model.GetTotal();
                    monthlyModel.User = user;
                    monthlyModel.RequestContext = Request.RequestContext;
                    paymentStatus = paymentStrategy.MakePayment(monthlyModel);
                    break;
                case Enums.Type.SingleDonation:
                    var singleModel = new PagSeguroSingleModel();
                    singleModel.Value = model.GetTotal();
                    singleModel.User = user;
                    singleModel.Id = "1";
                    singleModel.RequestContext = Request.RequestContext;
                    paymentStatus = paymentStrategy.MakePayment(singleModel);
                    break;
                case Enums.Type.BankTransfer:
                    //TODO: Adicionar
                    break;
                case Enums.Type.Purchase:
                default:
                    //TODO: Erro
                    break;
            }

            if (paymentStatus.Status)
            {
                return Redirect(paymentStatus.RedirectUrl);
            }

            ModelState.AddModelError(Consts.VALIDATION_SUMMARY, LocalizedMessages.UnexpectedErrorDuringPayment);
            return View();
        }

        [AllowAnonymous]
        public void Notification(string notificationCode, string notificationType)
        {
            //LogManager.Log.Payment(string.Format("Codigo de notificacao: {0}", notificationCode));

            if (!string.IsNullOrWhiteSpace(notificationCode))
            {
                //IPaymentManager paymentManager = new PagseguroPaymentManager(Request.RequestContext);
                //paymentManager.CheckTransaction(notificationCode, notificationType);
            }
            else
            {
                throw new Exception("Codigo da transacao não foi informado");
            }
        }
    }
}

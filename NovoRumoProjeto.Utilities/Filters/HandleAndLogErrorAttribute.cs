using System.Web;
using System.Web.Mvc;

namespace NovoRumoProjeto.Utilities.Filters
{
    public class HandleAndLogErrorAtribute : HandleErrorAttribute
    {
        private bool IsAjax(ExceptionContext filterContext)
        {
            return filterContext.HttpContext.Request.Headers["X-Requested-with"] == "XMLHttpRequest";
        }

        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
                return;

            var httpException = filterContext.Exception as HttpException;

            //LogManager.Log.Error(filterContext.Exception);

            if (IsAjax(filterContext))
            {
                filterContext.Result = new JsonResult
                {
                    Data = new
                    {
                        error = true,
                        message = filterContext.Exception.Message
                    }
                };
            }
            else
            {
                string view = "Error";

                string controllerName = filterContext.RouteData.Values["controller"].ToString();
                string actionName = filterContext.RouteData.Values["action"].ToString();

                HandleErrorInfo model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
                filterContext.Result =  new ViewResult
                {
                    ViewName = view,
                    ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                    TempData = filterContext.Controller.TempData
                };

                if (httpException != null)
                {
                    filterContext.HttpContext.Response.StatusCode = httpException.GetHttpCode();
                }
                else
                {
                    filterContext.HttpContext.Response.StatusCode = 500;
                }

                filterContext.Result.ExecuteResult(filterContext.Controller.ControllerContext);
                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Clear();
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
            }
        }
    }
}

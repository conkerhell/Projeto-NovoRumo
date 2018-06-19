using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NovoRumoProjeto.Utilities.HtmlHelpers
{
    public static class ValidationHtmlHelpers
    {
        public static IHtmlString FoundationValidationSummary(this HtmlHelper html, string validationMessage = "")
        {
            StringBuilder sb = new StringBuilder();

            if (!html.ViewData.ModelState.IsValid)
            {
                string message = string.Empty;
                if (string.IsNullOrWhiteSpace(validationMessage))
                {
                    var modelError = html.ViewData.ModelState[Consts.VALIDATION_SUMMARY];

                    if (modelError != null && modelError.Errors.Count > 0)
                    {
                        message = modelError.Errors.First().ErrorMessage;
                    }
                }
                else
                {
                    message = validationMessage;
                }

                if (!string.IsNullOrWhiteSpace(message))
                {
                    sb.Append("<div data-closable class='callout alert-callout-border alert'>");
                    sb.AppendFormat("{0}", message);
                    sb.Append("<button class='close-button' aria-label='Fechar alerta' type='button' data-close>");
                    sb.Append("<span aria-hidden='true'>&times;</span>");
                    sb.Append("</button>");
                    sb.Append("</div>");    
                }
            }

            return new HtmlString(sb.ToString());
        }
    }
}

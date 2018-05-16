using NovoRumoProjeto.Utilities.FlashMessage;
using System.Web;
using System.Web.Mvc;

namespace NovoRumoProjeto.Utilities.HtmlHelpers
{
    public static class FlashMessageHtmlHelper
    {
        public static IHtmlString RenderFlashMessages(this HtmlHelper html)
        {
            //var messages = FlashMessage.Retrieve(html.ViewContext.HttpContext);
            //var output = "";

            //foreach (var message in messages)
            //{
            //    output += RenderFlashMessage(message);
            //}

            return html.Raw(string.Empty);
        }

        /// <summary>
        /// Renders the passed flash message as a Twitter Bootstrap alert component.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string RenderFlashMessage(FlashMessageModel message)
        {
            //string result = "<div class=\"" + message.Type.GetCssStyle() + " alert-dismissible\" role=\"alert\">\r\n";

            //result += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>\r\n";
            //if (!string.IsNullOrWhiteSpace(message.Title))
            //    result += "<strong>" + HttpUtility.HtmlEncode(message.Title) + "</strong> ";

            //if (message.IsHtml)
            //    result += message.Message;
            //else
            //    result += HttpUtility.HtmlEncode(message.Message);

            //result += "</div>";
            //return result;
            return string.Empty;
        }
    }
}

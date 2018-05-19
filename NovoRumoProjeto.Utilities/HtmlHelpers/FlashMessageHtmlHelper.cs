
using System.Web;
using System.Web.Mvc;
using Vereyon.Web;

namespace NovoRumoProjeto.Utilities.HtmlHelpers
{
    /// <summary>
    /// Twitter Bootstrap based HTML renderer for Flash Messages rendering the messages as alerts.
    /// </summary>
    public static class FlashMessageHtmlHelper
    {

        /// <summary>
        /// Renders any queued flash messages to and returns the html code. 
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static IHtmlString RenderFlashMessages(this HtmlHelper html)
        {
            // Retrieve queued messages.
            var messages = FlashMessage.Retrieve(html.ViewContext.HttpContext);
            var output = "";

            foreach (var message in messages)
            {
                output += RenderFlashMessage(message);
            }

            return html.Raw(output);
        }

        /// <summary>
        /// Renders the passed flash message as a Twitter Bootstrap alert component.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string RenderFlashMessage(FlashMessageModel message)
        {
            string result = "<div class=\"callout " + message.Type.GetCssStyle() + " small-12\"data-closable>\r\n";

            if (!string.IsNullOrWhiteSpace(message.Title))
                result += "<h5>" + HttpUtility.HtmlEncode(message.Title) + "</h5> ";

            if (message.IsHtml)
                result += message.Message;
            else
                result += HttpUtility.HtmlEncode(message.Message);

            result += "<button class='close-button' aria-label='Dismiss alert' type='button' data-close><span aria-hidden='true'>&times;</span></button>";
            result += "</div>";
            return result;
        }

        /// <summary>
        /// Returns the Twitter bootstrap css style for the passed message type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static string GetCssStyle(this FlashMessageType type)
        {
            switch (type)
            {
                case FlashMessageType.Danger:
                    return "alert";
                default:
                case FlashMessageType.Info:
                    return "primary";
                case FlashMessageType.Warning:
                    return "warning";
                case FlashMessageType.Confirmation:
                    return "success";
            }
        }
    }
}

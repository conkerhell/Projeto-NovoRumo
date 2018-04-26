using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NovoRumoProjeto.Utilities.HtmlHelpers
{
    public static class ButtonHtmlHelpers
    {
        public static IHtmlString SaveButton(this HtmlHelper html, string text)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<button type='submit' class='primary button'>");
            sb.Append("<i class='fi fi-save' aria-hidden='true'></i>");
            sb.Append(text);
            sb.Append("</div>");

            return new HtmlString(sb.ToString());
        }
    }
}

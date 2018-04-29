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

        public static IHtmlString EditButton(this HtmlHelper html, string controller)
        {
            StringBuilder sb = new StringBuilder();

            var href = string.Format("{0}/edit", controller);

            sb.AppendFormat("<a href='{0}' class='button secondary'>", href);
            sb.Append("<i class='fi fi-pencil' aria-hidden='true'></i>");
            sb.Append("Alterar");
            sb.Append("</a>");
            return new HtmlString(sb.ToString());
        }

        public static IHtmlString AddButton(this HtmlHelper html, string controller)
        {
            StringBuilder sb = new StringBuilder();

            var href = string.Format("{0}/add", controller);

            sb.AppendFormat("<button type='submit' class='button secondary'>");
            sb.Append("<i class='fi fi-plus' aria-hidden='true'></i>");
            sb.Append("Cadastrar");
            sb.Append("</div>");
            return new HtmlString(sb.ToString());
        }
    }
}

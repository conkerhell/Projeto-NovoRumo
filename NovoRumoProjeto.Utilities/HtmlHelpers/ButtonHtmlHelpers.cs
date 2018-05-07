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

            var href = string.Format("{0}/edit", controller);

            sb.AppendFormat("<a href='{0}' class='button secondary'>", href);
            sb.Append("<i class='fi fi-plus' aria-hidden='true'></i>");
            sb.Append("Cadastrar");
            sb.Append("</a>");
            return new HtmlString(sb.ToString());
        }

        public static IHtmlString DeleteButton(this HtmlHelper html, string controller)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("<button type='submit' class='primary button'>");
            sb.AppendFormat("<i class='fi fi-trash' aria-hidden='true'></i>");
            sb.AppendFormat("Excluir");
            return new HtmlString(sb.ToString());
        }

        public static IHtmlString ResetButton(this HtmlHelper html, string controller)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" <button type='reset' value='Reset' class='primary button'>");
            sb.AppendFormat("<i class='fi fi-loop' aria-hidden='true'></i>");
            sb.AppendFormat("Reset");
            return new HtmlString(sb.ToString());
        }
    }
}

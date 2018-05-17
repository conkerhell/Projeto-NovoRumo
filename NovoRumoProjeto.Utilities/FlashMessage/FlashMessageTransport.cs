using System.Web;

namespace NovoRumoProjeto.Utilities.FlashMessage
{
    public class FlashMessageTransport
    {
        public string KeyName { get; set; }

        public FlashMessageTransport()
        {

            KeyName = "_FlashMessage";
        }

        public void Add(FlashMessageModel message)
        {
            var data = FlashMessage.Serialize(message);

            var context = new HttpContextWrapper(HttpContext.Current);
            context.Session[KeyName] = data;
        }
    }
}

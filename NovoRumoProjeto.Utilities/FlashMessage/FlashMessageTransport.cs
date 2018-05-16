
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

        public void Add(FlashMessageModel messages)
        {
            // Set the data without doing any further securing or transformations.
            var context = new HttpContextWrapper(HttpContext.Current);
            //context.Session[KeyName] = data;
        }
    }
}

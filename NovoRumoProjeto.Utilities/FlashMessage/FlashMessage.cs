using System.Collections.Generic;
using System.IO;

namespace NovoRumoProjeto.Utilities.FlashMessage
{
    public class FlashMessage
    {
        private FlashMessage flashMessage = new FlashMessage();
        public static FlashMessageTransport Transport { get; set; }

        static FlashMessage()
        {
            Transport = new FlashMessageTransport();
        }

        public static void Success(string message)
        {
            //Transport.Add()
        }

        public static byte[] Serialize(FlashMessageModel message)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(message.Message);
                    writer.Write(message.Title);
                    writer.Write((byte)message.Type);

                    writer.Flush();
                    return stream.ToArray();
                }
            }
        }
    }
}

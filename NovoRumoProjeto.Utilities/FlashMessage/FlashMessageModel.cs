
namespace NovoRumoProjeto.Utilities.FlashMessage
{
    public class FlashMessageModel
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public FlashMessageType Type { get; set; }

        public FlashMessageModel()
        {
            Type = FlashMessageType.Info;
        }
    }

    public enum FlashMessageType : byte
    {
        Info,
        Warning,
        Danger,
        Confirmation
    }
}

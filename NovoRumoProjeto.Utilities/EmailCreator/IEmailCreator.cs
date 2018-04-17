
namespace NovoRumoProjeto.Utilities.EmailCreator
{
    public interface IEmailCreator
    {
        IEmailCreator From(string fromAddress);
        IEmailCreator To(params string[] toAddresses);
        IEmailCreator CC(params string[] ccAddresses);
        IEmailCreator BCC(params string[] bccAddresses);
        IEmailCreator WithSubject(string subject);
        IEmailCreator WithBody(string body);
        void Send();
    }
}

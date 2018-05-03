using Microsoft.VisualStudio.TestTools.UnitTesting;
using NovoRumoProjeto.Utilities.EmailCreator;

namespace NovoRumoProjeto.Tests.Utilities.EmailCreatorTest
{
    [TestClass]
    public class EmailCreatorTest
    {
        [TestMethod]
        public void Should_SendEmail()
        {
            var sender = "fontiana@gmail.com";
            var destiny = "fontiana@gmail.com";
            EmailCreator.CreateEmailFrom(sender)
                .To(destiny)
                .WithBody("This is a test")
                .WithSubject("Test")
                .Send();
        }
    }
}

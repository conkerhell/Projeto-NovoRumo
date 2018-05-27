
using NovoRumoProjeto.DAL.Contact;

namespace NovoRumoProjeto.Models
{
    public class ContactViewModel
    {
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string SecondaryMobile { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }

        public void Get()
        {
            IContactDAL contactDAL = new ContactDAL();
            var entity = contactDAL.GetContact();

            Address = entity.Address;
            Telephone = entity.Telephone;
            Mobile = entity.Mobile;
            SecondaryMobile = entity.SecondaryMobile;
            Email = entity.Email;
            CEP = entity.CEP;
        }
    }
}
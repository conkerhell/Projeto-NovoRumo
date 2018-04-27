using NovoRumoProjeto.Entity;

namespace NovoRumoProjeto.DAL.Contact
{
    public interface IContactDAL : IDAL<ContactEntity>
    {
        ContactEntity GetContact();
    }
}

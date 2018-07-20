using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovoRumoProjeto.Entity;

namespace NovoRumoProjeto.DAL.Donation
{
    public interface IDonation: IDAL<DonationEntity>
    {
        bool Delete(int id);
        List<DonationEntity> GetOrders();
    }
}

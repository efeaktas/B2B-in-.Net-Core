using Bayi.Business.BaseRepository;
using Bayi.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.Business.IServiceRepository
{
    public interface IDealerSaleRepository : IRepository<DealerSale>
    {
        List<DealerSale> ListActiveOnes();

        DealerSale GetSale(int id);

        List<DealerSale> ListActiveOnesForDealer(int id);
    }
}

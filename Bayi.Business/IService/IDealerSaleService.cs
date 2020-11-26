using Bayi.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.Business.IService
{
    public interface IDealerSaleService
    {
        void Add(DealerSale dealerSale);

        List<DealerSale> ListActiveOnes();

        DealerSale GetSale(int id);

        void Update(DealerSale dealerSale);

        List<DealerSale> ListActiveOnesForDealer(int id);
    }
}

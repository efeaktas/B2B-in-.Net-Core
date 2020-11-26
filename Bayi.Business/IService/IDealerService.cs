using Bayi.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.Business.IService
{
    public interface IDealerService
    {
        void Add(Dealer dealer);

        void Update(Dealer dealer);

        List<Dealer> List();

        Dealer Get(int id);

        List<Dealer> ListDealerStockStatus();

        Dealer GetByAppUserId(int id);
    }
}

using Bayi.Business.BaseRepository;
using Bayi.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.Business.IServiceRepository
{
    public interface IDealerRepository : IRepository<Dealer>
    {
        Dealer Get(int id);

        List<Dealer> ListDealerStockStatus();

        Dealer GetByAppUserId(int id);
    }
}

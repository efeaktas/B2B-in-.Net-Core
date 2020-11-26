using Bayi.Business.BaseRepository;
using Bayi.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.Business.IServiceRepository
{
    public interface IDealerProductRepository : IRepository<DealerProduct>
    {
        DealerProduct IsExists(int dealerId, int productId);

        List<DealerProduct> ListDealerStockStatus();

        List<DealerProduct> ListDealerStockStatusForDealer(int dealerId);
    }
}

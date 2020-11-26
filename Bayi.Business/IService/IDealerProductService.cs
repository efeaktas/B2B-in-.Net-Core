using Bayi.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.Business.IService
{
    public interface IDealerProductService
    {
        DealerProduct IsExists(int dealerId, int productId);

        void Add(DealerProduct dealerProduct);

        DealerProduct Update(DealerProduct dealerProduct);

        void UpdateDealerStock(DealerProduct dealer, int quantity);

        List<DealerProduct> ListDealerStockStatus();

        List<DealerProduct> ListDealerStockStatusForDealer(int dealerId);
    }
}

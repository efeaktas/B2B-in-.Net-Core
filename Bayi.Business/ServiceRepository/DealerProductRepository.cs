using Bayi.Business.BaseRepository;
using Bayi.Business.Factory;
using Bayi.Business.IServiceRepository;
using Bayi.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bayi.Business.ServiceRepository
{
    public class DealerProductRepository : Repository<DealerProduct>, IDealerProductRepository
    {
        public DealerProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public DealerProduct IsExists(int dealerId, int productId)
        {
            return _dbContext.DealerProduct.Where(p =>p.IsActive==true && p.DealerId == dealerId && p.ProductId == productId).Include(r => r.Dealer).Include(s => s.Product).SingleOrDefault();
        }

        public List<DealerProduct> ListDealerStockStatus()
        {
            return _dbContext.DealerProduct.Where(p => p.IsActive == true && p.Dealer.IsActive == true).Include(r => r.Product).Include(s => s.Dealer).ThenInclude(t => t.AppUser).ToList();
        }

        public List<DealerProduct> ListDealerStockStatusForDealer(int dealerId)
        {
            return _dbContext.DealerProduct.Where(p=>p.Dealer.AppUserId==dealerId && p.IsActive==true &&p.Dealer.IsActive==true).Include(r => r.Product).Include(s => s.Dealer).ThenInclude(t => t.AppUser).ToList();
        }
    }
}

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
    public class DealerSaleRepository : Repository<DealerSale>, IDealerSaleRepository
    {
        public DealerSaleRepository(IDbFactory dbFactory)
          : base(dbFactory)
        {
        }

        public DealerSale GetSale(int id)
        {
            return _dbContext.DealerSale.Where(p => p.Id == id && p.IsActive == true).Include(r => r.Product).Include(s => s.Customer).Include(t => t.Dealer).ThenInclude(a => a.AppUser).SingleOrDefault();
        }

        public List<DealerSale> ListActiveOnes()
        {
            return _dbContext.DealerSale.Where(p => p.IsActive == true).Include(r => r.Product).Include(s => s.Customer).Include(t => t.Dealer).ThenInclude(a => a.AppUser).ToList();
        }

        public List<DealerSale> ListActiveOnesForDealer(int id)
        {
            return _dbContext.DealerSale.Where(p => p.IsActive == true && p.DealerId == id).Include(r => r.Product).Include(s => s.Customer).Include(t => t.Dealer).ThenInclude(a => a.AppUser).ToList();
        }
    }
}

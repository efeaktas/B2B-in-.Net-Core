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
    public class DealerRepository : Repository<Dealer>, IDealerRepository
    {
        public DealerRepository(IDbFactory dbFactory)
          : base(dbFactory)
        {
        }

        public Dealer Get(int id)
        {
            return _dbContext.Dealer.Where(p => p.Id == id && p.IsActive == true).Include(r => r.AppUser).Include(s => s.DealerProducts).SingleOrDefault();
        }

        public Dealer GetByAppUserId(int id)
        {
            return _dbContext.Dealer.Where(p => p.AppUserId == id && p.IsActive == true).Include(r => r.AppUser).Include(s => s.DealerProducts).SingleOrDefault();
        }

        public List<Dealer> ListDealerStockStatus()
        {
            return _dbContext.Dealer.Where(p => p.IsActive == true).Include(r => r.DealerProducts).Where(c=>c.IsActive==true).Include(a => a.AppUser).ToList();
        }
    }
}

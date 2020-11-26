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
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory)
          : base(dbFactory)
        {
        }

        public List<Order> ListActiveOnes()
        {
            return _dbContext.Order.Where(p => p.IsActive == true && p.IsRead == false).Include(r => r.Product).Include(s => s.AppUser).ToList();
        }

        public List<Order> ListActiveOnesForDealer(int id)
        {
            return _dbContext.Order.Where(p => p.IsActive == true && p.AppUserId == id).Include(r => r.Product).Include(s => s.AppUser).ToList();
        }

        public List<Order> ListReadOnes()
        {
            return _dbContext.Order.Where(p => p.IsRead == true).Include(r => r.Product).Include(s => s.AppUser).ToList();
        }
    }
}

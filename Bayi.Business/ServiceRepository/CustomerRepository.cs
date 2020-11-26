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
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDbFactory dbFactory)
          : base(dbFactory)
        {
        }

        public List<Customer> ListActiveOnes()
        {
            return _dbContext.Customer.Where(p => p.IsActive == true).Include(r=>r.Dealer).ThenInclude(s=>s.AppUser).ToList();
        }

        public List<Customer> ListActiveOnesByDealerId(int dealerId)
        {
            return _dbContext.Customer.Where(p => p.IsActive == true &&p.DealerId==dealerId).Include(r => r.Dealer).ThenInclude(s => s.AppUser).ToList();
        }
    }
}

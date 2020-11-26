using Bayi.Business.BaseRepository;
using Bayi.Business.Factory;
using Bayi.Business.IServiceRepository;
using Bayi.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bayi.Business.ServiceRepository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory)
          : base(dbFactory)
        {
        }

        public List<Product> GetActiveProducts()
        {
            return _dbContext.Product.Where(p => p.IsActive == true).ToList();
        }
    }
}

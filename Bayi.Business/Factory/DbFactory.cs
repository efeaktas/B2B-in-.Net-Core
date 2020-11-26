using Bayi.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.Business.Factory
{
    public class DbFactory : IDbFactory, IDisposable
    {
        protected BayiDbContext _dbContext;

        public void Dispose()
        {

            GC.SuppressFinalize(this);
        }

        public BayiDbContext Init()
        {

            return _dbContext ?? (_dbContext = new BayiDbContext());
        }
    }
}

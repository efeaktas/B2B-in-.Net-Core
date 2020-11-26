using Bayi.Business.Factory;
using Bayi.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.Business.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork 
    {
        private BayiDbContext _dbContext;
        private IDbFactory _dbFactory;
        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
            _dbContext = this._dbFactory.Init();
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges(); 
        }
    }
}

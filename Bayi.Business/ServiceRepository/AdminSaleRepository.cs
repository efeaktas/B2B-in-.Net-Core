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
    public class AdminSaleRepository : Repository<AdminSale>, IAdminSaleRepository
    {
        public AdminSaleRepository(IDbFactory dbFactory)
          : base(dbFactory)
        {
        }

        public AdminSale GetSale(int id)
        {
            return _dbContext.AdminSale.Where(p => p.Id == id).Include(r => r.Product).Include(s => s.Dealer).ThenInclude(b => b.AppUser).Include(a => a.AppUser).SingleOrDefault();
        }

        public List<AdminSale> GetSalesByDealer(int id)
        {
            return _dbContext.AdminSale.Where(p => p.DealerId == id && p.IsActive==true).Include(r => r.Product).Include(s => s.Dealer).ThenInclude(b => b.AppUser).Include(a => a.AppUser).ToList();
        }

        public List<AdminSale> ListActives()
        {
            return _dbContext.AdminSale.Where(p => p.IsActive == true).Include(r=>r.Product).Include(s=>s.Dealer).ThenInclude(b=>b.AppUser).Include(a=>a.AppUser).ToList();
        }
    }
}

using Bayi.Business.BaseRepository;
using Bayi.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.Business.IServiceRepository
{
    public interface IAdminSaleRepository : IRepository<AdminSale>
    {
        List<AdminSale> ListActives();

        AdminSale GetSale(int id);

        List<AdminSale> GetSalesByDealer(int id);
    }
}

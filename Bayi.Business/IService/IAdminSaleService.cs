using Bayi.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.Business.IService
{
    public interface IAdminSaleService
    {
        void Add(AdminSale adminSale);

        List<AdminSale> ListActives();

        AdminSale GetSale(int id);

        void Update(AdminSale adminSale);

        void UpdateSaleStock(AdminSale sale, int quantity);

        List<AdminSale> GetSalesByDealer(int id);
    }
}

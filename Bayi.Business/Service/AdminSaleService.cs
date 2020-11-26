using Bayi.Business.IService;
using Bayi.Business.IServiceRepository;
using Bayi.Business.UnitOfWork;
using Bayi.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.Business.Service
{
    public class AdminSaleService : IAdminSaleService
    {
        private readonly IAdminSaleRepository _adminSaleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AdminSaleService(IAdminSaleRepository adminSaleRepository, IUnitOfWork unitOfWork)
        {
            this._adminSaleRepository = adminSaleRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(AdminSale adminSale)
        {
            this._adminSaleRepository.Add(adminSale);
            this._unitOfWork.SaveChanges();
        }

        public AdminSale GetSale(int id) => this._adminSaleRepository.GetSale(id);

        public List<AdminSale> GetSalesByDealer(int id) => this._adminSaleRepository.GetSalesByDealer(id);

        public List<AdminSale> ListActives() => this._adminSaleRepository.ListActives();

        public void Update(AdminSale adminSale)
        {
            this._adminSaleRepository.Update(adminSale);
            this._unitOfWork.SaveChanges();
        }

        public void UpdateSaleStock(AdminSale sale, int quantity)
        {
            sale.IsActive = false;
            sale.Product.Stock += quantity;
            this._adminSaleRepository.Update(sale);
            this._unitOfWork.SaveChanges();
        }
    }
}

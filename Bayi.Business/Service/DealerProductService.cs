using Bayi.Business.IService;
using Bayi.Business.IServiceRepository;
using Bayi.Business.UnitOfWork;
using Bayi.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.Business.Service
{
    public class DealerProductService : IDealerProductService
    {
        private readonly IDealerProductRepository _dealerProductRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DealerProductService(
          IDealerProductRepository dealerProductRepository,
          IUnitOfWork unitOfWork)
        {
            this._dealerProductRepository = dealerProductRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(DealerProduct dealerProduct)
        {
            this._dealerProductRepository.Add(dealerProduct);
            this._unitOfWork.SaveChanges();
        }

        public DealerProduct IsExists(int dealerId, int productId) => this._dealerProductRepository.IsExists(dealerId, productId);

        public List<DealerProduct> ListDealerStockStatus() => this._dealerProductRepository.ListDealerStockStatus();

        public List<DealerProduct> ListDealerStockStatusForDealer(int dealerId) => this._dealerProductRepository.ListDealerStockStatusForDealer(dealerId);

        public DealerProduct Update(DealerProduct dealerProduct)
        {
            dealerProduct = this._dealerProductRepository.Update(dealerProduct);
            this._unitOfWork.SaveChanges();
            return dealerProduct;
        }

        public void UpdateDealerStock(DealerProduct dealer, int quantity)
        {
            DealerProduct entity = _dealerProductRepository.IsExists(dealer.DealerId, dealer.ProductId);
            entity.Stock -= quantity;
            this._dealerProductRepository.Update(entity);
            this._unitOfWork.SaveChanges();
        }
    }
}

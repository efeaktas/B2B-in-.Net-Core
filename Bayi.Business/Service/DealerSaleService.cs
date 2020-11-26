using Bayi.Business.IService;
using Bayi.Business.IServiceRepository;
using Bayi.Business.UnitOfWork;
using Bayi.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.Business.Service
{
    public class DealerSaleService : IDealerSaleService
    {
        private readonly IDealerSaleRepository _dealerSaleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DealerSaleService(IDealerSaleRepository dealerSaleRepository, IUnitOfWork unitOfWork)
        {
            this._dealerSaleRepository = dealerSaleRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(DealerSale dealerSale)
        {
            this._dealerSaleRepository.Add(dealerSale);
            this._unitOfWork.SaveChanges();
        }

        public DealerSale GetSale(int id) => this._dealerSaleRepository.GetSale(id);

        public List<DealerSale> ListActiveOnes() => this._dealerSaleRepository.ListActiveOnes();

        public List<DealerSale> ListActiveOnesForDealer(int id) => this._dealerSaleRepository.ListActiveOnesForDealer(id);

        public void Update(DealerSale dealerSale)
        {
            this._dealerSaleRepository.Update(dealerSale);
            this._unitOfWork.SaveChanges();
        }
    }
}

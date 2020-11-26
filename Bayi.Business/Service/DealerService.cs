using Bayi.Business.IService;
using Bayi.Business.IServiceRepository;
using Bayi.Business.UnitOfWork;
using Bayi.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.Business.Service
{
    public class DealerService : IDealerService
    {
        private readonly IDealerRepository _dealerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DealerService(IDealerRepository dealerRepository, IUnitOfWork unitOfWork)
        {
            this._dealerRepository = dealerRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Dealer dealer)
        {
            this._dealerRepository.Add(dealer);
            this._unitOfWork.SaveChanges();
        }

        public Dealer Get(int id) => this._dealerRepository.Get(id);

        public Dealer GetByAppUserId(int id) => this._dealerRepository.GetByAppUserId(id);

        public List<Dealer> List() => this._dealerRepository.GetAll();

        public List<Dealer> ListDealerStockStatus() => this._dealerRepository.ListDealerStockStatus();

        public void Update(Dealer dealer)
        {
            this._dealerRepository.Update(dealer);
            this._unitOfWork.SaveChanges();
        }
    }
}

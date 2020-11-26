using Bayi.Business.IService;
using Bayi.Business.IServiceRepository;
using Bayi.Business.UnitOfWork;
using Bayi.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.Business.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            this._customerRepository = customerRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Customer customer)
        {
            this._customerRepository.Add(customer);
            this._unitOfWork.SaveChanges();
        }

        public Customer GetById(int id) => this._customerRepository.GetById(id);

        public List<Customer> ListActiveOnes() => this._customerRepository.ListActiveOnes();

        public List<Customer> ListActiveOnesByDealerId(int dealerId) => this._customerRepository.ListActiveOnesByDealerId(dealerId);

        public void Update(Customer customer)
        {
            this._customerRepository.Update(customer);
            this._unitOfWork.SaveChanges();
        }
    }
}

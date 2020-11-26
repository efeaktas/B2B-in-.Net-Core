using Bayi.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.Business.IService
{
    public interface ICustomerService
    {
        void Add(Customer customer);

        List<Customer> ListActiveOnesByDealerId(int dealerId);

        Customer GetById(int id);

        void Update(Customer customer);

        List<Customer> ListActiveOnes();
    }
}

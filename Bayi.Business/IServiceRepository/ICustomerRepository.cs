using Bayi.Business.BaseRepository;
using Bayi.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.Business.IServiceRepository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        List<Customer> ListActiveOnesByDealerId(int dealerId);

        List<Customer> ListActiveOnes();
    }
}

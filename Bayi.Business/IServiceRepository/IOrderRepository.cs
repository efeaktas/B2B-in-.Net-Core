using Bayi.Business.BaseRepository;
using Bayi.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.Business.IServiceRepository
{
    public interface IOrderRepository : IRepository<Order>
    {
        List<Order> ListActiveOnes();

        List<Order> ListActiveOnesForDealer(int id);

        List<Order> ListReadOnes();
    }
}

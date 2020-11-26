using Bayi.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.Business.IService
{
    public interface IOrderService
    {
        void Add(Order order);

        List<Order> ListActiveOnes();

        Order GetById(int id);

        void Update(Order order);

        List<Order> ListActiveOnesForDealer(int id);

        List<Order> ListReadOnes();
    }
}

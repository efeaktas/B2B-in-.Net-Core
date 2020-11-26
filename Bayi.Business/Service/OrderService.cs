using Bayi.Business.IService;
using Bayi.Business.IServiceRepository;
using Bayi.Business.UnitOfWork;
using Bayi.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.Business.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            this._orderRepository = orderRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Order order)
        {
            this._orderRepository.Add(order);
            this._unitOfWork.SaveChanges();
        }

        public Order GetById(int id) => this._orderRepository.GetById(id);

        public List<Order> ListActiveOnes() => this._orderRepository.ListActiveOnes();

        public List<Order> ListActiveOnesForDealer(int id) => this._orderRepository.ListActiveOnesForDealer(id);

        public List<Order> ListReadOnes() => this._orderRepository.ListReadOnes();

        public void Update(Order order)
        {
            this._orderRepository.Update(order);
            this._unitOfWork.SaveChanges();
        }
    }
}

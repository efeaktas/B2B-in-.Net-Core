using Bayi.Business.IService;
using Bayi.Business.IServiceRepository;
using Bayi.Business.UnitOfWork;
using Bayi.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.Business.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this._productRepository = productRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Product product)
        {
            this._productRepository.Add(product);
            this._unitOfWork.SaveChanges();
        }

        public List<Product> GetActiveProducts() => this._productRepository.GetActiveProducts();

        public List<Product> GetAll() => this._productRepository.GetAll();

        public Product GetById(int productId) => this._productRepository.GetById(productId);

        public Product Update(Product product)
        {
            product = this._productRepository.Update(product);
            this._unitOfWork.SaveChanges();
            return product;
        }
    }
}

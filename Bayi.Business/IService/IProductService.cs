using Bayi.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.Business.IService
{
    public interface IProductService
    {
        void Add(Product product);

        List<Product> GetAll();

        Product GetById(int productId);

        Product Update(Product product);

        List<Product> GetActiveProducts();
    }
}

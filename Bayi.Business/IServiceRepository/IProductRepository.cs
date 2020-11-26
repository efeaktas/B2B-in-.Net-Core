﻿using Bayi.Business.BaseRepository;
using Bayi.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.Business.IServiceRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> GetActiveProducts();
    }
}
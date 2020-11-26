using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.DTO.Product
{
    public class CreateProductRequest
    {
        public string ProductName { get; set; }

        public string Quantity { get; set; }

        public string BuyingPrice { get; set; }

        public string SalePrice { get; set; }
    }
}

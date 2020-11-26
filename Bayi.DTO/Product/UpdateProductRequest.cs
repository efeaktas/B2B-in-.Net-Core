using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.DTO.Product
{
    public class UpdateProductRequest
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string BuyingPrice { get; set; }

        public string SalePrice { get; set; }
    }
}

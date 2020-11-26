using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.DTO.Product
{
    public class ListProductResponse
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public string BuyingPrice { get; set; }

        public string SalePrice { get; set; }
    }
}

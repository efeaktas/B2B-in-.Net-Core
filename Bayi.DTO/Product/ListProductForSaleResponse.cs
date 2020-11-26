using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.DTO.Product
{
    public class ListProductForSaleResponse
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public string SalePrice { get; set; }
    }
}

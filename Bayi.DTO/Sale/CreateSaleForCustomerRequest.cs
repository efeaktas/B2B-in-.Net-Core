using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.DTO.Sale
{
    public class CreateSaleForCustomerRequest
    {
        public int ProductId { get; set; }

        public int CustomerId { get; set; }

        public string Quantity { get; set; }

        public string SaleTime { get; set; }

        public string SalePrice { get; set; }
    }
}

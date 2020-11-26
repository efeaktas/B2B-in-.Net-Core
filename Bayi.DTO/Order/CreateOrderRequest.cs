using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.DTO.Order
{
    public class CreateOrderRequest
    {
        public int ProductId { get; set; }

        public string Quantity { get; set; }

        public string Statement { get; set; }

        public string SaleTime { get; set; }
    }
}

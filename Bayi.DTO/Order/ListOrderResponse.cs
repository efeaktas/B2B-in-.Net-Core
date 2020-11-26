using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.DTO.Order
{
    public class ListOrderResponse
    {
        public int Id { get; set; }

        public string DealerName { get; set; }

        public int Quantity { get; set; }

        public string ProductName { get; set; }

        public string DateOfOrder { get; set; }

        public string Statement { get; set; }

        public bool IsRead { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.DTO.Dealer
{
    public class ListDealerStockStatusResponse
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }
    }
}

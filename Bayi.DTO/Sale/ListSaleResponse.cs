using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.DTO.Sale
{
    public class ListSaleResponse
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string CustomerName { get; set; }

        public int Quantity { get; set; }

        public int ProductStock { get; set; }

        public string ProductName { get; set; }

        public string UnitPrice { get; set; }

        public string DateOfSale { get; set; }

        public string TotalPrice { get; set; }
    }
}

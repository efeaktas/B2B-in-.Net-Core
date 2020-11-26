using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bayi.DataAccess
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal AdminBuyPrice { get; set; }
        public decimal AdminSalePrice { get; set; }
        public decimal DealerSalePrice { get; set; }
        public bool IsActive { get; set; }
        public virtual List<DealerProduct> DealerProducts { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<AdminSale> AdminSales { get; set; }
        public virtual List<DealerSale> DealerSales { get; set; }
    }
}

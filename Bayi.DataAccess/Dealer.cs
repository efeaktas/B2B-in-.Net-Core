using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bayi.DataAccess
{
    public class Dealer
    {
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public virtual List<DealerProduct> DealerProducts { get; set; }
        public virtual List<Customer> Customers { get; set; }
        public virtual List<AdminSale> AdminSales { get; set; }
        public virtual List<DealerSale> DealerSales { get; set; }
        [ForeignKey("AppUser")]
        public virtual int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}

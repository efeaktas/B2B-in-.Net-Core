using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bayi.DataAccess
{
    public class DealerSale
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string DateOfSale { get; set; }
        public bool IsActive { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        [ForeignKey("Dealer")]
        public virtual int DealerId { get; set; }
        public virtual Dealer Dealer { get; set; }
        [ForeignKey("Customer")]
        public virtual int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        [ForeignKey("Product")]
        public virtual int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}

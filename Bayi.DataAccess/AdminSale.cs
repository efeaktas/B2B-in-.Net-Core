using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bayi.DataAccess
{
    public class AdminSale
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
        [ForeignKey("AppUser")]
        public virtual int AdminId { get; set; }
        public virtual AppUser AppUser { get; set; }
        [ForeignKey("Product")]
        public virtual int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}

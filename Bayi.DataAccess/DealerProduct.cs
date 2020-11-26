using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bayi.DataAccess
{
    public class DealerProduct
    {

        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public int Stock { get; set; }
        public decimal DealerSalePrice { get; set; }
        public decimal DealerBuyPrice { get; set; }
        [ForeignKey("Product")]
        public virtual int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [ForeignKey("Dealer")]
        public virtual int DealerId { get; set; }
        public virtual Dealer Dealer { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bayi.DataAccess
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string DateOfOrder { get; set; }
        public int Quantity { get; set; }
        public string Statement { get; set; }
        public bool IsRead { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey("AppUser")]
        public virtual int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        [ForeignKey("Product")]
        public virtual int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
